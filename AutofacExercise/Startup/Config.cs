using System.Collections.Generic;

namespace AutofacExercise.Start
{
    // an enumeration expressing our different output modes
    public enum OutputModes { Console, Popup, File, All };

    // holds our configuration, this class will be easy to expand later on
    // if we need to
    internal class Config
    {
        public List<OutputModes> OutputModes { get; private set; }

        public Config(List<OutputModes> outputPreferences)
        {
            OutputModes = outputPreferences;
        }
    }
}