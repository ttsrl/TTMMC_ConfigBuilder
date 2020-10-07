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
        private List<string> protocols = new List<string>();
        private List<string> groups = new List<string>();
        private List<FileConfigMachine> machines = new List<FileConfigMachine>();
        private Dictionary<string, FileConfigDB> dbs = new Dictionary<string, FileConfigDB>();
        private string _name;

        public string Name { get => _name; set => _name = value.Replace(".json", ""); }
        public List<string> Protocols { get => protocols; }
        public List<string> Groups { get => groups; }
        public List<FileConfigMachine> Machines { get => machines; }
        public Dictionary<string, FileConfigDB> DBs { get => dbs; }

        public FileConfig(string name)
        {
            Name = name;
        }

        public void AddGroup(string name)
        {
            if (!groups.Contains(name))
                groups.Add(name);
        }

        public void AddProtocol(string name)
        {
            if (!protocols.Contains(name))
                protocols.Add(name);
        }

        public void AddDatabase(string name, string ip, string database, string username, string password, bool requestSecurityInfo)
        {
            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return;
            var db_ = new FileConfigDB()
            {
                IP = ip,
                Database = database,
                Password = password,
                Username = username,
                PersistSecurityInfo = requestSecurityInfo
            };
            dbs.Add(name, db_);
        }

        public void AddDatabase(string name, string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                var db_ = new FileConfigDB();
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
                    dbs.Add(name, db_);
            }
        }

        public bool RemoveDatabase(string name)
        {
            return dbs.Remove(name);
        }

        public bool AddMachine(string type, string protocol, string group, string name, string descr, string address, string port, string image, string icon, List<DataGroup> datasRead, List<DataGroup> datasWrite, int modality, int valuex, int refreshReadTimer)
        {
            if ( !string.IsNullOrEmpty(protocol) && !string.IsNullOrEmpty(port) && !string.IsNullOrEmpty(address) )
            {
                var gr = groups.Where(g => g == (group ?? "")).FirstOrDefault();
                if (gr == null)
                {
                    AddGroup(group);
                    gr = GetGroup(group);
                }
                var pr = protocols.Where(p => p == protocol).FirstOrDefault();
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
                        DatasRead = datasRead ?? new List<DataGroup>(),
                        DatasWrite = datasWrite ?? new List<DataGroup>()
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
                    if (m.Protocol == name)
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
                    if (m.Group == name)
                        m.Group = null;
                }
                groups.Remove(prot);
                return true;
            }
            catch { return false; }
        }

        public bool ReplaceProtocol(string name, string newName)
        {
            try
            {
                var prot = GetProtocol(name);
                if (prot == null)
                    return false;
                foreach (var m in machines)
                {
                    if (m.Protocol == name)
                        m.Protocol = newName;
                }
                var indx = protocols.IndexOf(name);
                protocols[indx] = newName;
                return true;
            }
            catch { return false; }
        }

        public bool ReplaceGroup(string name, string newName)
        {
            try
            {
                var prot = GetGroup(name);
                if (prot == null)
                    return false;
                foreach (var m in machines)
                {
                    if (m.Group == name)
                        m.Group = newName;
                }
                var indx = groups.IndexOf(name);
                groups[indx] = newName;
                return true;
            }
            catch { return false; }
        }

        public string GetProtocol(string name)
        {
            foreach (var p in protocols)
            {
                if (p == name)
                    return p;
            }
            return null;
        }

        public string GetProtocol(int index)
        {
            return (index < protocols.Count) ? protocols[index] : null;
        }

        public string GetGroup(string name)
        {
            foreach (var p in groups)
            {
                if (p == name)
                    return p;
            }
            return null;
        }

        public string GetGroup(int index)
        {
            return (index < groups.Count) ? groups[index] : null;
        }

        public FileConfigMachine GetMachine(string name)
        {
            foreach (var m in machines)
            {
                if (m.ReferenceName == name)
                    return m;
            }
            return null;
        }

        public FileConfigMachine GetMachine(int index)
        {
            return (index < machines.Count) ? machines[index] : null;
        }

        public FileConfigDB GetDB(string name)
        {
            foreach (var m in dbs)
            {
                if (m.Key == name)
                    return m.Value;
            }
            return null;
        }

        public FileConfigDB GetDB(int index)
        {
            var k = dbs.Keys.ToList()[index];
            return (string.IsNullOrEmpty(k)) ? null : dbs[k];
        }
    }

    public class FileConfigDB
    {
        public string IP { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool PersistSecurityInfo { get; set; }
    }

    public class FileConfigMachine
    {
        private int minRefreshTime = 500;

        public int Id { get; set; }
        public MachineType? Type { get; set; }
        public string ReferenceName { get; set; }
        public string Description { get; set; }
        public string Protocol { get; set; }
        public string Group { get; set; }
        public string Address { get; set; }
        public string Port { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public int MinRefreshReadDatasTime { get => minRefreshTime; set => minRefreshTime = value; }
        public int ModalityLogCheck { get; set; }
        public int ValueModalityLogCheck { get; set; }
        public List<DataGroup> DatasRead { get; set; }
        public List<DataGroup> DatasWrite { get; set; }
    }

}
