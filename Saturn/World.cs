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
        
        public string GetAccessPoint(string user)
        {
            if (!UserToAccessPoint.ContainsKey(user)) return null;
            return UserToAccessPoint[user];
        }
        
        public double CurrentTime { get; set; }



        public void Message(string from, string to, string message)
        {
            Console.WriteLine("Time:   " + CurrentTime);
            Console.WriteLine("From:   " + from);
            Console.WriteLine("AP:     " + GetAccessPoint(from));
            Console.WriteLine("To:     " + to);
            Console.WriteLine("Message:" + message);
            Console.WriteLine();
        }
    }
}
