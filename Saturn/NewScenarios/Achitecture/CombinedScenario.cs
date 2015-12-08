using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	public abstract class CombinedScenario : IScenario
	{
		protected abstract IEnumerable<IScenario> Scenarios { get; }

		public IEnumerable<double> PerformActions(World w)
		{
			foreach (var e in Scenarios)
				foreach (var a in e.PerformActions(w))
					yield return a;
		}
	}
}
