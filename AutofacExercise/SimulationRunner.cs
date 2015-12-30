using System.IO;
using AutofacExercise.Input;
using AutofacExercise.Messages;
using AutofacExercise.Output;

namespace AutofacExercise
{
    class SimulationRunner
    {
        static void Main(string[] args)
        {
            // output file for new output-service
            var outputFilePath = Path.Combine(Path.GetTempPath(), "magic8BallOutput.txt");

            var simulator = new Magic8BallSimulator(
                new MessageService(),
                new ConsoleInputService(),
                new MultipleOutputService(outputFilePath) // new odd output class
            );
            simulator.Run();
        }
    }
}
