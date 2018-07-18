﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator.Model;

namespace CaveGenerator.Algorithm
{
    /// <summary>
    /// Experimental algorithm
    /// </summary>
    class OpenPlatformStrategy : IProceduralGenStragery
    {
        public int _birthLimit { get; set; }
        public int _deathLimit { get; set; }
        public int _iterationCount { get; set; }

        public int _activeChanceGround { get; set; }
        public int _activeChanceOnCrust { get; set; }
        public int _activeChanceOnAir { get; set; }

        public int _growthHorizontalChance { get; set; }
        public int _growthVerticalChance { get; set; }

        public int _upperFloorLimit { get; set; }
        public int _lowerFloorLimit { get; set; }

        Random random;

        public OpenPlatformStrategy()
        {
            _birthLimit = 3;
            _deathLimit = 4;
            _iterationCount = 3;

            _activeChanceGround = 10;
            _activeChanceOnCrust = 50;
            _activeChanceOnAir = 199;

            _growthHorizontalChance = 75;
            _growthVerticalChance = 10;

            _lowerFloorLimit = 70;
            _upperFloorLimit = 65;

            random = new Random();
        }

        /// <summary>
        /// Initialize the cave by setting random cells to active;
        /// </summary>
        /// <returns>New initialized map</returns>
        public Cave InitializeCave(Cave cave)
        {
            cave.MakeBlankGrid(true);
            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = 0; y < _upperFloorLimit; y++)
                {
                    if (!cave.IsBorderCell(x, y)){
                        if (!(random.Next(1, 200) < this._activeChanceOnAir)) {
                            cave._celullarMap[x, y] = Utility.WALL;
                        }
                    }
                    else {
                        cave._celullarMap[x, y] = Utility.WALL;
                    }
                }

                for (int y = _upperFloorLimit; y < _lowerFloorLimit; y++)
                {
                    if (!cave.IsBorderCell(x, y)) {
                        if (!(random.Next(1, 100) < this._activeChanceOnCrust)) {
                            cave._celullarMap[x, y] = Utility.WALL;
                        }
                    }
                    else {
                        cave._celullarMap[x, y] = Utility.WALL;
                    }
                }

                for (int y = _lowerFloorLimit; y < Utility.HEIGTH; y++)
                {
                    if(!cave.IsBorderCell(x, y)) {
                        if (!(random.Next(1, 100) < this._activeChanceGround)) {
                            cave._celullarMap[x, y] = Utility.WALL;
                        }
                    }
                    else {
                        cave._celullarMap[x, y] = Utility.WALL;
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
                for (int y = 0; y < _upperFloorLimit; y++)
                {
                    if(!cave.IsBorderCell(x, y)) {
                        if (cave._celullarMap[x, y] == Utility.WALL)
                        {
                            if (random.Next(1, 100) < this._growthHorizontalChance) {

                                copyMap[x - 1, y] = Utility.WALL;
                            }
                            if (random.Next(1, 100) < this._growthHorizontalChance) {
                                copyMap[x + 1, y] = Utility.WALL;
                            }
                            if (random.Next(1, 100) < this._growthVerticalChance){
                                copyMap[x, y + 1] = Utility.WALL;
                            }
                        }
                    }
                }
            }

            for (int x = 0; x < Utility.WIDTH; x++)
            {
                for (int y = _upperFloorLimit; y < Utility.HEIGTH; y++)
                {
                    if (!cave.IsBorderCell(x, y)) {
                        int activeNeighbor = cave.GetSumOfCellActiveNeighbor(x, y);

                        if (cave.IsActive(x, y)) {
                            if (activeNeighbor < _birthLimit) {
                                // Fill the holes
                                copyMap[x, y] = Utility.WALL;
                            }
                        }
                        else {
                            if (activeNeighbor > _deathLimit) {
                                // Destroy small walls
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