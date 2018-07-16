using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave.Algorithm
{
    class SimpleCaveStrategy : IProceduralGenStragery
    {
        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }
        public int _iterationCount { get; set; }
        public int _activeChance { get; set; }

        public SimpleCaveStrategy()
        {
            _birthLimit = 3;
            _deathLimit = 4;
            _iterationCount = 3;
            _activeChance = 45;
        }

        /// <summary>
        /// Initialize the cave by setting random cells to active;
        /// </summary>
        /// <returns>New initialized map</returns>
        public Cave InitializeCave(Cave cave)
        {
            Random random = new Random();

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        if (random.Next(0, 100) < this._activeChance)
                        {
                            cave._celullarMap[x, y] = Utility.HOLE;
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
            Boolean[,] copyMap = cave._celullarMap;

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        int activeNeighbor = cave.GetSumOfCellActiveNeighbor(x, y);

                        if (cave.IsActive(x, y))
                        {
                            if (activeNeighbor < _birthLimit)
                            {
                                // Fill the holes
                                copyMap[x, y] = Utility.WALL;
                            }
                        }
                        else
                        {
                            if (activeNeighbor > _deathLimit)
                            {
                                // Destroy small walls
                                copyMap[x, y] = Utility.HOLE;
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