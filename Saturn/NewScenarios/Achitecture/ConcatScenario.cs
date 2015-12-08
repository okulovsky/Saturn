using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	class ConcatScenario : CombinedScenario
	{
		IScenario[] scenarios;

		public ConcatScenario(params IScenario[] scenarios)
		{
			this.scenarios = scenarios;
		}

		protected override IEnumerable<IScenario> Scenarios
		{
			get { return scenarios; }
		}
	}
}
