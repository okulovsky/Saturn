using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Scenarios
{
    
    class ScenarioBuilder
    {
        public readonly ScenarioBuiderActionRequired actionRequired;
        public readonly ScenarioBuiderPauseRequired pauseRequired;
        double startTime;
        Action<World> lastAction;
        List<ScenarioAction> list=new List<ScenarioAction>();
        public ScenarioBuilder()
        {
            actionRequired = new ScenarioBuiderActionRequired(this);
            pauseRequired = new ScenarioBuiderPauseRequired(this);
        }
        public ScenarioBuiderActionRequired StartAt(double startTime)
        {
            this.startTime = startTime;
            return actionRequired;
        }
        public void SetLastAction(Action<World> action)
        {
            lastAction = action;
        }
        public void CompleteAction(double pause)
        {
            list.Add(new ScenarioAction(pause, lastAction));
            lastAction = null;
        }
        
        public static Random Random=new Random();
    }

    class ScenarioBuiderActionRequired
    {
        readonly ScenarioBuilder builder;
        public ScenarioBuiderActionRequired(ScenarioBuilder builder) { this.builder=builder; }

        public ScenarioBuiderPauseRequired Connect(string user, string accessPoint)
        {
            builder.SetLastAction(Actions.Connect(user,accessPoint));
            return builder.pauseRequired;
        }

        public ScenarioBuiderPauseRequired DirectMessage(string from, string to, object message)
        {
            builder.SetLastAction(Actions.DirectMessage(from,to, message));
            return builder.pauseRequired;
        }
    }

    class ScenarioBuiderPauseRequired
    {
        readonly ScenarioBuilder builder;
        public ScenarioBuiderPauseRequired(ScenarioBuilder builder) { this.builder = builder; }

        public ScenarioBuiderActionRequired UniformDelay(double minTime, double maxTime)
        {
            builder.CompleteAction(ScenarioBuilder.Random.NextDouble() * (maxTime - minTime) + minTime);
            return builder.actionRequired;
        }
    }



}
