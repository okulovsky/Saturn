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

			var users = Enumerable.Range(0,100).Select(z=>"user"+string.Format("{0:D3}",z)).ToList();
			var xmlMessenger = "xmlMessenger";
			var jsonMessenger = "jsonMessenger";
			double totalTime = 1000;
			var messengers = new List<string> {xmlMessenger, jsonMessenger};
			var messengerFactory=new List<Func<IMessage>>
			{
				()=>new DirectMessage(),
				()=>new MediatedMessage<XmlMediatedMessageFrame>{Mediator=xmlMessenger},
				()=>new MediatedMessage<JsonMediatedMessageFrame>{ Mediator=jsonMessenger}
			};
			var lang = new Language();

            var world = new World
            {
                AccessPointsAddresses = Enumerable.Range(0,10).Select(z=>"ap"+z).ToList(),
                Users = users.Concat(messengers).ToList()
            };
            world.PackageSent += new MessagePrinter().Log;

			var scenarios = new List<IScenario>();

			foreach (var e in users)
				scenarios.Add(new RandomWalking(e, () => Rnd.NextDouble(10,30)));
			foreach (var e in messengers)
				scenarios.Add(new RandomWalking(e, () => totalTime * 2));
	
				
            var graph = Connections.CreateUniformConnections(users, 5);

			foreach (var u1 in graph.Connections.Keys)
				foreach (var u2 in graph.Connections[u1])
				{
					if (u1.CompareTo(u2) > 0) continue;
					var msn = Rnd.Element(messengerFactory);
					scenarios.Add(new Chat(
						Rnd.NextDouble(1, totalTime * 0.95),
						u1,
						u2,
						Rnd.NextInt(6, 10),
						() => Rnd.NextDouble(0.01, 1),
						() => lang.Text(140),
						msn
						));
				}

			//scenarios.Add(new MediatedMessage<XmlMediatedMessageFrame>() { Mediator = xmlMessenger }.Prepare(users[0], users[1], "test", 1));



            var dispatcher=new Dispatcher(world, scenarios);
            dispatcher.Run(100);
            Console.ReadKey();

			//идеи сценариев:
			// идея с отравлением, сценарий - посещение ресторана. 
			// 
        }
    }
}