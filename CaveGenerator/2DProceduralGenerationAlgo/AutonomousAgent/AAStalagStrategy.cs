using _2DProceduralContentGenerator;
using _2DProceduralContentGenerator.AutonomousAgent;

namespace _2DProceduralGenerationAlgo.AutonomousAgent
{
    class AAStalagStrategy : IAutonomousAgent
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public int _age { get; set; }
        public double _lifetimeDeathChance { get; set; }
        public int _minLifetime { get; set; }
        public int _maxLifetime { get; set; }
        public bool _isAlive { get; set; }

        public Utility.DIRECTION _growthDirection { get; set; }
        public int _growthRate { get; set; }

        public AAStalagStrategy(int x, int y, Utility.DIRECTION growthDirection = Utility.DIRECTION.Up, int growthRate = 1)
        {
            this._x = x;
            this._y = y;

            this._isAlive = true;
            this._growthDirection = growthDirection;
            this._growthRate = growthRate;
            this._age = 0;
        }

        public void NextAction()
        {
            if (this._x >= Utility.WIDTH || this._x <= 0 || this._y >= Utility.HEIGTH || this._y <= 0)
            {
                this._isAlive = false;
            }
            if (this._isAlive)
            {
                Move();
                _age++;
            }
        }

        private void Move()
        {
            if (this._age % _growthRate == 0)
            {
                if (_growthDirection == Utility.DIRECTION.Up)
                {
                    _y--;
                }
                else if (_growthDirection == Utility.DIRECTION.Down)
                {
                    _y++;
                }
                else if (_growthDirection == Utility.DIRECTION.Left)
                {
                    _x--;
                }
                else if (_growthDirection == Utility.DIRECTION.Right)
                {
                    _x++;
                }
            }
        }
    }
}
