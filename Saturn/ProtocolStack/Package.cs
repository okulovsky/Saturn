using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    public interface IPackage { }

    public class Package<T> : IPackage
    {
        public readonly double Timestamp;
        public readonly string Sender;
        public readonly string AccessPoint;
        public readonly T Message;

        public Package(double timestamp, string sender, string accessPoint, T message)
        {
            Timestamp = timestamp;
            Sender = sender;
            AccessPoint = accessPoint;
            Message = message;
        }
    }
}