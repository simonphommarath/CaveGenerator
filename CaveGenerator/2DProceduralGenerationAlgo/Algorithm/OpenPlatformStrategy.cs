using _2DProceduralContentGenerator.Model;

namespace _2DProceduralContentGenerator.Algorithm
{
    /// <summary>
    /// Experimental algorithm
    /// </summary>
    class OpenPlatformStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public double _activeChanceOnAir { get; set; }

        public double _growthHorizontalChance { get; set; }
        public double _growthVerticalChance { get; set; }

        public OpenPlatformStrategy()
        {
            _iterationCount = 3;

            _activeChanceOnAir = 0.99;

            _growthHorizontalChance = 0.75;
            _growthVerticalChance = 0.10;
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
                    if (!cave.IsBorderCell(x, y)){
                        if (!(CustomRandomNumberGenerator.GetRandom() < this._activeChanceOnAir)) {
                            cave._celullarMap[x, y].state = Utility.STATE.Rock;
                        }
                    }
                    else {
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
                    if(!cave.IsBorderCell(x, y)) {
                        if (cave._celullarMap[x, y].state == Utility.STATE.Rock)
                        {
                            if (CustomRandomNumberGenerator.GetRandom() < this._growthHorizontalChance) {

                                copyMap[x - 1, y].state = Utility.STATE.Rock;
                            }
                            if (CustomRandomNumberGenerator.GetRandom() < this._growthHorizontalChance) {
                                copyMap[x + 1, y].state = Utility.STATE.Rock;
                            }
                            if (CustomRandomNumberGenerator.GetRandom() < this._growthVerticalChance){
                                copyMap[x, y + 1].state = Utility.STATE.Rock;
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