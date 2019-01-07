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

        public void RemoveDatabase()
        {
            db = null;
        }

        public bool AddMachine(FileConfigMachineType type, FileConfigProtocol protocol, string name, string descr, string address, string port, string image)
        {
            if (type is FileConfigMachineType && protocol is FileConfigProtocol && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(image))
            {
                var protExist = protocols.Exists(x => x.Name == protocol.Name);
                var typeExist = machineTypes.Exists(x => x.Name == type.Name);
                if (protExist && typeExist)
                {
                    var m = new FileConfigMachine
                    {
                        Id = machines.Count,
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

        public bool RemoveMachine(string name)
        {
            foreach (var m in machines)
            {
                if (m.ReferenceName == name)
                {
                    machines.Remove(m);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveMachine(int index)
        {
            if (index < machines.Count)
            {
                machines.RemoveAt(index);
                return true;
            }
            return false;
        }

        public FileConfigMachineType GetMachineType(string name)
        {
            foreach(var t in machineTypes)
            {
                if (t.Name == name)
                {
                    return t;
                }
            }
            return null;
        }

        public FileConfigMachineType GetMachineType(int index)
        {
            return (index < machineTypes.Count) ? machineTypes[index] : null;
        }

        public FileConfigProtocol GetProtocol(string name)
        {
            foreach (var p in protocols)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return null;
        }

        public FileConfigProtocol GetProtocol(int index)
        {
            return (index < protocols.Count) ? protocols[index] : null;
        }

        public FileConfigMachine GetMachine(string name)
        {
            foreach (var m in machines)
            {
                if (m.ReferenceName == name)
                {
                    return m;
                }
            }
            return null;
        }

        public FileConfigMachine GetMachine(int index)
        {
            return (index < machines.Count) ? machines[index] : null;
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
        public Dictionary<string, List<FileConfigDataAddressToReadItem>> DatasAddressToRead { get; set; }
    }

    public class FileConfigProtocol
    {
        public string Name { get; set; }
    }

    public class FileConfigMachineType
    {
        public string Name { get; set; }
    }

    public class FileConfigDataAddressToReadItem
    {
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
