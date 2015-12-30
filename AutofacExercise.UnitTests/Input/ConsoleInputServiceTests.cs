using AutofacExercise.Business.Input;
using AutofacExercise.UnitTests.Helpers;
using NUnit.Framework;

namespace AutofacExercise.UnitTests.Input
{
    [TestFixture]
    public class ConsoleInputServiceTests
    {
        private readonly ConsoleInputMock _consoleMock = new ConsoleInputMock();
        private ConsoleInputService _service;

        [Test]
        public void ConsoleInputIsReturnedByGetInput()
        {
            const string testInput = "This is test input.";
            var input = MakeRequest(testInput);

            Assert.AreEqual(testInput, input);
        }

        [Test]
        [TestCase("\r\n")]
        [TestCase("\r")]
        [TestCase("\n")]
        [TestCase(" ")]
        [TestCase("")]
        public void ExitIsRequestedOnValidInput(string testInput)
        {
            MakeRequest(testInput);

            var exitWasRequested = _service.ExitWasRequested();
            Assert.IsTrue(exitWasRequested);
        }

        private string MakeRequest(string testInput)
        {
            _consoleMock.GivenConsoleInputOf(testInput);

            _service = new ConsoleInputService();
            var input = _service.GetInput();
            _consoleMock.CloseConsoleInput();
            return input;
        }
    }
}
