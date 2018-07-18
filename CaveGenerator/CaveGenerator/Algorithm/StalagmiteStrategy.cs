using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator.Model;
using CaveGenerator.AutonomousAgent;

namespace CaveGenerator.Algorithm
{
    class StalagmiteStrategy : IProceduralGenStragery
    {
        public int _iterationCount { get; set; }

        public int _floorLimit { get; set; }

        Random random;

        public StalagmiteStrategy()
        {
            _iterationCount = 20;
            _floorLimit = 70;

            random = new Random();
        }

        public Cave InitializeCave(Cave cave)
        {
            cave.MakeBlankGrid(true);

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
                    cave._celullarMap[x,y] = Utility.WALL;
                }
            }
            
            return cave;
        }

        public Cave doSimulation(Cave cave)
        {
            Boolean[,] copyMap = cave._celullarMap;

            // TBD

            cave._celullarMap = copyMap;
            return cave;
        }
    }
}