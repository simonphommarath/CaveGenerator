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
        const bool WALL = false;
        const bool HOLE = true;

        private int _width = 75;
        private int _height = 75;

        private int _birthLimit;
        private int _deathLimit;
        private int _iterationCount;
        private int _activeChance;

        Boolean[,] _celullarMap;

        /// <summary>
        /// Constructor to CaveGenerator
        /// </summary>
        public CaveGenerator()
        {
            this._birthLimit = 4;
            this._deathLimit = 2;
            this._iterationCount = 5;
            this._activeChance = 45;

            this._celullarMap = new Boolean[_width, _height];

            MakeBlankGrid();
            InitializeCave();
        }

        public Boolean[,] GetCellularMap()
        {
            return this._celullarMap;
        }

        public int GetWidth()
        {
            return this._width;
        }

        public int GetHeigth()
        {
            return this._height;
        }

        public int GetIterationCount()
        {
            return this._iterationCount;
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
                    map[x, y] = WALL;
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
                            map[x, y] = HOLE;
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
        bool IsActive(int x, int y)
        {
            if (IsOutOfBounds(x, y)) {
                return false;
            }

            if (_celullarMap[x, y] == HOLE) {
                return true;
            }

            if (_celullarMap[x, y] == WALL) {
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

        /// <summary>
        /// Prints all cells active neighbor for test purpose
        /// </summary>
        public void PrintActiveNeighbor()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Console.WriteLine("(" + x + "," + y + "): " + getSumOfActiveNeighbor(x, y));
                }
            }
        }

        /// <summary>
        /// Check number of active neighbor
        /// Out of bound is considered active neighbor
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        int getSumOfActiveNeighbor(int x, int y)
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

        /// <summary>
        /// Do the original simulation
        /// </summary>
        public void DoSimulation1()
        {
            Boolean[,] copyMap = this._celullarMap;

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (!IsBorderCell(x, y))
                    {
                        int activeNeighbor = getSumOfActiveNeighbor(x, y);

                        // If few neighbours, kill cell.
                        if (copyMap[x, y]) {
                            if (activeNeighbor < _deathLimit) {
                                copyMap[x, y] = WALL;
                            }
                            else { 
                                copyMap[x, y] = HOLE;
                            }
                        } // Else, become active if right number
                        else {
                            if (activeNeighbor > _birthLimit) {
                                copyMap[x, y] = HOLE;
                            }
                            else {
                                copyMap[x, y] = WALL;
                            }
                        }
                    }
                }
            }
            this._celullarMap = copyMap;
        }

        /// <summary>
        /// Do a custom simulation
        /// </summary>
        public void DoSimulation2()
        {
            Boolean[,] copyMap = this._celullarMap;

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (!IsBorderCell(x, y))
                    {
                        int activeNeighbor = getSumOfActiveNeighbor(x, y);

                        if (IsActive(x, y)) {
                            if (activeNeighbor < 3) {
                                // Underpopulation
                                copyMap[x, y] = WALL;
                            }
                        }
                        else {
                            if (activeNeighbor > 4) {
                                // reproduction
                                copyMap[x, y] = HOLE;
                            }
                        }

                    }
                }
            }
            this._celullarMap = copyMap;
        }
    }
}