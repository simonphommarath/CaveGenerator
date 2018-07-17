using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator;
using CaveGenerator.Model;

namespace CaveGenerator.Algorithm
{
    class GameOfLifeStrategy : IProceduralGenStragery
    {

        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }
        public int _iterationCount { get; set; }
        public int _activeChance { get; set; }

        public GameOfLifeStrategy()
        {
            _birthLimit = 2;
            _deathLimit = 3;
            _iterationCount = 10;
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

                        if (copyMap[x, y])
                        {
                            if (activeNeighbor < _birthLimit)
                            {
                                // Underpopulation
                                copyMap[x, y] = Utility.WALL;
                            }
                            else if (activeNeighbor == _birthLimit || activeNeighbor == _deathLimit)
                            {
                                // Reproduction
                                copyMap[x, y] = Utility.HOLE;
                            }
                            else
                            {
                                // Overpopulation
                                copyMap[x, y] = Utility.WALL;
                            }
                        }
                        else
                        {
                            if (activeNeighbor == _deathLimit)
                            {
                                // Reproduction
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