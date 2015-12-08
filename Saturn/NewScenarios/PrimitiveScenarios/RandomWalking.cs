using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	class RandomWalking : IScenario
	{
		Func<double> delayGenerator;
		string user;

		public RandomWalking(string user, Func<double> delayGenerator)
		{
			this.delayGenerator = delayGenerator;
			this.user = user;
		}



		public IEnumerable<double> PerformActions(World w)
		{
			while(true)
			{
				w.UserToAccessPoint[user] = Rnd.Element(w.AccessPointsAddresses);
				w.Message(user, "CONNECTED");
				yield return delayGenerator();
			}
		}
	}
}
