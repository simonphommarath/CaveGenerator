using _2DProceduralContentGenerator;
using _2DProceduralContentGenerator.Algorithm;
using _2DProceduralContentGenerator.Model;
using _2DProceduralGenerationAlgo.AutonomousAgent;
using System.Collections.Generic;

namespace _2DProceduralGenerationAlgo.Algorithm
{
    class RandomWalkStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public List<AARandWalkStrategy> RWalkSeeds { get; set; }
        private const int seedNumber = 10;

        public Cave InitializeCave(Cave cave)
        {
            _iterationCount = 50;

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    cave._celullarMap[x, y].state = Utility.STATE.Rock;
                }
            }

            RWalkSeeds = new List<AARandWalkStrategy>();

            for (int i = 0; i < seedNumber; i++)
            {
                AARandWalkStrategy seed = new AARandWalkStrategy(
                        CustomRandomNumberGenerator.GetRandomInt(40, 90),
                        CustomRandomNumberGenerator.GetRandomInt(20, 55)
                    );
                cave._celullarMap[seed._x, seed._y].state = Utility.STATE.Air;
                RWalkSeeds.Add(seed);
            }

            return cave;
        }

        public Cave doSimulation(Cave cave)
        {
            foreach (var seed in RWalkSeeds)
            {
                seed.NextAction();
                if (cave.IsOutOfBounds(seed._x, seed._y))
                {
                    seed._isAlive = false;
                }
                else
                {
                    cave._celullarMap[seed._x, seed._y].state = Utility.STATE.Air;
                }
            }
            return cave;
        }
    }
}