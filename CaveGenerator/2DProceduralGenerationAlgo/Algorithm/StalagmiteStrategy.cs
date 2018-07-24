using _2DProceduralGenerationAlgo.Model;

namespace _2DProceduralGenerationAlgo.Algorithm
{
    class StalagmiteStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _floorLimit { get; set; }

        public StalagmiteStrategy()
        {
            _iterationCount = 20;
            _floorLimit = 70;
        }

        public Cave InitializeCave(Cave cave)
        {
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < _floorLimit; y++)
                {
                    // TBD
                }
            }

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = _floorLimit; y < Utility.HEIGTH; y++) {
                    cave._celullarMap[x,y].state = Utility.STATE.Rock;
                }
            }
            
            return cave;
        }

        public Cave doSimulation(Cave cave)
        {
            Cell[,] copyMap = cave._celullarMap;

            // TBD

            cave._celullarMap = copyMap;
            return cave;
        }
    }
}