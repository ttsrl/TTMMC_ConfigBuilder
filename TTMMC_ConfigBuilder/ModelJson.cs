﻿using System.Collections.Generic;
using static TTMMC_ConfigBuilder.Form1;

namespace TTMMC_ConfigBuilder
{
    public class ModelJson
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, MachineJSON> Machines { get; set; }
    }

    public class MachineJSON
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public string Protocol { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Image { get; set; }
        public Dictionary<string, Dictionary<string, DataAddressItem>> DatasAddressToRead { get; set; }
    }

    public class DataAddressItem
    {
        private string dataType { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string DataType { get => dataType; set => dataType = value?.ToLower(); }

        public DataAddressItem(string address, string description, DataTypes datatype)
        {
            Address = address;
            Description = description;
            DataType = datatype.ToString();
        }
    }
}
