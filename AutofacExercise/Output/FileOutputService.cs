using System.IO;
using AutofacExercise.Interfaces;

namespace AutofacExercise.Output
{
    internal class FileOutputService : IOutputService
    {
        private readonly string _outputFilePath;

        public FileOutputService(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
        }

        public void PrintExit()
        {
            File.AppendAllText(_outputFilePath, "Thanks for using the Magic 8-Ball Simulator");
        }

        public void PrintInputPrompt()
        {
            File.AppendAllText(_outputFilePath, "Ask a Question, or press [Enter] to exit >>");
        }

        private string _message = string.Empty;

        public void PrintMessage(string message)
        {
            _message = message;
            File.AppendAllText(_outputFilePath, _message);
        }

        public void PrintWelcome()
        {
            File.AppendAllText(_outputFilePath, "Welcome to the Magic 8 Ball simulator");
        }
    }
}