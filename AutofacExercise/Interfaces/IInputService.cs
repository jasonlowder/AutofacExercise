namespace AutofacExercise.Interfaces
{
    internal interface IInputService
    {
        bool ExitWasRequested();
        string GetInput();
    }
}