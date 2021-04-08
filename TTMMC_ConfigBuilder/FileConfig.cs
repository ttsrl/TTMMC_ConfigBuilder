using System;
using System.Collections.Generic;
using System.Linq;

namespace TTMMC_ConfigBuilder
{

    public class FileConfig
    {
        private List<string> protocols = new List<string>();
        private List<string> groups = new List<string>();
        private List<Machine> machines = new List<Machine>();
        private Dictionary<string, DB> dbs = new Dictionary<string, DB>();
        private string _name;
        private List<VpnItem> vpn = new List<VpnItem>();

        public string Name { get => _name; set => _name = value.Replace(".json", ""); }
        public List<string> Protocols { get => protocols; }
        public List<string> Groups { get => groups; }
        public List<Machine> Machines { get => machines; }
        public Dictionary<string, DB> DBs { get => dbs; }
        public List<VpnItem> Vpn { get => vpn; set => vpn = value; }


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
            var db_ = new DB()
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
                var db_ = new DB();
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

        public bool AddMachine(Machine machine)
        {
            if (string.IsNullOrEmpty(machine.Group) || ( machine.ShareEngine == -1 && (string.IsNullOrEmpty(machine.Protocol) || string.IsNullOrEmpty(machine.Address) || string.IsNullOrEmpty(machine.Port))))
                return false;
            var gr = groups.Where(g => g == (machine.Group ?? "")).FirstOrDefault();
            if (gr == null)
            {
                AddGroup(machine.Group);
                gr = GetGroup(machine.Group);
            }
            var pr = protocols.Where(p => p == machine.Protocol).FirstOrDefault();
            if (pr == null)
            {
                AddProtocol(machine.Protocol);
                pr = GetProtocol(machine.Protocol);
            }
            if (gr != null && pr != null)
            {
                machines.Add(machine);
                return true;
            }
            return false;
        }

        public bool MoveUpMachine(string name)
        {
            try
            {
                Machine ma = GetMachine(name);
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
                Machine ma = GetMachine(name);
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

        public Machine GetMachine(string name)
        {
            foreach (var m in machines)
            {
                if (m.ReferenceName == name)
                    return m;
            }
            return null;
        }

        public Machine GetMachine(int index)
        {
            return (index < machines.Count) ? machines[index] : null;
        }

        public Machine GetMachineById(int id)
        {
            var mt = machines.Where(m => m.Id == id).FirstOrDefault();
            return mt;
        }

        public DB GetDB(string name)
        {
            foreach (var m in dbs)
            {
                if (m.Key == name)
                    return m.Value;
            }
            return null;
        }

        public DB GetDB(int index)
        {
            var k = dbs.Keys.ToList()[index];
            return (string.IsNullOrEmpty(k)) ? null : dbs[k];
        }

    }

}
