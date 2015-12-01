using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public static class Actions
    {
        public static Action<World> Connect(string user, string accessPoint)
        {
            return world => 
                {
                    world.UserToAccessPoint[user] = accessPoint;
                    world.Message(user, "Connected");
                };
            
        }

        public static Action<World> DirectMessage(string from, string to, object message)
        {
            return world =>
                {
                    if (world.IsConnected(from) && world.IsConnected(to))
                        world.Message(from, new DirectMessage(to, message));
                };
        }
    }
}
