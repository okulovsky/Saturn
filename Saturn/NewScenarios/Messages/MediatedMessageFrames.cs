using Saturn.ProtocolStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	
	public abstract class MediatedMessageFrame
	{
		public string Sender { get; set; }
		[EntryField]
		public object Entry;
	}

	[JsonSerializer]
	public class JsonMediatedMessageFrame : MediatedMessageFrame
	{

	}
	[XmlSerializer]
	public class XmlMediatedMessageFrame : MediatedMessageFrame
	{

	}
}
