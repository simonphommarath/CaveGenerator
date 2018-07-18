using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGenerator.AutonomousAgent
{
    class AASeedStrategy : IAutonomousAgent
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public int _growthChanceNorth { get; set; }
        public int _growthChanceWest { get; set; }
        public int _growthChanceEast { get; set; }
        public int _growthChanceSouth { get; set; }

        public bool _isAlive { get; set; }

        Random rdm;

        public AASeedStrategy( int x, int y, int growthChanceNorth = 50, int growthChanceWest = 25, int growthChanceEast = 25, int growthChanceSouth = 0)
        {
            this._x = x;
            this._y = y;

            this._growthChanceNorth = growthChanceNorth;
            this._growthChanceWest = growthChanceWest;
            this._growthChanceEast = growthChanceEast;
            this._growthChanceSouth = growthChanceSouth;

            this._isAlive = true;
        }

        public void NextPosition()
        {
            rdm = new Random(Guid.NewGuid().GetHashCode());

            if(rdm.Next(1,100) < _growthChanceNorth) {
                this._y--;
            }
            else if (rdm.Next(1, 100) < _growthChanceWest) {
                this._x--;
            } else if (rdm.Next(1, 100) < _growthChanceEast) {
                this._x++;
            }
        }
    }
}