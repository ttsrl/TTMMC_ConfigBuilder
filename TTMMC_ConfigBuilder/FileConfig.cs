using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMMC_ConfigBuilder
{
    public class FileConfig
    {
        private List<FileConfigProtocol> protocols = new List<FileConfigProtocol>();
        private List<FileConfigMachineType> machineTypes = new List<FileConfigMachineType>();
        private List<FileConfigMachine> machines = new List<FileConfigMachine>();
        private FileConfigDB db;

        public string Name { get; set; }
        public List<FileConfigProtocol> Protocols { get => protocols; }
        public List<FileConfigMachineType> MachineTypes { get => machineTypes; }
        public List<FileConfigMachine> Machines { get => machines; }
        public FileConfigDB DB { get => db; }

        public FileConfig(string name)
        {
            Name = name;
        }

        public void AddProtocol(string name)
        {
            var protExist = protocols.Exists(x => x.Name == name);
            if (!protExist)
                protocols.Add(new FileConfigProtocol { Name = name });
        }

        public void AddMachineType(string name)
        {
            var typeExist = machineTypes.Exists(x => x.Name == name);
            if (!typeExist)
                machineTypes.Add(new FileConfigMachineType { Name = name });
        }

        public void AddDatabase(string ip, string database, string username, string password, bool requestSecurityInfo)
        {
            var db_ = new FileConfigDB()
            {
                IP = ip,
                Database = database,
                Password = password,
                Username = username,
                PersisteSecurityInfo = requestSecurityInfo
            };
            db = db_;
        }

        public bool AddMachine(int id, FileConfigMachineType type, FileConfigProtocol protocol, string name, string descr, string address, string port, string image)
        {
            if (id > 0 && type is FileConfigMachineType && protocol is FileConfigProtocol && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(image))
            {
                var protExist = protocols.Exists(x => x.Name == protocol.Name);
                var typeExist = machineTypes.Exists(x => x.Name == type.Name);
                if (protExist && typeExist)
                {
                    var m = new FileConfigMachine
                    {
                        Id = id,
                        Type = type,
                        Protocol = protocol,
                        Address = address,
                        Description = descr,
                        Port = port,
                        ReferenceName = name,
                        Image = image
                    };
                    machines.Add(m);
                    return true;
                }
            }
            return false;
        }

    }

    public class FileConfigDB
    {
        public string IP { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool PersisteSecurityInfo { get; set; }
    }

    public class FileConfigMachine
    {
        public int Id { get; set; }
        public FileConfigMachineType Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public FileConfigProtocol Protocol { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Image { get; set; }
    }

    public class FileConfigProtocol
    {
        public string Name { get; set; }
    }

    public class FileConfigMachineType
    {
        public string Name { get; set; }
    }
}
