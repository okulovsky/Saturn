using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn
{
    static class Rnd
    {
        static Random rnd = new Random();

        public static double NextDouble(double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }

        public static int NextInt(int min, int max)
        {
            return (int)(rnd.NextDouble() * (max - min)) + min;
        }

        public static bool NextBool(double probability)
        {
            return rnd.NextDouble() < probability;
        }


        public static T Element<T>(IEnumerable<T> array)
        {
            return array.ElementAt(rnd.Next(array.Count()));
        }
    }
}
