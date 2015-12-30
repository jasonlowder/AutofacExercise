using AutofacExercise.Interfaces;

namespace AutofacExercise
{
    internal class Magic8BallSimulator
    {
        // our "dependencies" are now interfaces
        private readonly IMessageService _messageService;
        private readonly IInputService _inputService;
        private readonly IOutputService _outputService;

        // we're now injecting Interfaces, this loosens our coupling to our "injected" dependencies
        public Magic8BallSimulator(IMessageService messageService, IInputService inputService,
            IOutputService outputService)
        {
            _messageService = messageService;
            _inputService = inputService;
            _outputService = outputService;
        }

        public void Run()
        {
            _outputService.PrintWelcome();
            string message = string.Empty;

            _outputService.PrintInputPrompt();
            _inputService.GetInput();

            while (!_inputService.ExitWasRequested())
            {
                message = _messageService.GetMessage();
                _outputService.PrintMessage(message);
                _outputService.PrintInputPrompt();
                _inputService.GetInput();
            }

            _outputService.PrintExit();
        }
    }
}