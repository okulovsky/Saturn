using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public class World
    {
        public readonly Dictionary<string, string> UserToAccessPoint = new Dictionary<string, string>();
        public readonly List<string> AccessPointsAddresses = new List<string>();
        public readonly List<IPackage> SentPackages = new List<IPackage>();
        
        
        public string GetAccessPoint(string user)
        {
            if (!UserToAccessPoint.ContainsKey(user)) return null;
            return UserToAccessPoint[user];
        }

        public bool IsConnected(string user)
        {
            return GetAccessPoint(user) != null;
        }
        
        public double CurrentTime { get; set; }



        public void Message<T>(string from, T message)
        {
            SentPackages.Add(new Package<T>(CurrentTime, from, GetAccessPoint(from), message));
        }
    }
}
