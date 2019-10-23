using System;
using System.Collections.Generic;

namespace TTMMC_ConfigBuilder
{
    public class FileConfig
    {
        private List<FileConfigProtocol> protocols = new List<FileConfigProtocol>();
        private List<FileConfigMachineType> machineTypes = new List<FileConfigMachineType>();
        private List<FileConfigMachine> machines = new List<FileConfigMachine>();
        private FileConfigDB db;
        private string _name;

        public string Name { get => _name; set => _name = value.Replace(".json", ""); }
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

        public void AddDatabase(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                var db_ = new FileConfigDB();
                char[] char1 = new char[] { ';' };
                char[] char2 = new char[] { '=' };
                var split = connectionString.Split(char1);
                foreach (var str in split)
                {
                    var val = str.Split(char2);
                    if (val[0] == "Data Source")
                    {
                        db_.IP = val[1];
                    }
                    else if (val [0] == "Initial Catalog")
                    {
                        db_.Database = val[1];
                    }
                    else if (val[0] == "Persist Security Info")
                    {
                        db_.PersisteSecurityInfo = Boolean.Parse(val[1]);
                    }
                    else if (val[0] == "User ID")
                    {
                        db_.Username = val[1];
                    }
                    else if (val[0] == "Password")
                    {
                        db_.Password = val[1];
                    }
                }
                if (!string.IsNullOrEmpty(db_.IP) && !string.IsNullOrEmpty(db_.Database) && !string.IsNullOrEmpty(db_.Username) && !string.IsNullOrEmpty(db_.Password))
                {
                    db = db_;
                }
            }
        }

        public void RemoveDatabase()
        {
            db = null;
        }

        public bool AddMachine(FileConfigMachineType type, FileConfigProtocol protocol, string name, string descr, string address, string port, string image, Dictionary<string, List<DataAddressItem>> datasAddressToRead, Dictionary<string, List<DataAddressItem>> datasAddressToWrite, int modality, int valuex, string refKeyRead = "", string finKeyRead = "", string finKeyWrite = "")
        {
            if (type is FileConfigMachineType && protocol is FileConfigProtocol && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(address) )
            {
                var protExist = protocols.Exists(x => x.Name == protocol.Name);
                var typeExist = machineTypes.Exists(x => x.Name == type.Name);
                if (protExist && typeExist)
                {
                    var m = new FileConfigMachine
                    {
                        Id = machines.Count + 1,
                        Type = type,
                        Protocol = protocol,
                        Address = address,
                        Description = descr,
                        Port = port,
                        ReferenceName = name,
                        Image = image,
                        ModalityLogCheck = modality,
                        ValueModalityLogCheck = valuex,
                        ReferenceKeyRead = refKeyRead,
                        FinishKeyRead = finKeyRead,
                        FinishKeyWrite = finKeyWrite,
                        DatasAddressToRead = datasAddressToRead ?? new Dictionary<string, List<DataAddressItem>>(),
                        DatasAddressToWrite = datasAddressToWrite ?? new Dictionary<string, List<DataAddressItem>>()
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
        private string _referenceKeyR = "";
        private string _finishKeyR = "";
        private string _finishKeyW = "";

        public int Id { get; set; }
        public FileConfigMachineType Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public FileConfigProtocol Protocol { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Image { get; set; }
        public int ModalityLogCheck { get; set; }
        public int ValueModalityLogCheck { get; set; }
        public string ReferenceKeyRead { get => _referenceKeyR; set => _referenceKeyR = value; }
        public string FinishKeyRead { get => _finishKeyR; set => _finishKeyR = value; }
        public string FinishKeyWrite { get => _finishKeyW; set => _finishKeyW = value; }
        public Dictionary<string, List<DataAddressItem>> DatasAddressToRead { get; set; }
        public Dictionary<string, List<DataAddressItem>> DatasAddressToWrite { get; set; }
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
