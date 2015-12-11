using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Environment
{
    public static class Connections
    {
        public static ConnectionGraph CreateUniformConnections(IEnumerable<string> strs, int connectionPerUser)
        {
            var s = strs.ToList();
            var graph = new ConnectionGraph();
            for (int i=0;i<s.Count-1;i++)
            {
                for (int j=0;j<connectionPerUser;j++)
                {
                    var n = Rnd.NextInt(i + 1, s.Count);
                    if (graph.IsConnected(s[i], s[n]))
                        continue;
                    graph.Add(s[i], s[n]);
                }
            }
            return graph;
        }
    }
}
