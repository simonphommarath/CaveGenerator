using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator.Model;
using CaveGenerator.AutonomousAgent;

namespace CaveGenerator.Algorithm
{
    public class PlantStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _floorLimit { get; set; }
        public List<AASeedStrategy> seeds { get; set; }

        Random random;

        public PlantStrategy()
        {
            _iterationCount = 20;
            _floorLimit = 70;

            seeds = new List<AASeedStrategy>();

            random = new Random();
        }

        public Cave InitializeCave(Cave cave)
        {
            cave.MakeBlankGrid();

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
                        cave._celullarMap[seed._x, seed._y].state = Utility.STATE.Rock;
                    }
                }
            }

            cave._celullarMap = copyMap;
            return cave;
        }

        public void CreateSeed()
        {
            seeds = new List<AASeedStrategy>();
            int seedNumber = random.Next(5, 10);
            int seedDistance = Utility.WIDTH / seedNumber;

            for (int i = 1; i < seedNumber; i++)
            {
                seeds.Add(new AASeedStrategy(i * (seedDistance + random.Next(-2, 2)), _floorLimit - 1));
            }
        }
    }
}
