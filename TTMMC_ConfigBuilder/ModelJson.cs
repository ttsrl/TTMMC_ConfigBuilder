using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace TTMMC_ConfigBuilder
{

    public enum MachineType
    {
        Machinary,
        UtilityMachine
    }

    public enum LogarithmAritmeticOperator
    {
        Equal,
        Major,
        Minor,
        MajorEqual,
        MinorEqual,
        NotEqual
    }

    public enum ConfrontVarType
    {
        Value,
        DataItem,
        LastDataItemRecValue
    }

    [Flags]
    public enum DataGroupMode
    {
        Read = 1,
        Write = 2,
        ReadAndWrite = 4
    }

    [Flags]
    public enum DataItemAttribute
    {
        Realtime = 1,
        Logs = 2
    }

    public enum DataType
    {
        AUTO,
        BOOL,
        BYTE,
        INT16,
        UINT16,
        INT32,
        UINT32,
        INT64,
        UINT64,
        FLOAT,
        DOUBLE,
        STRING
    }

    public enum ReadMode
    {
        Null,
        Continuous,
        AtCallRead
    }

    public class ModelJson
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public List<Machine> Machines { get; set; }
        public List<VpnItem> Vpn { get; set; }
        public List<RecipeLayout> RecipeLayouts { get; set; }
    }

    public class ModelJsonWithStandardOb
    {
        private Logging logging = new Logging();
        public Logging Logging { get => logging; set => logging = value; }
        public string AllowedHosts = "*";

        public Dictionary<string, string> ConnectionStrings { get; set; }
        public List<Machine> Machines { get; set; }
        public List<VpnItem> Vpn { get; set; }
        public List<RecipeLayout> RecipeLayouts { get; set; }
    }

    public class Machine
    {
        private int refTime = 500;
        private int readTime = 1000;
        private string shareEngine = null;
        private string group = null;
        private List<DataGroup> datas = new List<DataGroup>();
        private RecordingDetails recDetails = new RecordingDetails();

        public MachineType Type { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Group { get => group; set => group = value; }
        public string ShareEngine { get => shareEngine; set => shareEngine = value; }
        public ReadMode ReadMode { get; set; }
        public string Protocol { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string RootPath { get; set; }
        public string OnlineDataItem { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int CallRealtimeDatasReadInterval { get => refTime; set { refTime = (value < 50) ? 50 : value; } }
        public int ReadingContinuousInterval { get => readTime; set { readTime = (value < 100) ? 100 : value; } }
        public RecordingDetails RecordingDetails { get => recDetails; set => recDetails = value; }
        public List<DataGroup> Datas { get => datas; set => datas = value; }

    }

    public class DB
    {
        public string IP { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool PersistSecurityInfo { get; set; }

        public static DB Parse(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                var db_ = new DB();
                var split = connectionString.Split(new char[] { ';' });
                foreach (var str in split)
                {
                    var val = str.Split(new char[] { '=' });
                    if (string.IsNullOrEmpty(val[1]))
                        continue;
                    var p = val[0].Replace(" ", "");
                    if (p == "DataSource")
                        db_.IP = val[1];
                    else if (p == "InitialCatalog")
                        db_.Database = val[1];
                    else if (p == "PersistSecurityInfo")
                        db_.PersistSecurityInfo = Boolean.Parse(val[1]);
                    else if (p == "UserID")
                        db_.Username = val[1];
                    else if (p == "Password")
                        db_.Password = val[1];
                }
                if (!string.IsNullOrEmpty(db_.IP) && !string.IsNullOrEmpty(db_.Username) && !string.IsNullOrEmpty(db_.Password))
                    return db_;
            }
            return null;
        }

        public override string ToString()
        {
            return "Data Source=" + IP + ";Initial Catalog=" + Database + ";Persist Security Info=" + PersistSecurityInfo.ToString() + ";User ID=" + Username + ";Password=" + Password;
        }
    }

    [Serializable]
    public class RecipeLayout : ICloneable
    {
        private List<string> machs = new List<string>();

        public string Name { get; set; }
        public string Label { get; set; }
        public List<string> Machines { get => machs; set => machs = value; }

        public RecipeLayout() { }

        public RecipeLayout(string name, string label, IEnumerable<string> machines)
        {
            Name = name;
            Label = label;
            Machines = machines.ToList();
        }

        public RecipeLayout(string name, string label, params string[] machines)
        {
            Name = name;
            Label = label;
            Machines = new List<string>(machines);
        }

        public object Clone()
        {
            var clone = (RecipeLayout)this.MemberwiseClone();
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, this.Machines);
                stream.Seek(0, SeekOrigin.Begin);
                clone.Machines = (List<string>)formatter.Deserialize(stream);
            }
            return clone;
        }
    }

    [Serializable]
    public class VpnItem : ICloneable
    {
        public string Name { get; set; }
        public string Ip { get; set; }

        public VpnItem() { }

        public VpnItem(string name, string ip)
        {
            Name = name;
            Ip = ip;
        }

        public object Clone()
        {
            var clone = (VpnItem)this.MemberwiseClone();
            return clone;
        }
    }

    [Serializable]
    public class ConfrontVar
    {
        public ConfrontVarType Type { get; set; }
        public string Value { get; set; }

        public object Clone()
        {
            var clone = (ConfrontVar)this.MemberwiseClone();
            return clone;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public string GetDataGroup()
        {
            if (Type != ConfrontVarType.DataItem || string.IsNullOrEmpty(Value))
                return "";
            return Value.Substring(0, Value.IndexOf("["));
        }

        public int GetDataItem()
        {
            if (Type != ConfrontVarType.DataItem || string.IsNullOrEmpty(Value))
                return 0;
            return int.Parse(Value.Substring(Value.IndexOf("[") + 1, -1));
        }
    }

    [Serializable]
    public class LogarithmConfront : ICloneable
    {
        private ConfrontVar v1 = null;
        private ConfrontVar v2 = null;

        public ConfrontVar Var1 { get => v1; set => v1 = value; }
        public ConfrontVar Var2 { get => v2; set => v2 = value; }
        public LogarithmAritmeticOperator Operator { get; set; }

        public LogarithmConfront() { }

        public LogarithmConfront(ConfrontVar var1, ConfrontVar var2, LogarithmAritmeticOperator op)
        {
            this.Var1 = var1;
            this.Var2 = var2;
            this.Operator = op;
        }

        public override string ToString()
        {
            return Var1.ToString() + " " + Enum.GetName(typeof(LogarithmAritmeticOperator), Operator) + " " + Var2.ToString();
        }

        public object Clone()
        {
            var clone = (LogarithmConfront)this.MemberwiseClone();
            var formatter = new BinaryFormatter();
            if (Var1 != null)
            {
                using (var stream = new MemoryStream())
                {
                    formatter.Serialize(stream, Var1);
                    stream.Seek(0, SeekOrigin.Begin);
                    clone.Var1 = (ConfrontVar)formatter.Deserialize(stream);
                }
            }
            if (Var2 != null)
            {
                formatter = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    formatter.Serialize(stream, Var2);
                    stream.Seek(0, SeekOrigin.Begin);
                    clone.Var2 = (ConfrontVar)formatter.Deserialize(stream);
                }
            }
            return clone;
        }
    }

    [Serializable]
    public class RecordingDetails : ICloneable
    {

        public enum RecordingType
        {
            Continuous,
            Confront
        }

        private int refTime = 5000;
        private int conTime = 30000;
        private int vCount = 1;
        private LogarithmConfront rc = null;
        private LogarithmConfront fc = null;
        private RecordingType type = RecordingType.Continuous;

        public LogarithmConfront RecordingConfront { get => rc; set => rc = value; }
        public LogarithmConfront FinishConfront { get => fc; set => fc = value; }
        public int CheckTime { get => refTime; set { refTime = (value < 1000) ? 1000 : value; } }
        public int ConfrontsValidationCounter { get => vCount; set { vCount = (value < 1) ? 1 : value; } }
        public RecordingType Type { get => type; set => type = value; }
        public int ContinuousTime { get => conTime; set => conTime = value; }

        public object Clone()
        {
            var clone = (RecordingDetails)this.MemberwiseClone();
            return clone;
        }

    }

    [Serializable]
    public class DataItem
    {
        string format = DataItemFormat.Empty.ToString();
        string address = "";
        string description = "";
        string unit = "";
        bool realt = true;
        bool logs = true;
        DataType type = DataType.AUTO;

        public string Description { get => description; set => description = value; }
        public string Address { get => address; set { if (!string.IsNullOrEmpty(value)) address = value; } }
        public string Format { get => format; set { if (!string.IsNullOrEmpty(value)) format = value; } }
        public string Unit { get => unit; set => unit = value; }
        public DataType Type { get => type; set => type = value; }

        [JsonIgnore]
        public bool Realtime { get => realt; set => realt = value; }
        [JsonIgnore]
        public bool Logs { get => logs; set => logs = value; }

        public List<bool> Attributes
        {
            get => new List<bool>() { realt, logs };
            set
            {
                realt = value[2];
                logs = value[3];
            }
        }

        public DataItem() { }

        public DataItem(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.Exception("parameters not null or empty");
            this.address = address;
        }

        public DataItem(string address, string format)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(format))
                throw new System.Exception("parameters not null or empty");
            this.address = address;
            this.format = format;
        }

        public DataItem(string address, string format, string description)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(format))
                throw new System.Exception("parameters not null or empty");
            this.address = address;
            this.format = format;
            this.description = description;
        }

        public DataItemAttribute GetAttributes()
        {
            DataItemAttribute outs = 0;
            if (realt)
                outs = outs | DataItemAttribute.Realtime;
            if (logs)
                outs = outs | DataItemAttribute.Logs;
            return outs;
        }
    }

    [Serializable]
    public class DataGroup : ICloneable
    {
        private List<DataItem> items = new List<DataItem>();
        private DataGroupMode mode = DataGroupMode.Read;

        public string Name { get; set; }
        public List<DataItem> Items
        {
            get => items;
            set => items = value;
        }
        public DataGroupMode Mode { get => mode; set => mode = value; }

        public object Clone()
        {
            var clone = (DataGroup)this.MemberwiseClone();
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, this.Items);
                stream.Seek(0, SeekOrigin.Begin);
                clone.Items = (List<DataItem>)formatter.Deserialize(stream);
            }
            return clone;
        }


    }

    public class Logging
    {
        private LogLevel ll = new LogLevel();
        public LogLevel LogLevel { get => ll; set => ll = value; }
    }

    public class LogLevel
    {
        public string Default = "Information";
        public string Microsoft = "Warning";
        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftH = "Information";
    }

}