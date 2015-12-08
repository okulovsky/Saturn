using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	public class Sleep : IScenario
	{
		double time;
		public Sleep(double time)
		{
			this.time = time;
		}

		public IEnumerable<double> PerformActions(World w)
		{
			yield return time;
		}
		
	}
}
