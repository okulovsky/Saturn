using Saturn.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public class Dispatcher
    {
        List<Scenario> scenarios;
        World world;

        class ScenarioInstance
        {
            public IEnumerator<ScenarioAction> actions;
            public double nextActionTime;
        }

        public Dispatcher(World world, List<Scenario> scenarios)
        {
            this.world = world;
            this.scenarios = scenarios;
        }

        public void Run(double totalTime)
        {
            var queue =
                scenarios.Select(z => new ScenarioInstance { actions = z.GetActions(world).GetEnumerator(), nextActionTime = z.BeginningTime })
                .Where(z => z.actions.MoveNext())
                .ToList();
            world.CurrentTime = queue.Min(z => z.nextActionTime);
            while(world.CurrentTime<totalTime)
            {
                if (queue.Count == 0) break;
                var currentAction = queue.ArgMin(z => z.nextActionTime);
                world.CurrentTime = currentAction.nextActionTime;
                currentAction.actions.Current.Action(world);
                currentAction.nextActionTime += currentAction.actions.Current.Delay;

                if (!currentAction.actions.MoveNext())
                    queue.Remove(currentAction);
            }
        }
    }
}
