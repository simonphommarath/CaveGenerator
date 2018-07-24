using _2DProceduralContentGenerator.Model;

namespace _2DProceduralContentGenerator.Algorithm
{
    class FloorLevelStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }

        public int _upperFloorLimit { get; set; }
        public int _lowerFloorLimit { get; set; }

        public double _activeChanceGround { get; set; }
        public double _activeChanceOnCrust { get; set; }

        public FloorLevelStrategy()
        {
            _iterationCount = 3;

            _lowerFloorLimit = 70;
            _upperFloorLimit = 65;

            _birthLimit = 3;
            _deathLimit = 4;

            _activeChanceGround = 0.10;
            _activeChanceOnCrust = 0.50;
        }

        /// <summary>
        /// Initialize the cave by setting random cells to active;
        /// </summary>
        /// <returns>New initialized map</returns>
        public Cave InitializeCave(Cave cave)
        {
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = _upperFloorLimit; y < _lowerFloorLimit; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        if (!(RandomNumberGenerator.GetRandom() < this._activeChanceOnCrust))
                        {
                            cave._celullarMap[x, y].state = Utility.STATE.Rock;
                        }
                    }
                    else
                    {
                        cave._celullarMap[x, y].state = Utility.STATE.Rock;
                    }
                }

                for (int y = _lowerFloorLimit; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        if (!(RandomNumberGenerator.GetRandom() < this._activeChanceGround))
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
                for (int y = _upperFloorLimit; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        int activeNeighbor = cave.GetSumOfCellActiveNeighbor(x, y);

                        if (cave.IsAir(x, y))
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
                }
            }

            cave._celullarMap = copyMap;
            return cave;
        }
    }
}
