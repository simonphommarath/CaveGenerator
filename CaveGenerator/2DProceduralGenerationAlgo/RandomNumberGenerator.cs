using System;

namespace _2DProceduralContentGenerator
{
    public static class CustomRandomNumberGenerator
    {
        static int seed = Environment.TickCount;

        static readonly Random random = new Random();

        public static double GetRandom()
        {
            double value = 0;

            // we dont want no 0
            while(value == 0) {
                value = random.NextDouble();
            }

            return value;
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}