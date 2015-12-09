using Saturn.Environment;
using Saturn.NewScenarios;
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
            var world = new World
            {
                AccessPointsAddresses = Enumerable.Range(0,10).Select(z=>"ap"+z).ToList(),
                Users = Enumerable.Range(0,20).Select(z=>"user"+string.Format("{0:D3}",z)).ToList()
            };
            world.PackageSent += new MessagePrinter().Log;

			var scenarios = new List<IScenario>();

			foreach (var e in world.Users)
				scenarios.Add(new RandomWalking(e, () => Rnd.NextDouble(10, 30)));

            var graph = Connections.CreateUniformConnections(world.Users, 5);
            var list = graph.Connections.OrderBy(z=>z.Key).ToDictionary(z => z.Key, z => z.Value.Count);



            var dispatcher=new Dispatcher(world, scenarios);
            dispatcher.Run(100);
            Console.ReadKey();
        }
    }
}