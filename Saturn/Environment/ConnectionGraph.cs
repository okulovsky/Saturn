using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Environment
{
    public class ConnectionGraph
    {
        public readonly Dictionary<string,HashSet<string>> Connections=new Dictionary<string,HashSet<string>>();
        
        void AddInternal(string a, string b)
        {
            if (!Connections.ContainsKey(a))
                Connections[a] = new HashSet<string>();
            Connections[a].Add(b);
        }
        public void Add(string a, string b)
        {
            AddInternal(a, b);
            AddInternal(b, a);
        }

        public bool IsConnected(string a, string b)
        {
            if (a.CompareTo(b) > 0) return IsConnected(b, a);
            if (!Connections.ContainsKey(a)) return false;
            if (!Connections[a].Contains(b)) return false;
            return true;
        }
        
    }
}
