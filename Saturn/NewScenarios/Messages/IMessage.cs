using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	public interface IMessage : IScenario
	{
	 string From { get; set; }
	 string To { get; set; }
	 object Message { get; set; }
	 double Delay { get; set; }
	}

	public static class MessageExtensions
	{
		public static IMessage Prepare(this IMessage m, string from, string to, object message, double delay)
		{
			m.From = from;
			m.To = to;
			m.Message = message;
			m.Delay = delay;
			return m;
		}
	}
}
