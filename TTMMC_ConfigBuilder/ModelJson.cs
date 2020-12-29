using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

    public enum DataGroupMode
    {
        Read = 1,
        Write = 2,
        ReadAndWrite = 4
    }

    public enum DataType
    {
        AUTO,
        INT,
        UINT,
        DINT,
        UDINT,
        REAL,
        LREAL,
        STRING
    }

    public class ModelJson
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, Machine> Machines { get; set; }
    }

    public class Machine
    {
        private int refTime = 500;
        private int shareEngine = -1;
        private List<DataGroup> datas = new List<DataGroup>();
        private RecordingDetails recDetails = new RecordingDetails();

        public int Id { get; set; }
        public MachineType Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public int ShareEngine { get => shareEngine; set => shareEngine = value; }
        public string Protocol { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string RootPath { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int RefreshRealTimeDatasRead { get => refTime; set { refTime = (value < 25) ? 25 : value; } }
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
        private int refTime = 5000;
        private int vCount = 1;
        private LogarithmConfront rc = null;
        private LogarithmConfront fc = null;

        public LogarithmConfront RecordingConfront { get => rc; set => rc = value; }
        public LogarithmConfront FinishConfront { get => fc; set => fc = value; }
        public int CheckTime { get => refTime; set { refTime = (value < 1000) ? 1000 : value; } }
        public int ConfrontsValidationCounter { get => vCount; set { vCount = (value < 1) ? 1 : value; } }

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
        bool ignoreR = false;
        bool ignoreL = false;
        List<bool> attribs = new List<bool>();
        DataType type = DataType.AUTO;

        public string Description { get => description; set => description = value; }
        public string Address { get => address; set { if (!string.IsNullOrEmpty(value)) address = value; } }
        public string Format { get => format; set { if (!string.IsNullOrEmpty(value)) format = value; } }
        public string Unit { get => unit; set => unit = value; }
        public DataType Type { get => type; set => type = value; }

        [JsonIgnore]
        public bool IgnoreRealtime { get => ignoreR; set { ignoreR = value; attribs[0] = value; } }
        [JsonIgnore]
        public bool IgnoreInLogs { get => ignoreL; set { ignoreL = value; attribs[1] = value; } }

        public List<bool> Attributes { get => attribs; }

        public DataItem() 
        {
            assignAttribs();
        }

        public DataItem(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.Exception("parameters not null or empty");
            Address = address;
            assignAttribs();
        }

        public DataItem(string address, string format)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(format))
                throw new System.Exception("parameters not null or empty");
            this.address = address;
            this.format = format;
            assignAttribs();
        }

        public DataItem(string address, string format, string description)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(format))
                throw new System.Exception("parameters not null or empty");
            this.address = address;
            this.format = format;
            this.description = description;
            assignAttribs();
        }

        private void assignAttribs()
        {
            attribs.Add(ignoreR);
            attribs.Add(ignoreL);
        }
    }

    public class DataGroup : ICloneable
    {
        private List<DataItem> items = new List<DataItem>();
        private DataGroupMode mode = DataGroupMode.Read;

        public string Name { get; set; }
        public List<DataItem> Items { get => items; set => items = value; }
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
}
