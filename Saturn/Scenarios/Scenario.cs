using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Scenarios
{
    public abstract class Scenario
    {
        public readonly double BeginningTime;

        public Scenario(double beginningTime)
        {
            BeginningTime = beginningTime;
        }

        public abstract IEnumerable<ScenarioAction> GetActions(World world);

        public static Random Random = new Random(1);
    }
}
