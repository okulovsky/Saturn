using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	public class DirectMessage : IMessage
	{
		public string From { get; set; }
		public string To { get; set; }
		public object Message { get; set; }
		public double Delay { get; set; }

		public IEnumerable<double> PerformActions(World w)
		{
			while (!w.IsConnected(From) || !w.IsConnected(To))
				yield return 1;
			w.Message(From, new DirectMessageFrame(To, Message));
			yield return Delay;
		}
	}
}
