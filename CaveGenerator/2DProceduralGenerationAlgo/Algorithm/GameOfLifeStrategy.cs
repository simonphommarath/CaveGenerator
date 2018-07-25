using _2DProceduralContentGenerator.Model;
using static _2DProceduralContentGenerator.Utility;

namespace _2DProceduralContentGenerator.Algorithm
{
    class GameOfLifeStrategy : IProceduralGenStragery
    {

        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }
        public int _iterationCount { get; set; }
        public double _wallChance { get; set; }

        public GameOfLifeStrategy()
        {
            _birthLimit = 2;
            _deathLimit = 3;
            _iterationCount = 10;
            _wallChance = 0.90;
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
                    if (cave.IsBorderCell(x, y))
                    {
                        cave._celullarMap[x, y].state = Utility.STATE.Rock;
                    }
                    else {
                        if (CustomRandomNumberGenerator.GetRandom() < this._wallChance)
                        {
                            cave._celullarMap[x, y].state = Utility.STATE.Rock;
                        }
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

                        if (copyMap[x, y].state == STATE.Air)
                        {
                            if (activeNeighbor < _birthLimit)
                            {
                                // Underpopulation
                                copyMap[x, y].state = STATE.Rock;
                            }
                            else if (activeNeighbor == _birthLimit || activeNeighbor == _deathLimit)
                            {
                                // Reproduction
                                copyMap[x, y].state = STATE.Air;
                            }
                            else
                            {
                                // Overpopulation
                                copyMap[x, y].state = STATE.Rock;
                            }
                        }
                        else
                        {
                            if (activeNeighbor == _deathLimit)
                            {
                                // Reproduction
                                copyMap[x, y].state = STATE.Air;
                            }
                        }
                    }
                }
            }
            cave._celullarMap = copyMap;
            return cave;
        }
    }
}