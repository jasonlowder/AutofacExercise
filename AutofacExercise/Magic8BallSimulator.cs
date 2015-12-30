using System.Collections.Generic;
using AutofacExercise.Interfaces;

namespace AutofacExercise
{
    internal class Magic8BallSimulator
    {

        // our "dependencies" are now interfaces
        private readonly IMessageService _messageService;
        private readonly IInputService _inputService;
        private readonly IEnumerable<IOutputService> _outputServices;

        // we're now injecting Interfaces, this loosens our coupling to our "injected" dependencies
        public Magic8BallSimulator(IMessageService messageService, IInputService inputService,
            IEnumerable<IOutputService> outputServices)
        {
            _messageService = messageService;
            _inputService = inputService;
            _outputServices = outputServices;
        }

        public void Run()
        {
            PrintWelcome();
            PrintInputPrompt();
            _inputService.GetInput();

            while (!_inputService.ExitWasRequested())
            {
                var message = _messageService.GetMessage();

                PrintMessage(message);
                PrintInputPrompt();
                _inputService.GetInput();
            }

            PrintExit();
        }

        private void PrintWelcome()
        {
            foreach (var outputService in _outputServices)
                outputService.PrintWelcome();
        }
        private void PrintInputPrompt()
        {
            foreach (var outputService in _outputServices)
                outputService.PrintInputPrompt();
        }
        private void PrintMessage(string message)
        {
            foreach (var outputService in _outputServices)
                outputService.PrintMessage(message);
        }
        private void PrintExit()
        {
            foreach (var outputService in _outputServices)
                outputService.PrintExit();
        }
    }
}