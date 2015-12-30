using System;

namespace AutofacExercise
{
    internal class ConsoleInputService
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