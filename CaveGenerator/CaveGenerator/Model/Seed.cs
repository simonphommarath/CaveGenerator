using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGenerator.Model
{
    class Seed
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public int _growthSpeedNorth { get; set; }
        public int _growthSpeedWest { get; set; }
        public int _growthSpeedEast { get; set; }
        public int _growthSpeedSouth { get; set; }

        public int _growthChanceNorth { get; set; }
        public int _growthChanceWest { get; set; }
        public int _growthChanceEast { get; set; }
        public int _growthChanceSouth { get; set; }

        public Seed(
            int x, 
            int y,
            int growthSpeedNorth = 0,
            int growthSpeedWest = 0,
            int growthSpeedEast = 0,
            int growthSpeedSouth = 0,
            int growthChanceNorth = 0,
            int growthChanceWest = 0,
            int growthChanceEast = 0,
            int growthChanceSouth = 0 )
        {
            this._x = x;
            this._y = y;

            this._growthSpeedNorth = growthSpeedNorth;
            this._growthSpeedWest = growthSpeedWest;
            this._growthSpeedEast = growthSpeedEast;
            this._growthSpeedSouth = growthSpeedSouth;
            this._growthChanceNorth = growthChanceNorth;
            this._growthChanceWest = growthChanceWest;
            this._growthChanceEast = growthChanceEast;
            this._growthChanceSouth = growthChanceSouth;
        }
    }
}