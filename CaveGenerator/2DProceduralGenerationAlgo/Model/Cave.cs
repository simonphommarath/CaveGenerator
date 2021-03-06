﻿namespace _2DProceduralContentGenerator.Model
{
    public class Cave
    {
        public Cell[,] _celullarMap { get; set; }

        /// <summary>
        /// Constructor to CaveGenerator
        /// </summary>
        public Cave()
        {
            this._celullarMap = new Cell[Utility.WIDTH, Utility.HEIGTH];

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    _celullarMap[x, y] = new Cell();
                }
            }
        }

        /// <summary>
        /// Create a blank map, where all fields are the same
        /// </summary>
        /// <param name="isFullOfHole">cell default value</param>
        public void MakeBlankGrid()
        {
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++) {
                    this._celullarMap[x, y].state = Utility.STATE.Air;
                }
            }
        }

        /// <summary>
        /// Check if cell is a wall
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Returns true if is a wall</returns>
        public bool IsAir(int x, int y)
        {
            if (IsOutOfBounds(x, y)) {
                return false;
            }

            if (_celullarMap[x, y].state == Utility.STATE.Air) {
                return true;
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
                    if (!IsOutOfBounds(x + dx, y + dy))
                    {
                        if (_celullarMap[x + dx, y + dy].state == Utility.STATE.Air)
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get total number of rock on the map
        /// </summary>
        /// <returns></returns>
        public int GetWallTotal()
        {
            int total = 0;
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < Utility.HEIGTH; y++)
                {
                    if (this._celullarMap[x,y].state == Utility.STATE.Rock)
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        /// <summary>
        /// Get total cell number on map
        /// </summary>
        /// <returns></returns>
        public int GetCellTotal()
        {
            return Utility.HEIGTH * Utility.WIDTH;
        }

        /// <summary>
        /// Return the rock to cell ratio
        /// </summary>
        /// <returns></returns>
        public double GetWallRatio()
        {
            return GetWallTotal() / GetCellTotal();
        }
    }
}