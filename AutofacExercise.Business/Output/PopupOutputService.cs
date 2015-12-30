using System.Windows.Forms;
using AutofacExercise.Business.Interfaces;

namespace AutofacExercise.Business.Output
{
    public class PopupOutputService : IOutputService
    {
        public void PrintExit()
        {
            MessageBox.Show("Thanks for using the Magic 8-Ball Simulator", "Goodbye");
        }

        public void PrintInputPrompt()
        {
            MessageBox.Show("Ask a Question, or press [Enter] to exit >>", "Info");
        }

        private string _message = string.Empty;

        public void PrintMessage(string message)
        {
            _message = message;
            MessageBox.Show(_message, "The 8-Ball says");
        }

        public void PrintWelcome()
        {
            MessageBox.Show("Welcome to the Magic 8 Ball simulator", "Hello");
        }
    }
}