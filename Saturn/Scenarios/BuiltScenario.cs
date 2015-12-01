using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Scenarios
{
    class BuiltScenario : Scenario
    {
        List<ScenarioAction> actions;

        public BuiltScenario(double startTime, List<ScenarioAction> actions)
        : base(startTime)
        {
            this.actions = actions;
        }
        public override IEnumerable<ScenarioAction> GetActions(World world)
        {
            return actions;
        }
    }
}
