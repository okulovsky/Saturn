using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	class MediatedMessage<T> : IMessage
		where T : MediatedMessageFrame, new()
	{
		public string From { get; set; }
		public string To { get; set; }
		public object Message { get; set; }
		public double Delay { get; set; }

		public string Mediator { get; set; }

	 public IEnumerable<double> PerformActions(World w)
		{
			var sc=new ConcatScenario(
				new DirectMessage().Prepare(From,Mediator,Message,Delay),
				new DirectMessage().Prepare(Mediator,To, new T { Sender=From, Entry=Message },Delay));
			return sc.PerformActions(w);
		}
	}
}
