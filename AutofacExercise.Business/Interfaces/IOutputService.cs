namespace AutofacExercise.Business.Interfaces
{
    public interface IOutputService
    {
        void PrintExit();
        void PrintInputPrompt();
        void PrintMessage(string message);
        void PrintWelcome();
    }
}