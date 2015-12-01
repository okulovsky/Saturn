using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    public class DirectMessage
    {
        public readonly string Receiver;
        public readonly string Message;
        public DirectMessage(string receiver, string message)
        {
            this.Receiver = receiver;
            this.Message = message;
        }
    }
}
