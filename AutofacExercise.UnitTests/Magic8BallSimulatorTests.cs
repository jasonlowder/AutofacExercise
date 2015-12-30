using System.Collections.Generic;
using AutofacExercise.Business;
using AutofacExercise.Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutofacExercise.UnitTests
{
    [TestClass]
    public class Magic8BallSimulatorTests
    {
        [TestMethod]
        public void PrintExitIsCalledOnExitRequested()
        {
            // this will be true if PrintExit() is called
            // mock our 3 interfaces
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            // this is cool, we're getting a free mock of IInputService and we can specify
            // how the ExitWasRequested() method will behave by a lambda expression (as you
            // can see, it always returns true
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            // outservice mock
            var outputService = new Mock<IOutputService>();
            var outputServices = new List<IOutputService> {outputService.Object};

            // setup and run our simulator
            var magic8BallSimulator = new Magic8BallSimulator(
                messageService.Object,
                inputService.Object,
                outputServices
            );
            magic8BallSimulator.Run();

            // a simple assertion *verifying* that the PrintExit() method was called
            outputService.Verify(s => s.PrintExit());
        }

        [TestMethod]
        public void GetMessageIsNotCalledAfterExitRequested()
        {
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            var outputService = new Mock<IOutputService>();
            var outputServices = new List<IOutputService> { outputService.Object };

            var magic8BallSimulator = new Magic8BallSimulator(
                messageService.Object,
                inputService.Object,
                outputServices
            );
            // verify that GetMessage() was *not* called
            messageService.Verify(s => s.GetMessage(), Times.Never());
        }

        [TestMethod]
        public void PrintWelcomeIsCalledOnRun()
        {
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            var outputService = new Mock<IOutputService>();
            var outputServices = new List<IOutputService> { outputService.Object };

            var magic8BallSimulator = new Magic8BallSimulator(
                messageService.Object,
                inputService.Object,
                outputServices
            );
            magic8BallSimulator.Run();
            outputService.Verify(s => s.PrintWelcome());
        }

        [TestMethod]
        public void PrintInputPromptIsCalledOnRun()
        {
            var messageService = new Mock<IMessageService>();

            var inputService = new Mock<IInputService>();
            inputService.Setup(s => s.ExitWasRequested()).Returns(true);

            var outputService = new Mock<IOutputService>();
            var outputServices = new List<IOutputService> { outputService.Object };

            var magic8BallSimulator = new Magic8BallSimulator(
                messageService.Object,
                inputService.Object,
                outputServices
            );
            magic8BallSimulator.Run();
            outputService.Verify(s => s.PrintInputPrompt());
        }
    }
}
