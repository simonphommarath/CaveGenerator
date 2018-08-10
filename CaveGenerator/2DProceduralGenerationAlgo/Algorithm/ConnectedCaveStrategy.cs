using _2DProceduralContentGenerator;
using _2DProceduralContentGenerator.Algorithm;
using _2DProceduralContentGenerator.Model;

namespace _2DProceduralGenerationAlgo.Algorithm
{
    class ConnectedCaveStrategy : IProceduralGenStragery
    {

        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }
        public int _iterationCount { get; set; }
        public double _wallChance { get; set; }
        private int _currentIteration;

        public ConnectedCaveStrategy()
        {
            _birthLimit = 3;
            _deathLimit = 4;
            _iterationCount = 3;
            _wallChance = 0.65;
            _currentIteration = 0;
        }

        /// <summary>
        /// Initialize the cave by setting random cells to active;
        /// </summary>
        /// <returns>New initialized map</returns>
        public Cave InitializeCave(Cave cave)
        {
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        if (CustomRandomNumberGenerator.GetRandom() < this._wallChance)
                        {
                            cave._celullarMap[x, y].state = Utility.STATE.Rock;
                        }
                    }
                    else
                    {
                        cave._celullarMap[x, y].state = Utility.STATE.Rock;
                    }
                }
            }
            return cave;
        }

        /// <summary>
        /// Simulate one iteration of the algorithm
        /// </summary>
        /// <param name="cave"></param>
        /// <returns></returns>
        public Cave doSimulation(Cave cave)
        {
            Cell[,] copyMap = cave._celullarMap;

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {

                    if (!cave.IsBorderCell(x, y))
                    {
                        int activeNeighbor = cave.GetSumOfCellActiveNeighbor(x, y);

                        if (_currentIteration < 4)
                        {
                            if (cave._celullarMap[x, y].state == Utility.STATE.Air)
                            {
                                if (activeNeighbor < _birthLimit)
                                {
                                    // Fill the holes
                                    copyMap[x, y].state = Utility.STATE.Rock;
                                }
                            }
                            else
                            {
                                if (activeNeighbor > _deathLimit)
                                {
                                    // Destroy small walls
                                    copyMap[x, y].state = Utility.STATE.Air;
                                }
                            }
                        }
                        else
                        {
                            if (cave._celullarMap[x, y].state == Utility.STATE.Air)
                            {
                                if (activeNeighbor >= _deathLimit)
                                {
                                    copyMap[x, y].state = Utility.STATE.Air;
                                }
                            }
                        }
                    }

                }
            }

            _currentIteration++;
            cave._celullarMap = copyMap;
            return cave;
        }
    }
}
