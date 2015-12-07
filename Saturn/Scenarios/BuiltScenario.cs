using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Scenarios
{
    class BuiltScenario : Scenario
    {
        List<Tuple<Action<World>, Func<double>>> actions;

        public BuiltScenario(double startTime, List<Tuple<Action<World>, Func<double>>> actions)
        : base(startTime)
        {
            this.actions = actions;
        }
        public override IEnumerable<ScenarioAction> GetActions(World world)
        {
            foreach (var e in actions)
                yield return new ScenarioAction(e.Item2(), e.Item1);
        }
    }
}
