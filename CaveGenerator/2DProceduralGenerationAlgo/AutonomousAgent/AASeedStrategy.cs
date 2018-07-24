namespace _2DProceduralGenerationAlgo.AutonomousAgent
{
    /// <summary>
    /// A seed is an autonomous agent that tends to go toward one direction.
    /// </summary>
    public class AASeedStrategy : IAutonomousAgent
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public double _growthChanceNorth { get; set; }
        public double _growthChanceWest { get; set; }
        public double _growthChanceEast { get; set; }
        public double _growthChanceSouth { get; set; }

        public bool _isAlive { get; set; }
        public int _age { get; set; }
        public double _lifetimeDeathChance { get; set; }
        public int _maxLifetime { get; set; }
        public int _minLifetime { get; set; }

        public AASeedStrategy( int x, int y, double growthChanceNorth = 0.50, double growthChanceWest = 0.25, double growthChanceEast = 0.25, double growthChanceSouth = 0)
        {
            this._x = x;
            this._y = y;

            this._growthChanceNorth = growthChanceNorth;
            this._growthChanceWest = growthChanceWest;
            this._growthChanceEast = growthChanceEast;
            this._growthChanceSouth = growthChanceSouth;

            this._isAlive = true;
            this._age = 0;
            this._lifetimeDeathChance = 0.5;
            this._minLifetime = 60;
            this._maxLifetime = 160;
        }

        public void NextAction()
        {
            if (this._isAlive)
            {
                if (_age > _maxLifetime)
                {
                    this._isAlive = false;
                }
                else if (_age > _minLifetime && _age < _maxLifetime)
                {
                    if (RandomNumberGenerator.GetRandom() < _lifetimeDeathChance)
                    {
                        this._isAlive = false;
                    }
                    else
                    {
                        Move();
                    }
                }
                else
                {
                    Move();
                }
                _age++;
            }
        }

        private void Move()
        {
            if (this._age == 0)
            {
                this._y--;
            }
            else
            {
                if (RandomNumberGenerator.GetRandom() < _growthChanceNorth)
                {
                    this._y--;
                }
                else if (RandomNumberGenerator.GetRandom() < _growthChanceWest)
                {
                    this._x--;
                }
                else if (RandomNumberGenerator.GetRandom() < _growthChanceEast)
                {
                    this._x++;
                }
            }
        }
    }
}