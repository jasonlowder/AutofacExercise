using System;
using System.IO;

namespace AutofacExercise.UnitTests.Helpers
{
    public class ConsoleOutputCapture
    {
        private StringWriter _consoleOutputReader;

        public void StartCapture()
        {
            if (_consoleOutputReader != null)
                StopCapture();

            _consoleOutputReader = new StringWriter();
            Console.SetOut(_consoleOutputReader);
        }

        public string GetCapturedOutput()
        {
            return _consoleOutputReader.ToString();
        }
        public string GetCapturedOutputStripFinalNewline()
        {
            var output = _consoleOutputReader.ToString();
            if (output.EndsWith(Environment.NewLine))
                output = output.Substring(0, output.LastIndexOf(Environment.NewLine, StringComparison.Ordinal));

            return output;
        }

        public void StopCapture()
        {
            _consoleOutputReader.Close();
            _consoleOutputReader.Dispose();
            _consoleOutputReader = null;
        }
    }
}
