using System;
using System.IO;

namespace AutofacExercise.UnitTests.Helpers
{
    public class ConsoleInputMock
    {
        private StringReader _consoleInputReader;

        // sets up the Console with a given input string
        public void GivenConsoleInputOf(string consoleInput)
        {
            if (_consoleInputReader != null)
                CloseConsoleInput();

            _consoleInputReader = new StringReader(consoleInput);
            Console.SetIn(_consoleInputReader);
        }

        public void CloseConsoleInput()
        {
            _consoleInputReader.Close();
            _consoleInputReader.Dispose();
            _consoleInputReader = null;
        }
    }
}
