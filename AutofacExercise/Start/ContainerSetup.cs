using System.IO;
using Autofac;
using AutofacExercise.Input;
using AutofacExercise.Interfaces;
using AutofacExercise.Messages;
using AutofacExercise.Output;

namespace AutofacExercise.Start
{
    internal class ContainerSetup
    {
        private ContainerBuilder _builder;
        private Config _config;

        public IContainer BuildContainer(Config config)
        {
            _config = config;
            _builder = new ContainerBuilder();

            // in English this reads, setup ConsoleInputService as the implementation of 
            // IInputService
            _builder.RegisterType<ConsoleInputService>().As<IInputService>();

            // Magic8BallSimulator doesn't implement an interface, its registered as-is
            _builder.RegisterType<Magic8BallSimulator>();
            _builder.RegisterType<MessageService>().As<IMessageService>();

            // we're now registering N IOutputServices based on our passed config configuration 
            // class
            if (_config.OutputModes.Contains(OutputModes.Console) || _config.OutputModes.Contains(OutputModes.All))
                _builder.RegisterType<ConsoleOutputService>().As<IOutputService>();

            if (_config.OutputModes.Contains(OutputModes.Popup) || _config.OutputModes.Contains(OutputModes.All))
                _builder.RegisterType<PopupOutputService>().As<IOutputService>();

            if (_config.OutputModes.Contains(OutputModes.File) || _config.OutputModes.Contains(OutputModes.All))
            {
                var outputFilePath = Path.Combine(Path.GetTempPath(), "magic8BallOutput.txt");
                _builder.Register(c => new FileOutputService(outputFilePath)).As<IOutputService>();
            }

            return _builder.Build();
        }
    }
}