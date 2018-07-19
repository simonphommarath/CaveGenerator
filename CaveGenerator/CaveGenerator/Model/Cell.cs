using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveGenerator.Model
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