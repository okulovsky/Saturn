using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	[JsonSerializer]
	public class MediatedMessageFrame
	{
		public string Sender { get; set; }
		public object Entry { get; set; }
	}
}
