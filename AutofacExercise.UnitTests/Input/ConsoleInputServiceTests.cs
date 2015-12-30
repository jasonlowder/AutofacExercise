using System;
using AutofacExercise.Business.Input;
using AutofacExercise.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutofacExercise.UnitTests.Input
{
    [TestClass]
    public class ConsoleInputServiceTests
    {
        private readonly ConsoleInputMock _consoleMock = new ConsoleInputMock();

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ConsoleInputIsReturnedByGetInput()
        {
            const string testInput = "This is test input.";
            _consoleMock.GivenConsoleInputOf(testInput);

            var service = new ConsoleInputService();
            var input = service.GetInput();
            _consoleMock.CloseConsoleInput();

            Assert.AreEqual(testInput, input);
        }

        [TestMethod]
        public void ExitIsRequestedOnNewlineInput()
        {
            _consoleMock.GivenConsoleInputOf(Environment.NewLine);

            var service = new ConsoleInputService();
            service.GetInput();
            _consoleMock.CloseConsoleInput();

            var exitWasRequested = service.ExitWasRequested();
            Assert.IsTrue(exitWasRequested);
        }

        [TestMethod]
        public void ExitIsRequestedOnEmptyInput()
        {
            _consoleMock.GivenConsoleInputOf(String.Empty);

            var service = new ConsoleInputService();
            service.GetInput();
            _consoleMock.CloseConsoleInput();

            var exitWasRequested = service.ExitWasRequested();
            Assert.IsTrue(exitWasRequested);
        }

        [TestMethod]
        public void ExitIsRequestedOnWhitespaceInput()
        {
            _consoleMock.GivenConsoleInputOf(" ");

            var service = new ConsoleInputService();
            service.GetInput();
            _consoleMock.CloseConsoleInput();

            var exitWasRequested = service.ExitWasRequested();
            Assert.IsTrue(exitWasRequested);
        }
    }
}
