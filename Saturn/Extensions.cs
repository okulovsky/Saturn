using Saturn.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public static class Extensions
    {
        public static double Gauss(this Random rnd, double mean, double deviation)
        {
            double u1 = rnd.NextDouble(); 
            double u2 = rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2);
            double randNormal =
                         mean + deviation * randStdNormal;
            return randNormal;
        }

         public static double Gauss(this Random rnd, GaussParameters param)
        {
            return rnd.Gauss(param.Mean, param.Deviation);
        }
       

        public static T Element<T>(this Random rnd, IEnumerable<T> array)
        {
            return array.ElementAt(rnd.Next(array.Count()));
        }



        public static ScenarioAction WithDelay(this Action<World> action, double delay)
        {
            return new ScenarioAction(delay, action);
        }

        public static T ArgMin<T>(this IEnumerable<T> en,Func<T,double> selector)
        {
            bool firstTime = true;
            double currentMin=double.PositiveInfinity;
            T arg = default(T);
            foreach(var e in en)
            {
                var c = selector(e);
                if (firstTime || c<currentMin)
                {
                    arg = e;
                    currentMin = c;
                    firstTime = false;
                }
            }
            if (firstTime) throw new ArgumentException();
            return arg;
        }
    }
}
