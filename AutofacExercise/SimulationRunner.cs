using Autofac;
using AutofacExercise.Start;

namespace AutofacExercise
{
    class SimulationRunner
    {
        static void Main(string[] args)
        {
            var argumentsParser = new ArgumentsParser(args);
            Config config = argumentsParser.GetConfig();

            var containerSetup = new ContainerSetup();
            IContainer container = containerSetup.BuildContainer(config);
            container.Resolve<Magic8BallSimulator>().Run();
        }
    }
}
