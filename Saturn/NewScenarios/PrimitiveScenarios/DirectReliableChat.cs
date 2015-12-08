using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	class DirectReliableChat : CombinedScenario
	{
		string user1;
		string user2;
		int chatLength;
		Func<object> messageSource;
		Func<double> messageDelayGenerator;

		public DirectReliableChat(string user1, string user2, int chatLength, Func<double> messageDelayGenerator, Func<object> messageSource)
		{
			this.user1 = user1;
			this.user2 = user2;
			this.chatLength = chatLength;
			this.messageSource = messageSource;
			this.messageDelayGenerator = messageDelayGenerator;

		}

		protected override IEnumerable<IScenario> Scenarios
		{
			get
			{
				for (int i = 0; i < chatLength; i++)
				{
					bool speak1 = i % 2 == 0;
					yield return new DirectReliableMessage(
						speak1 ? user1 : user2,
						speak1 ? user2 : user1,
						messageSource(),
						messageDelayGenerator()
						);
				}
			}
		}
	}
}
