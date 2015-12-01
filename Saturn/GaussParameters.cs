using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public class GaussParameters
    {
        public readonly double Mean;
        public readonly double Deviation;
        public GaussParameters(double mean, double deviation)
        {
            this.Mean = mean;
            this.Deviation = deviation;
        }
    }
}
