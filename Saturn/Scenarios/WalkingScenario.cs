using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Scenarios
{
    public class WalkingScenario : Scenario
    {
        readonly double DepartureTime;
        readonly string UserId;
        readonly double MinTime;
        readonly double MaxTime;

        public WalkingScenario(string userId, double arrivalTime, double departureTime, double minTimeInNetwork, double maxTimeInNetwork)
        : base(arrivalTime)
        {
            DepartureTime = departureTime;
                MinTime=minTimeInNetwork;
            MaxTime=maxTimeInNetwork;
            UserId=userId;
        }

        public override IEnumerable<ScenarioAction> GetActions(World world)
        {
            while(true)
            {
                var ap=Random.Element(world.AccessPointsAddresses);
                yield return Actions.Connect(UserId, ap).WithDelay(Rnd.NextDouble(MinTime, MaxTime));
            }
        }
    }
}
