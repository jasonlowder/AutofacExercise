namespace AutofacExercise.Business.Interfaces
{
    public interface IInputService
    {
        bool ExitWasRequested();
        string GetInput();
    }
}