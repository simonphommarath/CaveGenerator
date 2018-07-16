using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGenerator.Algorithm
{
    class GameOfLifeStrategy : IProceduralGenStragery
    {
        public CaveGenerator doSimulation(CaveGenerator cave)
        {
            Boolean[,] copyMap = cave._celullarMap;

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {
                        int activeNeighbor = cave.GetSumOfActiveNeighbor(x, y);

                        if (copyMap[x, y])
                        {
                            if (activeNeighbor < 2)
                            {
                                // Underpopulation
                                copyMap[x, y] = Utility.WALL;
                            }
                            else if (activeNeighbor == 2 || activeNeighbor == 3)
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
                            if (activeNeighbor == 3)
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
