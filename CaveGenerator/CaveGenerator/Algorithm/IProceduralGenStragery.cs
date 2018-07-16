using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave
{
    interface IProceduralGenStragery
    {
        int _iterationCount { get; set; }

        Cave doSimulation(Cave cave);
        Cave InitializeCave(Cave cave);
    }
}
