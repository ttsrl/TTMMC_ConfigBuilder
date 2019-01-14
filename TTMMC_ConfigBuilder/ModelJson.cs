using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMMC_ConfigBuilder
{
    public class ModelJson
    {
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public List<MachineJSON> Machines { get; set; }
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
        public Dictionary<string, List<DataAddressToReadItem>> DatasAddressToRead { get; set; }
    }

    public class DataAddressToReadItem
    {
        private string dataType { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string DataType { get => dataType; set => dataType = value?.ToLower(); }
    }
}
