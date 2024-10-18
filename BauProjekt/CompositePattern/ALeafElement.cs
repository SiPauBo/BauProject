namespace BauProjekt.CompositePattern;

public abstract class ALeafElement : IProjectComponent
{
    public string Name { get; private set; }

    protected ALeafElement(string name)
    {
        Name = name;
    }

    public void Add(IProjectComponent component)
    {
        throw new InvalidOperationException("Leaf elements cannot contain other elements.");
    }

    public void Remove(IProjectComponent component)
    {
        throw new InvalidOperationException("Leaf elements cannot contain other elements.");
    }
}