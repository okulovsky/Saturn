
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    public static class Extensions
    {


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
