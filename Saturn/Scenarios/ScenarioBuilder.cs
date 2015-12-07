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
        List<Tuple<Action<World>, Func<double>>> list = new List<Tuple<Action<World>, Func<double>>>();
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
        public void CompleteAction(Func<double> pause)
        {
            list.Add(Tuple.Create(lastAction, pause));
            lastAction = null;
        }
       
        public BuiltScenario Create()
        {
            return new BuiltScenario(startTime,list);
        }

        public void Iterate(int count)
        {
            int p = list.Count;
            for (int i = 0; i < count; i++)
                for (int j = 0; j < p; j++)
                    list.Add(list[j]);
        }
        
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

        public BuiltScenario Create()
        {
            return builder.Create();
        }

        public ScenarioBuiderActionRequired Iterate(int count)
        {
            builder.Iterate(count);
            return this;
        }
    }

    class ScenarioBuiderPauseRequired
    {
        readonly ScenarioBuilder builder;
        public ScenarioBuiderPauseRequired(ScenarioBuilder builder) { this.builder = builder; }

        public ScenarioBuiderActionRequired UniformDelay(double minTime, double maxTime)
        {
            builder.CompleteAction(()=>Scenario.Random.NextDouble(minTime,maxTime));
            return builder.actionRequired;
        }
    }



}
