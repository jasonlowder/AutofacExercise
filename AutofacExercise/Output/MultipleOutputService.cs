using System;
using System.IO;
using System.Windows.Forms;
using AutofacExercise.Interfaces;

namespace AutofacExercise.Output
{
    internal class MultipleOutputService : IOutputService
    {
        private readonly string _outputFilePath;

        public MultipleOutputService(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
        }

        public void PrintExit()
        {
            MessageBox.Show("Thanks for using the Magic 8-Ball Simulator", "Goodbye");
        }

        public void PrintInputPrompt()
        {
            Console.WriteLine("Ask a Question, or press [Enter] to exit >>");
        }

        private string _message = string.Empty;

        public void PrintMessage(string message)
        {
            _message = message;
            WriteMessageToConsole();
            WriteMessageToFile();
            ShowMessagePopup();
        }

        private void WriteMessageToConsole()
        {
            Console.WriteLine(_message);
        }

        private void WriteMessageToFile()
        {
            File.AppendAllText(_outputFilePath, _message);
        }

        // because they're not enough popups in our lives :)
        private void ShowMessagePopup()
        {
            MessageBox.Show(_message, "The 8-Ball says");
        }

        public void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Magic 8 Ball simulator");
        }
    }
}