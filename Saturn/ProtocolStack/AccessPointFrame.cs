using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    [EncodingBinaryFrame(typeof(JsonSerializer))]
    public class AccessPointFrame
    {
        public readonly double Timestamp;
        public readonly string Sender;
        public readonly string AccessPoint;
        [EntryField]
        public readonly object Entry;
        public AccessPointFrame(double timestamp, string sender, string accessPoint, object entry)
        {
            Timestamp = timestamp;
            Sender = sender;
            AccessPoint = accessPoint;
            Entry = entry;
        }
    }

  
}