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
        static List<Scenario> scenarios = new List<Scenario>();
        static World world;
        static Language Lang = new Language();
        static double TotalLength = 1000;

        static void CreateRandomTalks(int talksCount)
        {
            for (int i = 0; i < talksCount; i++)
            {
                var user1=Rnd.Element(world.Users);
                string user2 = "";
                do
                {
                    user2 = Rnd.Element(world.Users);
                } while (user2 != user1);

                var s = new ScenarioBuilder()
                        .StartAt(Rnd.NextDouble(0, TotalLength))
                        .DirectMessage(user1, user2, Lang.Text(100))
                        .UniformDelay(0.01, 1)
                        .DirectMessage(user2, user1, Lang.Text(100))
                        .UniformDelay(0.01, 1)
                        .Iterate(Rnd.NextInt(10, 100))
                        .Create();
                scenarios.Add(s);
            }
        }

        static void CreateRandomWalking()
        {
            foreach(var user in world.Users)
            {
                var s = new WalkingScenario(user, Rnd.NextDouble(0, 3), TotalLength, 20, 50);
                scenarios.Add(s);
            }
        }


        public static void Main()
        {
            world = new World
            {
                AccessPointsAddresses = Enumerable.Range(0,10).Select(z=>"ap"+z).ToList(),
                Users = Enumerable.Range(0,40).Select(z=>"user"+z).ToList()
            };
            world.PackageSent += new MessagePrinter().Log;

            CreateRandomWalking();
            CreateRandomTalks(100);

            var dispatcher=new Dispatcher(world, scenarios);
            dispatcher.Run(TotalLength);
            Console.ReadKey();
        }
    }
}