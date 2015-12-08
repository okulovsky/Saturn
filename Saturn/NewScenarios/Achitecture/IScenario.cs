
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.NewScenarios
{
	public interface IScenario
	{
		IEnumerable<double> PerformActions(World w);
	}
}
