using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    [JsonSerializer]
    public class DirectMessageFrame
    {
        public readonly string Receiver;
        [EntryField]
        public readonly object Message;
        public DirectMessageFrame(string receiver, object message)
        {
            this.Receiver = receiver;
            this.Message = message;
        }
    }
}
