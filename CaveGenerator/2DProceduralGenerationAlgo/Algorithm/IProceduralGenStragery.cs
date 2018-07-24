using _2DProceduralGenerationAlgo.Model;

namespace _2DProceduralGenerationAlgo.Algorithm
{
    public interface IProceduralGenStragery
    {
        int _iterationCount { get; set; }

        Cave InitializeCave(Cave cave);
        Cave doSimulation(Cave cave);
    }
}
