using _2DProceduralGenerationAlgo.Algorithm;
using _2DProceduralGenerationAlgo.Model;

namespace _2DProceduralGenerationAlgo
{
    public class ProceduralContentGenerator
    {
        public Cave cave { get; set; }

        private IProceduralGenStragery algoStrategy;

        public ProceduralContentGenerator()
        {
            this.SetProceduralGenStrategy(new SimpleCaveStrategy());
            cave = algoStrategy.InitializeCave(new Cave());
        }

        public void SetProceduralGenStrategy(IProceduralGenStragery strategy)
        {
            algoStrategy = strategy;
        }

        public void SetProceduralGenStrategy(string strategyId)
        {
            switch (strategyId)
            {
                case "sc":
                    this.SetProceduralGenStrategy(new SimpleCaveStrategy());
                    break;
                case "gol":
                    this.SetProceduralGenStrategy(new GameOfLifeStrategy());
                    break;
                case "op":
                    this.SetProceduralGenStrategy(new OpenPlatformStrategy());
                    break;
                case "sta":
                    this.SetProceduralGenStrategy(new StalagmiteStrategy());
                    break;
                case "pla":
                    this.SetProceduralGenStrategy(new PlantStrategy());
                    break;
                case "flo":
                    this.SetProceduralGenStrategy(new FloorLevelStrategy());
                    break;
            }
            cave = algoStrategy.InitializeCave(new Cave());
        }

        public void Reset()
        {
            cave.MakeBlankGrid();
            cave = algoStrategy.InitializeCave(new Cave());
        }

        public void DoSingleSimulation()
        {
            cave = algoStrategy.doSimulation(cave);
        }

        public void DoIterationSimulation()
        {
            for (int i = 0; i < algoStrategy._iterationCount; i++)
            {
                cave = algoStrategy.doSimulation(cave);
            }
        }
    }
}