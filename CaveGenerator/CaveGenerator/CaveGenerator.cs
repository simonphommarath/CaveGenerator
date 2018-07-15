using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaveGenerator
{
    public class CaveGenerator
    {
        private int _width = 100;
        private int _height = 100;

        private int _birthLimit;
        private int _deathLimit;
        private double _initialChance;
        private int _stepsCount;
        private int _activeChance;

        Boolean[,] _celullarMap;

        /// <summary>
        /// Constructor to CaveGenerator
        /// </summary>
        public CaveGenerator()
        {
            this._birthLimit = 4;
            this._deathLimit = 3;
            this._initialChance = 0.4f;
            this._stepsCount = 2;
            this._activeChance = 45;

            this._celullarMap = new Boolean[_width, _height];
            initializeCave();
        }

        /// <summary>
        /// Initialize the cave by setting random cells to active;
        /// </summary>
        /// <returns>New initialized map</returns>
        public void initializeCave()
        {
            Boolean[,] map = new Boolean[_width, _height];

            Random random = new Random();

            for ( int i = 0; i < _width; i++ ) {
                for ( int j = 0; j < _height; j++ ) {
                    if (random.Next(0,100) < this._activeChance ) {
                        map[i,j] = true;
                    }
                    else {
                        map[i, j] = false;
                    }
                }
            }
            this._celullarMap = map;
        }

        /// <summary>
        /// Print grid in text file
        /// </summary>
        public void printGrid()
        {
            string path = @"D:\MyTest.txt";

            if (File.Exists(path)){
                File.Delete(path);
            }

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < _width; i++)
                    {
                        for (int j = 0; j < _height; j++) {
                            sw.Write(this._celullarMap[i, j] ? "#":" ");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        void doSimulation() {

        }
    }
}