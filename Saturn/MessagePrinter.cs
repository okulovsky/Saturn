using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public class MessagePrinter
    {
        public void Log(AccessPointFrame frame)
        {
            var serializer = typeof(AccessPointFrame).GetCustomAttributes(typeof(IBinarySerializer),false).First() as IBinarySerializer;
            Console.WriteLine(serializer.SerializeToString(frame));
        }
    }
}
