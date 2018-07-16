using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave
{

    public class Cave
    {
        public Boolean[,] _celullarMap { get; set; }

        /// <summary>
        /// Constructor to CaveGenerator
        /// </summary>
        public Cave()
        {
            this._celullarMap = new Boolean[Utility.WIDTH, Utility.HEIGTH];
            MakeBlankGrid();
        }

        /// <summary>
        /// Create a blank map, where all fields are walls
        /// </summary>
        public void MakeBlankGrid()
        {
            Boolean[,] map = new Boolean[Utility.WIDTH, Utility.HEIGTH];

            Random random = new Random();

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.WIDTH; y++) {
                    map[x, y] = Utility.WALL;
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
            else if (x > Utility.WIDTH - 1 || y > Utility.HEIGTH - 1) {
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
            else if (x == Utility.WIDTH - 1 || y == Utility.HEIGTH - 1) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check number of active neighbor
        /// Out of bound is considered active neighbor
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public int GetSumOfCellActiveNeighbor(int x, int y)
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
    }
}