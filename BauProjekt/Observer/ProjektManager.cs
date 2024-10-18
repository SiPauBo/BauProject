namespace BauProjekt;

public class ProjectManager : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Project Manager notified: {message}");
    }
}