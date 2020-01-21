using Newtonsoft.Json;
using System.Collections.Generic;
using static TTMMC_ConfigBuilder.Form1;
using static TTMMC_ConfigBuilder.inputKey;

namespace TTMMC_ConfigBuilder
{
    public class ModelJson
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, MachineJSON> Machines { get; set; }
    }

    public class MachineJSON
    {
        private string _referenceKeyR = "";
        private string _finishKeyR = "";
        private string _finishKeyW = "";
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
        public int RefreshRealTimeDatasRead { get => refTime; set { refTime = (value < 10) ? 10 : value; } }
        public int ModalityLogCheck { get; set; }
        public int ValueModalityLogCheck { get; set; }
        public string ReferenceKeyRead { get => _referenceKeyR; set => _referenceKeyR = value; }
        public string FinishKeyRead { get => _finishKeyR; set => _finishKeyR = value; }
        public string FinishKeyWrite { get => _finishKeyW; set => _finishKeyW = value; }
        public Dictionary<string, Dictionary<string, DataAddressItem>> DatasAddressToRead { get; set; }
        public Dictionary<string, Dictionary<string, DataAddressItem>> DatasAddressToWrite { get; set; }
    }

    public class DataAddressItem
    {
        private string dataType { get; set; }
        private int _scaling = 0;
        public string Description { get; set; }
        public string Address { get; set; }
        public string DataType { get => dataType; set => dataType = value?.ToLower(); }
        public int Scaling { get => _scaling; set => _scaling = value; }

        public DataAddressItem(string address, string description, DataTypes datatype, int scaling)
        {
            Address = address;
            Description = description;
            DataType = datatype.ToString();
            Scaling = scaling;
        }
    }
}
