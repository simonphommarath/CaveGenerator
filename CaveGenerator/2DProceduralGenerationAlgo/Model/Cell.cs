using System;

namespace _2DProceduralGenerationAlgo.Model
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