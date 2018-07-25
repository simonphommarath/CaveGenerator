using _2DProceduralContentGenerator.AutonomousAgent;
using _2DProceduralContentGenerator.Model;
using System.Collections.Generic;

namespace _2DProceduralContentGenerator.Algorithm
{
    public class PlantStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _floorLimit { get; set; }
        public List<AASeedStrategy> seeds { get; set; }

        public PlantStrategy()
        {
            _iterationCount = 80;
            _floorLimit = 70;

            seeds = new List<AASeedStrategy>();
        }

        public Cave InitializeCave(Cave cave)
        {
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = _floorLimit; y < Utility.HEIGTH; y++)
                {
                    cave._celullarMap[x, y].state = Utility.STATE.Rock;
                }
            }

            CreateSeed();
            foreach (var seed in seeds)
            {
                cave._celullarMap[seed._x, seed._y].state = Utility.STATE.Seed;
            }

            return cave;
        }

        public Cave doSimulation(Cave cave)
        {
            Cell[,] copyMap = cave._celullarMap;

            foreach (var seed in seeds)
            {
                seed.NextAction();
                if (seed._isAlive)
                {
                    if (cave.IsOutOfBounds(seed._x, seed._y))
                    {
                        seed._isAlive = false;
                    }
                    else
                    {
                        cave._celullarMap[seed._x, seed._y].state = Utility.STATE.Other;
                    }
                }
            }

            cave._celullarMap = copyMap;
            return cave;
        }

        private void CreateSeed()
        {
            seeds = new List<AASeedStrategy>();

            int seedNumber = CustomRandomNumberGenerator.GetRandomInt(6, 10);

            int seedDistance = Utility.WIDTH / seedNumber;

            for (int i = 1; i < seedNumber; i++)
            {
                int trueDistance = 0;
                while ((i * trueDistance <= 0 || i * trueDistance >= Utility.WIDTH)) {
                    trueDistance = seedDistance + CustomRandomNumberGenerator.GetRandomInt(-2, 2);
                }
                seeds.Add(new AASeedStrategy(i * trueDistance, _floorLimit - 1));
            }
        }

    }
}