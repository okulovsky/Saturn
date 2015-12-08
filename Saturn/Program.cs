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
                Users = Enumerable.Range(0,3).Select(z=>"user"+z).ToList()
            };
            world.PackageSent += new MessagePrinter().Log;

			var scenarios = new List<IScenario>();

			foreach (var e in world.Users)
				scenarios.Add(new RandomWalking(e, () => 1000000));

			scenarios.Add(new Chat("user1", "user2", 5, () => 3, () => "A", ()=>new DirectMessage()));

			scenarios.Add(new ConcatScenario(new Sleep(10),
				new Chat("user1", "user2", 5, () => 3, () => "B", () => new MediatedMessage<MediatedMessageFrame> { Mediator = "user0" })
				));


            var dispatcher=new Dispatcher(world, scenarios);
            dispatcher.Run(100);
            Console.ReadKey();

			//идеи сценариев:
			// идея с отравлением, сценарий - посещение ресторана. 
			// 
        }
    }
}