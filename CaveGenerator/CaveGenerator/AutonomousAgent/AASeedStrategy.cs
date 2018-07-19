using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGenerator.AutonomousAgent
{
    /// <summary>
    /// A seed is an autonomous agent that tends to go toward one direction.
    /// </summary>
    public class AASeedStrategy : IAutonomousAgent
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public int _growthChanceNorth { get; set; }
        public int _growthChanceWest { get; set; }
        public int _growthChanceEast { get; set; }
        public int _growthChanceSouth { get; set; }

        public bool _isAlive { get; set; }
        public int _age { get; set; }
        public int _lifetimeDeathChance { get; set; }
        public int _maxLifetime { get; set; }
        public int _minLifetime { get; set; }

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
            this._age = 0;
            this._lifetimeDeathChance = 5;
            this._minLifetime = 60;
            this._maxLifetime = 160;
        }

        public void NextAction()
        {
            rdm = new Random(Guid.NewGuid().GetHashCode());

            if (_age > _maxLifetime) {
                this._isAlive = false;
            }
            else if (_age > _minLifetime && _age < _maxLifetime)
            {
                if (rdm.Next(1, 100) < _lifetimeDeathChance) {
                    this._isAlive = false;
                }
                else {
                    Move();
                }
            }
            else {
                Move();
            }
            _age++;
        }

        void Move()
        {
            if (rdm.Next(1, 100) < _growthChanceNorth) {
                this._y--;
            }
            else if (rdm.Next(1, 100) < _growthChanceWest) {
                this._x--;
            }
            else if (rdm.Next(1, 100) < _growthChanceEast) {
                this._x++;
            }
        }
    }
}