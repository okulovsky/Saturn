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
        public List<string> AccessPointsAddresses = new List<string>();
        public List<string> Users = new List<string>();

        public event Action<AccessPointFrame> PackageSent;
        
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


        void OnPackageSent(AccessPointFrame package)
        {
            if (PackageSent != null) PackageSent(package);
        }

        public void Message<T>(string from, T message)
        {
            OnPackageSent(new AccessPointFrame(CurrentTime, from, GetAccessPoint(from), message));
        }
    }
}
