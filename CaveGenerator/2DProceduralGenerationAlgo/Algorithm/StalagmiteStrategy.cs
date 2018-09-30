using _2DProceduralContentGenerator.Model;
using _2DProceduralGenerationAlgo.AutonomousAgent;
using System.Collections.Generic;

namespace _2DProceduralContentGenerator.Algorithm
{
    class StalagmiteStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _generation { get; set; }

        public int _floorLimit { get; set; }
        public List<AAStalagStrategy> upStalag { get; set; }
        public List<AAStalagStrategy> sideStalag { get; set; }

        public StalagmiteStrategy()
        {
            _iterationCount = 20;
            _floorLimit = 70;

            upStalag = new List<AAStalagStrategy>();
            sideStalag = new List<AAStalagStrategy>();
        }

        public Cave InitializeCave(Cave cave)
        {
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = _floorLimit; y < Utility.HEIGTH; y++) {
                    cave._celullarMap[x,y].state = Utility.STATE.Rock;
                }
            }

            CreateSeed();
            foreach (var seed in upStalag)
            {
                cave._celullarMap[seed._x, seed._y].state = Utility.STATE.Rock;
            }

            return cave;
        }

        public Cave doSimulation(Cave cave)
        {
            Cell[,] copyMap = cave._celullarMap;

            foreach (var stalag in upStalag)
            {
                sideStalag.Add(new AAStalagStrategy(stalag._x, stalag._y, growthDirection: Utility.DIRECTION.Left, growthRate: 6));
                sideStalag.Add(new AAStalagStrategy(stalag._x, stalag._y, growthDirection: Utility.DIRECTION.Right, growthRate: 6));
                stalag.NextAction();
                cave._celullarMap[stalag._x, stalag._y].state = Utility.STATE.Rock;
            }

            foreach (var stalag in sideStalag)
            {
                stalag.NextAction();
                cave._celullarMap[stalag._x, stalag._y].state = Utility.STATE.Rock;
            }

            cave._celullarMap = copyMap;
            return cave;
        }

        private void CreateSeed()
        {
            upStalag = new List<AAStalagStrategy>();

            int seedNumber = CustomRandomNumberGenerator.GetRandomInt(6, 10);

            int seedDistance = Utility.WIDTH / seedNumber;

            for (int i = 1; i < seedNumber; i++)
            {
                int trueDistance = 0;
                while ((i * trueDistance <= 0 || i * trueDistance >= Utility.WIDTH))
                {
                    trueDistance = seedDistance + CustomRandomNumberGenerator.GetRandomInt(-2, 2);
                }
                upStalag.Add(new AAStalagStrategy(i * trueDistance, _floorLimit - 1));
            }
        }
    }
}