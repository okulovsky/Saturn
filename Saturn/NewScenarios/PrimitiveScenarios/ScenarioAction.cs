using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
    public class ScenarioAction
    {
        public readonly double Delay;
        public readonly Action<World> Action;
        public ScenarioAction(double delay, Action<World> action)
        {
            Delay = delay;
            Action = action;
        }
    }

}
