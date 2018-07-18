using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator.Model;

namespace CaveGenerator.Algorithm
{
    class StalagmiteStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public StalagmiteStrategy()
        {
            _iterationCount = 0;
        }

        public Cave InitializeCave(Cave cave)
        {
            Random random = new Random();

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {

                    }
                }
            }
            return cave;
        }

        public Cave doSimulation(Cave cave)
        {
            Boolean[,] copyMap = cave._celullarMap;

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y))
                    {

                    }
                }
            }
            cave._celullarMap = copyMap;
            return cave;
        }
    }
}