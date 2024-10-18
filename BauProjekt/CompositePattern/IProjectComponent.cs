namespace BauProjekt.CompositePattern;

public interface IProjectComponent
{
    string Name { get; }
    void Add(IProjectComponent component);
    void Remove(IProjectComponent component);
}