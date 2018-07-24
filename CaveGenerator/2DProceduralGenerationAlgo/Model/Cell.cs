using System;

namespace _2DProceduralContentGenerator.Model
{
    public class Cell
    {
        public Utility.STATE state { get; set; }

        public Cell()
        {
            state = Utility.STATE.Air;
        }
    }
}