using System;
using AutofacExercise.Business.Interfaces;

namespace AutofacExercise.Business.Input
{
    public class ConsoleInputService : IInputService
    {
        private string _input = "input-initializer";

        public string GetInput()
        {
            _input = Console.ReadLine();
            if (!String.IsNullOrEmpty(_input))
                _input = _input.Trim();
            return _input;
        }

        public bool ExitWasRequested()
        {
            return string.IsNullOrEmpty(_input);
        }
    }
}