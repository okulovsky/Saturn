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
        readonly GaussParameters TimeInOneNetwork;
        readonly string UserId;

        public WalkingScenario(string userId, double arrivalTime, double departureTime, GaussParameters timeInOneNetwork)
        : base(arrivalTime)
        {
            DepartureTime = departureTime;
            TimeInOneNetwork = timeInOneNetwork;
            UserId=userId;
        }

        public override IEnumerable<ScenarioAction> GetActions(World world)
        {
            while(true)
            {
                var ap=Random.Element(world.AccessPointsAddresses);
                yield return Actions.Connect(UserId, ap).WithDelay(Random.PositiveGauss(TimeInOneNetwork));
            }
        }
    }
}
