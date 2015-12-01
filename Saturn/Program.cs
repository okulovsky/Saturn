using Saturn.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    class Program
    {
        public static void Main()
        {
            World w = new World
            {
                AccessPointsAddresses = { "ap1", "ap2", "ap3" }
            };
            var scenarios = new List<Scenario>
            {
                new WalkingScenario("us1",1,2,new GaussParameters(0.1,0.1)),
                new WalkingScenario("us2",0.5,2.5,new GaussParameters(0.2,0.2))
            };
            var dispatcher = new Dispatcher(w, scenarios);
            dispatcher.Run(4);
            Console.ReadKey();
        }
    }
}