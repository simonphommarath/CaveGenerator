using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator.Model;

namespace CaveGenerator.Algorithm
{
    /// <summary>
    /// Experimental algorithm
    /// </summary>
    class OpenPlatformStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _activeChanceOnAir { get; set; }

        public int _growthHorizontalChance { get; set; }
        public int _growthVerticalChance { get; set; }

        Random random;

        public OpenPlatformStrategy()
        {
            _iterationCount = 3;

            _activeChanceOnAir = 199;

            _growthHorizontalChance = 75;
            _growthVerticalChance = 10;

            random = new Random();
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
                        if (!(random.Next(1, 200) < this._activeChanceOnAir)) {
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
                            if (random.Next(1, 100) < this._growthHorizontalChance) {

                                copyMap[x - 1, y].state = Utility.STATE.Rock;
                            }
                            if (random.Next(1, 100) < this._growthHorizontalChance) {
                                copyMap[x + 1, y].state = Utility.STATE.Rock;
                            }
                            if (random.Next(1, 100) < this._growthVerticalChance){
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