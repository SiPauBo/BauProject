using BauProjekt.CompositePattern;
using BauProjekt.Factory;
using BauProjekt.Logger;

namespace BauProjekt;

public class Project
{
    private List<IObserver> observers = new List<IObserver>();
    private List<IProjectComponent> components = new List<IProjectComponent>();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void AddComponent(IProjectComponent component)
    {
        components.Add(component);
        NotifyObservers($"{component.Name} added to project.");
        MyLogger.Instance.Log($"{component.Name} was added.");
    }

    public void RemoveComponent(IProjectComponent component)
    {
        components.Remove(component);
        NotifyObservers($"{component.Name} removed from project.");
        MyLogger.Instance.Log($"{component.Name} was removed.");
    }

    public T CreateAndAdd<T>(string name, IProjectElementFactory<T> factory) where T : IProjectComponent
    {
        T component = factory.Create(name);
        AddComponent(component);
        return component;
    }
}
