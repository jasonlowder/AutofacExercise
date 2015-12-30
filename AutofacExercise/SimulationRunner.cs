using Autofac;
using AutofacExercise.Start;
using AutofacExercise.Startup;
using AutofacExercise.Business;

namespace AutofacExercise
{
    internal class SimulationRunner
    {
        private static void Main(string[] args)
        {
            var argumentsParser = new ArgumentsParser(args);
            var config = argumentsParser.GetConfig();

            var containerSetup = new ContainerSetup();
            var container = containerSetup.BuildContainer(config);
            container.Resolve<Magic8BallSimulator>().Run();
        }
    }
}
