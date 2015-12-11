using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    [XmlSerializer]
    
    public class DirectMessageFrame
    {
        public  string Receiver;
        [EntryField]
        public object Message;
        public DirectMessageFrame(string receiver, object message)
        {
            this.Receiver = receiver;
            this.Message = message;
        }

        private DirectMessageFrame() { }
    }
}
