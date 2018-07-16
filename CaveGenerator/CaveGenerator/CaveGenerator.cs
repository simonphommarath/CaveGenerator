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

        public int _width { get; private set; }
        public int _height { get; private set; }

        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }
        public int _iterationCount { get; set; }
        public int _activeChance { get; set; }

        public Boolean[,] _celullarMap { get; set; }

        /// <summary>
        /// Constructor to CaveGenerator
        /// </summary>
        public CaveGenerator()
        {
            this._width = 75;
            this._height = 75;

            this._birthLimit = 4;
            this._deathLimit = 2;
            this._iterationCount = 5;
            this._activeChance = 45;

            this._celullarMap = new Boolean[_width, _height];

            MakeBlankGrid();
            InitializeCave();
        }

        /// <summary>
        /// Create a blank map, where all fields are walls
        /// </summary>
        public void MakeBlankGrid()
        {
            Boolean[,] map = new Boolean[_width, _height];

            Random random = new Random();

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++) {
                    map[x, y] = Utility.WALL;
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
                    if (!IsBorderCell(x, y)) {
                        if (random.Next(0, 100) < this._activeChance) {
                            map[x, y] = Utility.HOLE;
                        }
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
        public bool IsActive(int x, int y)
        {
            if (IsOutOfBounds(x, y)) {
                return false;
            }

            if (_celullarMap[x, y] == Utility.HOLE) {
                return true;
            }

            if (_celullarMap[x, y] == Utility.WALL) {
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
        public bool IsOutOfBounds(int x, int y)
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
        public bool IsBorderCell(int x, int y)
        {
            if (x == 0 || y == 0) {
                return true;
            }
            else if (x == _width-1 || y == _height - 1) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Prints all cells active neighbor for test purpose
        /// </summary>
        public void PrintActiveNeighbor()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Console.WriteLine("(" + x + "," + y + "): " + GetSumOfActiveNeighbor(x, y));
                }
            }
        }

        /// <summary>
        /// Check number of active neighbor
        /// Out of bound is considered active neighbor
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public int GetSumOfActiveNeighbor(int x, int y)
        {
            int result = 0;

            for (int dx = -1; dx <= 1; ++dx)
            {
                for (int dy = -1; dy <= 1; ++dy)
                {
                    if (!(dx == 0 && dy == 0))
                    {
                        if (IsOutOfBounds(x + dx, y + dy)) {
                            //result++;
                        }
                        else if (IsActive(x + dx, y + dy)) {
                            result++;
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
                            sw.Write(this._celullarMap[x, y] ? "#":" ");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}