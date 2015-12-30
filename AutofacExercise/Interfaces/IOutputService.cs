namespace AutofacExercise.Interfaces
{
    internal interface IOutputService
    {
        void PrintExit();
        void PrintInputPrompt();
        void PrintMessage(string message);
        void PrintWelcome();
    }
}