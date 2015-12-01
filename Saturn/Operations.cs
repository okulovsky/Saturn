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
                    world.Message(user,accessPoint,"CONNECTED");
                };
            
        }
    }
}
