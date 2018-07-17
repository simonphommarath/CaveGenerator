using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaveGenerator;
using CaveGenerator.Model;

namespace CaveGenerator.Algorithm
{
    interface IProceduralGenStragery
    {
        int _iterationCount { get; set; }

        Cave doSimulation(Cave cave);
        Cave InitializeCave(Cave cave);
    }
}
