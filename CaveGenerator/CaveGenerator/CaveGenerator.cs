using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaveGenerator
{
    /// <summary>
    /// False = Wall
    /// True = Open
    /// </summary>
    public class CaveGenerator
    {
        private int _width = 50;
        private int _height = 50;

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

            MakeBlankMap();
            InitializeCave();
        }

        /// <summary>
        /// Create a blank map, where all fields are walls
        /// </summary>
        public void MakeBlankMap()
        {
            Boolean[,] map = new Boolean[_width, _height];

            Random random = new Random();

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++) {
                    map[x, y] = false;
                }
            }
            this._celullarMap = map;
        }

        /// <summary>
        /// Initialize the cave by setting random cells to active;
        /// </summary>
        /// <returns>New initialized map</returns>
        public void InitializeCave()
        {
            Boolean[,] map = new Boolean[_width, _height];

            Random random = new Random();

            for ( int x = 0; x < _width; x++ ) {
                for ( int y = 0; y < _height; y++ ) {
                    if (random.Next(0,100) < this._activeChance || IsBorderCell(x,y)) {
                        map[x,y] = true;
                    }
                }
            }
            this._celullarMap = map;
        }

        /// <summary>
        /// Check if cell is a wall
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Returns true if is a wall</returns>
        bool IsWall(int x, int y)
        {
            if (IsOutOfBounds(x, y)) {
                return true;
            }

            if (_celullarMap[x, y] == true) {
                return true;
            }

            if (_celullarMap[x, y] == false) {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Check if coordinate is out of bound
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Returns true if coordinate is out of bound</returns>
        bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || y < 0) {
                return true;
            }
            else if (x > _width - 1 || y > _height - 1) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if coordinate is a border
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Returns true if coordinate is a border cell</returns>
        bool IsBorderCell(int x, int y)
        {
            if (x == 0 || y == 0) {
                return true;
            }
            else if (x == _width-1 || y == _height - 1) {
                return true;
            }
            return false;
        }

        bool IsActive(int x, int y)
        {
            return !_celullarMap[x, y];
        }

        /// <summary>
        /// Check number of active neighbor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        int getSumOfActiveNeighbor(int dx, int dy)
        {
            int result = 0;

            for (int x = -1; x <= 1; ++x)
            {
                for (int y = -1; y <= 1; ++y)
                {
                    // not himself
                    if (x != 0 && y != 0) {
                        if (!IsOutOfBounds(dx + x, dy + y)) {
                            if (IsActive(dx + x, dy + y)) {
                                result++;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Print grid in text file (temp)
        /// </summary>
        public void PrintGrid()
        {
            string path = @"D:\MyTest.txt";

            // Delete file
            if (File.Exists(path)) {
                File.Delete(path);
            }

            if (!File.Exists(path)) {
                // Creates a file and write
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int x = 0; x < _width; x++)
                    {
                        for (int y = 0; y < _height; y++) {
                            // Console.WriteLine("(" + x + ","+ y +  "): " + getSumOfActiveNeighbor(x, y));
                            sw.Write(this._celullarMap[x, y] ? "#":" ");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        void DoSimulation() {

        }
    }
}