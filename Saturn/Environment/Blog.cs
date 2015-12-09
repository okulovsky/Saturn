using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Environment
{
    class BlogEntry
    {
        public string Sender;
        public double Timestamp;
        public object Message;
    }

    class Blog
    {
        Dictionary<string, List<BlogEntry>> entries = new Dictionary<string, List<BlogEntry>>();
        Dictionary<string, double> lastRetrieve = new Dictionary<string, double>();
        ConnectionGraph graph;
        public Blog(ConnectionGraph graph)
        {
            this.graph = graph;
        }
        public void Publish(string user, double timestamp, object message)
        {
            if (!entries.ContainsKey(user))
                entries[user] = new List<BlogEntry>();
            entries[user].Add(new BlogEntry { Timestamp = timestamp, Message = message, Sender=user });
        }
        public List<BlogEntry> Retrieve(string user, double timestamp)
        {
            double startTime = 0;
            if (lastRetrieve.ContainsKey(user)) startTime = lastRetrieve[user];
            lastRetrieve[user] = timestamp;
            return
                graph.Connections[user]
                .SelectMany(z => entries[z].Where(x => x.Timestamp > startTime))
                .OrderBy(z => z.Timestamp)
                .ToList();
        }
    }
}
