using _2DProceduralContentGenerator;
using _2DProceduralContentGenerator.AutonomousAgent;
using System.Diagnostics;

namespace _2DProceduralGenerationAlgo.AutonomousAgent
{
    class AARandWalkStrategy : IAutonomousAgent
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public bool _isAlive { get; set; }
        public int _age { get; set; }
        public int _maxLifetime { get; set; }
        public double _lifetimeDeathChance { get; set; }
        public int _minLifetime { get; set; }

        public AARandWalkStrategy(int x, int y)
        {
            this._isAlive = true;
            this._x = x;
            this._y = y;

            this._age = 0;
        }

        public void NextAction()
        {
            if (this._isAlive)
            {
                Move();
                _age++;
            }
        }

        private void Move()
        {
            int number = CustomRandomNumberGenerator.GetRandomInt(1,5);
            Debug.WriteLine(number);

            if (number == 1)
            {
                _y--;
            }
            else if (number == 2)
            {
                _y++;
            }
            else if (number == 3)
            {
                _x--;
            }
            else if (number == 4)
            {
                _x++;
            }
        }
    }
}
