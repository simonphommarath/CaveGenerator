using _2DProceduralContentGenerator.Model;

namespace _2DProceduralContentGenerator.Algorithm
{
    public interface IProceduralGenStragery
    {
        int _iterationCount { get; set; }

        Cave InitializeCave(Cave cave);
        Cave doSimulation(Cave cave);
    }
}
