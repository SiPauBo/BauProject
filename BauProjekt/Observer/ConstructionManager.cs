namespace BauProjekt;

public class ConstructionManager : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Construction Manager notified: {message}");
    }
}