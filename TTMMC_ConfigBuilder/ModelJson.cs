using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TTMMC_ConfigBuilder
{
    public class ModelJson
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, MachineJson> Machines { get; set; }
    }

    public class MachineJson
    {
        private int refTime = 500;

        public int Id { get; set; }
        public string Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Protocol { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int RefreshRealTimeDatasRead { get => refTime; set { refTime = (value < 25) ? 25 : value; } }
        public int ModalityLogCheck { get; set; }
        public int ValueModalityLogCheck { get; set; }
        public List<DataGroup> DatasRead { get; set; }
        public List<DataGroup> DatasWrite { get; set; }
    }

    [Serializable]
    public class DataItem
    {
        string format = DataItemFormat.Empty.ToString();
        string address = "";
        string description = "";
        string unit = "";

        public string Description { get => description; set => description = value; }
        public string Address { get => address; set { if (!string.IsNullOrEmpty(value)) address = value; } }
        public string Format { get => format; set { if (!string.IsNullOrEmpty(value)) format = value; } }
        public string Unit { get => unit; set => unit = value; }
        public bool IsReferenceKey { get; set; }
        public bool IsFinishKey { get; set; }
        public bool Ignore { get; set; }

        public DataItem() { }

        public DataItem(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.Exception("parameteres not null or empty");
            Address = address;
        }

        public DataItem(string address, string format)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(format))
                throw new System.Exception("parameteres not null or empty");
            this.address = address;
            this.format = format;
        }

        public DataItem(string address, string format, string description)
        {
            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(format))
                throw new System.Exception("parameteres not null or empty");
            this.address = address;
            this.format = format;
            this.description = description;
        }
    }

    public class DataGroup : ICloneable
    {
        private List<DataItem> items = new List<DataItem>();

        public string Name { get; set; }
        public List<DataItem> Items { get => items; set => items = value; }

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
