using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Scenarios
{
    public class ConversationScenario : Scenario
    {
        string user1;
        string user2;
        GaussParameters intensity;
        double length;

        public ConversationScenario(double beginning, double length, string user1, string user2, GaussParameters intensity)
         : base (beginning)
        {
            this.user1 = user1;
            this.user2 = user2;
            this.length = length;
            this.intensity = intensity;
        }

        public override IEnumerable<ScenarioAction> GetActions(World world)
        {
            double time = 0;
            bool swap=false;
            while(time<length)
            {
                var dtime = Random.PositiveGauss(intensity);
                yield return Actions.DirectMessage(
                    swap ? user1 : user2,
                    swap ? user2 : user1,
                    "bla-bla-bla").WithDelay(dtime);
                time += dtime;
                swap = !swap;
            }
        }

    }
}
