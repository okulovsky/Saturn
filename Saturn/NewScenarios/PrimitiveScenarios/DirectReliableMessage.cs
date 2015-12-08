using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	public class DirectReliableMessage : IScenario
	{
		string from;
		string to;
		object message;
		double delay;

		public DirectReliableMessage(string from, string to, object message, double delay)
		{
			this.from = from;
			this.to = to;
			this.message = message;
			this.delay = delay;
		}

		public IEnumerable<double> PerformActions(World w)
		{
			while (!w.IsConnected(from) || !w.IsConnected(to))
				yield return 1;
			w.Message(from, new DirectMessageFrame(to, message));
			yield return delay;
		}
	}
}
