using System;
using System.Collections.Generic;
using System.Linq;

namespace TTMMC_ConfigBuilder
{
    public enum MachineType
    {
        Machinary,
        UtilityMachine
    }

    public class FileConfig
    {
        private List<FileConfigProtocol> protocols = new List<FileConfigProtocol>();
        private List<FileConfigMachine> machines = new List<FileConfigMachine>();
        private List<FileConfigGroup> groups = new List<FileConfigGroup>();
        private FileConfigDB db;
        private string _name;

        public string Name { get => _name; set => _name = value.Replace(".json", ""); }
        public List<FileConfigProtocol> Protocols { get => protocols; }
        public List<FileConfigGroup> Groups { get => groups; }
        public List<FileConfigMachine> Machines { get => machines; }
        public FileConfigDB DB { get => db; }

        public FileConfig(string name)
        {
            Name = name;
        }

        public void AddGroup(string name)
        {
            var groupExist = groups.Exists(x => x.Name == name);
            if (!groupExist)
                groups.Add(new FileConfigGroup { Name = name });
        }

        public void AddProtocol(string name)
        {
            var protExist = protocols.Exists(x => x.Name == name);
            if (!protExist)
                protocols.Add(new FileConfigProtocol { Name = name });
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

        public bool AddMachine(string type, string protocol, string group, string name, string descr, string address, string port, string image, string icon, Dictionary<string, List<DataAddressItem>> datasAddressToRead, Dictionary<string, List<DataAddressItem>> datasAddressToWrite, int modality, int valuex, int refreshReadTimer, string refKeyRead = "", string finKeyRead = "", string finKeyWrite = "")
        {
            if ( !string.IsNullOrEmpty(protocol) && !string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(address) )
            {
                var gr = groups.Where(g => g.Name == (group ?? "")).FirstOrDefault();
                if (gr == null)
                {
                    AddGroup(group);
                    gr = GetGroup(group);
                }
                var pr = protocols.Where(p => p.Name == protocol).FirstOrDefault();
                if (pr == null)
                {
                    AddProtocol(protocol);
                    pr = GetProtocol(protocol);
                }
                MachineType ty;
                var try_ = Enum.TryParse(type, out ty);
                if (gr != null && pr != null)
                {
                    var m = new FileConfigMachine
                    {
                        Id = machines.Count + 1,
                        Type = (!try_) ? null : (MachineType?)ty,
                        Protocol = pr,
                        Address = address,
                        Description = descr,
                        Group = gr,
                        Port = port,
                        ReferenceName = name,
                        Image = image,
                        Icon = icon,
                        MinRefreshReadDatasTime = refreshReadTimer,
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

        public bool MoveUpMachine(string name)
        {
            try
            {
                FileConfigMachine ma = GetMachine(name);
                if (ma == null)
                    return false;
                var indx = machines.IndexOf(ma);
                if (indx == 0)
                    return false;
                machines.Remove(ma);
                machines.Insert(indx - 1, ma);
                ma.Id = ma.Id - 1;
                machines[indx].Id = machines[indx].Id + 1;
                return true;
            }
            catch { return false; }
        }

        public bool MoveDownMachine(string name)
        {
            try
            {
                FileConfigMachine ma = GetMachine(name);
                if (ma == null)
                    return false;
                var indx = machines.IndexOf(ma);
                if (indx == machines.Count - 1)
                    return false;
                machines.Remove(ma);
                machines.Insert(indx + 1, ma);
                ma.Id = ma.Id + 1;
                machines[indx].Id = machines[indx].Id - 1;
                return true;
            }
            catch { return false; }
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

        public bool RemoveProtocol(string name)
        {
            try
            {
                var prot = GetProtocol(name);
                if (prot == null)
                    return false;
                foreach (var m in machines)
                {
                    if (m.Protocol.Name == name)
                        m.Protocol = null;
                }
                protocols.Remove(prot);
                return true;
            }
            catch { return false; }
        }

        public bool RemoveGroup(string name)
        {
            try
            {
                var prot = GetGroup(name);
                if (prot == null)
                    return false;
                foreach (var m in machines)
                {
                    if (m.Group.Name == name)
                        m.Group = null;
                }
                groups.Remove(prot);
                return true;
            }
            catch { return false; }
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

        public FileConfigGroup GetGroup(string name)
        {
            foreach (var p in groups)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return null;
        }

        public FileConfigGroup GetGroup(int index)
        {
            return (index < groups.Count) ? groups[index] : null;
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
        private int minRefreshTime = 500;

        public int Id { get; set; }
        public MachineType? Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public FileConfigProtocol Protocol { get; set; }
        public FileConfigGroup Group { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int MinRefreshReadDatasTime { get => minRefreshTime; set => minRefreshTime = value; }
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

    public class FileConfigGroup
    {
        public string Name { get; set; }
    }
}
