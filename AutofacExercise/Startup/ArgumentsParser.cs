using System;
using System.Collections.Generic;

namespace AutofacExercise.Start
{
    internal class ArgumentsParser
    {
        private readonly string[] _arguments;

        // default output mode when no args specified
        private List<OutputModes> _outputModes = new List<OutputModes>() { OutputModes.Console };

        public ArgumentsParser(string[] args)
        {
            _arguments = args;
        }

        public Config GetConfig()
        {
            SanityCheckArgs();

            return new Config(_outputModes);
        }

        private void SanityCheckArgs()
        {
            // no-args to check
            if (_arguments.Length == 0)
                return;

            // too many args
            if (_arguments.Length > 3)
                throw new ArgumentException(
                    "Too many arguments were specified, expected 'console','popup','file', or 'all'");

            SetupOutputModes();
        }

        private void SetupOutputModes()
        {
            _outputModes = new List<OutputModes>();

            // see if each requested output-mode exists in our struct
            foreach (var outputModeRequested in _arguments)
            {
                try
                {
                    _outputModes.Add(
                        (OutputModes)Enum.Parse(typeof(OutputModes), outputModeRequested, true)
                    );
                }
                catch
                {
                    throw new ArgumentException(String.Format(
                        "Illegal output mode '{0}' requested, expected 'console','popup','file', or 'all'",
                        outputModeRequested));
                }
            }
            // handles odd input like "console all"
            if (_outputModes.Contains(OutputModes.All))
                _outputModes = new List<OutputModes>() { OutputModes.All };
        }
    }
}