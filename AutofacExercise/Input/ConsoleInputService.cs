using System;
using AutofacExercise.Interfaces;

namespace AutofacExercise.Input
{
    internal class ConsoleInputService : IInputService
    {
        private string _input = "input-initializer";

        public string GetInput()
        {
            _input = Console.ReadLine();
            return _input;
        }

        public bool ExitWasRequested()
        {
            return string.IsNullOrEmpty(_input);
        }
    }
}