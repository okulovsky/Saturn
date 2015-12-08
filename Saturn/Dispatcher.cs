using Saturn.NewScenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public class Dispatcher
    {
        List<IScenario> scenarios;
        World world;

        class ScenarioInstance
        {
            public IEnumerator<double> actions;
            public double nextActionTime;
        }

        public Dispatcher(World world, List<IScenario> scenarios)
        {
            this.world = world;
            this.scenarios = scenarios;
        }

        public void Run(double totalTime)
        {
			world.CurrentTime = 0;
            var queue = scenarios
				.Select(z => new ScenarioInstance { actions = z.PerformActions(world).GetEnumerator() })
				.ToList();
            while(world.CurrentTime<totalTime)
            {
                if (queue.Count == 0) break;
                var currentAction = queue.ArgMin(z => z.nextActionTime);
                world.CurrentTime = currentAction.nextActionTime;
				var alive = currentAction.actions.MoveNext();
				if (!alive)
				{
					queue.Remove(currentAction);
					continue;
				}
				currentAction.nextActionTime += currentAction.actions.Current;
            }
        }
    }
}
