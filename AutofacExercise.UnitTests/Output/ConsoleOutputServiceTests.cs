using AutofacExercise.Business.Output;
using AutofacExercise.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutofacExercise.UnitTests.Output
{
    [TestClass]
    public class ConsoleOutputServiceTests
    {
        private readonly ConsoleOutputCapture _consoleOutputCapture = new ConsoleOutputCapture();

        [TestMethod]
        public void MessageIsPrintedByPrintMessage()
        {
            const string message = "This is a test message.";
            _consoleOutputCapture.StartCapture();

            var service = new ConsoleOutputService();
            service.PrintMessage(message);
            var messageFromConsole = _consoleOutputCapture.GetCapturedOutputStripFinalNewline();
            _consoleOutputCapture.StopCapture();

            Assert.AreEqual(message, messageFromConsole);
        }

        [TestMethod]
        public void PrintWelcomePrintsWelcomeMessage()
        {
            const string welcome = "Welcome to the Magic 8 Ball simulator";
            _consoleOutputCapture.StartCapture();

            var service = new ConsoleOutputService();
            service.PrintWelcome();

            var messageFromConsole = _consoleOutputCapture.GetCapturedOutputStripFinalNewline();
            _consoleOutputCapture.StopCapture();

            Assert.AreEqual(welcome, messageFromConsole);
        }

        [TestMethod]
        public void PrintInputPromptPrintsInputPrompt()
        {
            const string welcome = "Ask a Question, or press [Enter] to exit >> ";
            _consoleOutputCapture.StartCapture();

            var service = new ConsoleOutputService();
            service.PrintInputPrompt();

            var messageFromConsole = _consoleOutputCapture.GetCapturedOutputStripFinalNewline();
            _consoleOutputCapture.StopCapture();

            Assert.AreEqual(welcome, messageFromConsole);
        }

        [TestMethod]
        public void PrintExitPrintsExitMessage()
        {
            const string welcome = "Goodbye";
            _consoleOutputCapture.StartCapture();

            var service = new ConsoleOutputService();
            service.PrintExit();

            var messageFromConsole = _consoleOutputCapture.GetCapturedOutputStripFinalNewline();
            _consoleOutputCapture.StopCapture();

            Assert.AreEqual(welcome, messageFromConsole);
        }
    }
}
