using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaveGenerator
{
    public static class RandomNumberGenerator
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static double GetRandom()
        {
            double value = 0;

            // we dont want no 0
            while(value == 0) {
                value = random.Value.NextDouble();
            }

            return value;
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Value.Next(min, max);
        }
    }
}
