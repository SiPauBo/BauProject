namespace BauProjekt.CompositePattern;

public abstract class ACompositeElement : IProjectComponent
{
    public string Name { get; private set; }
    public List<IProjectComponent> children = new List<IProjectComponent>();

    protected ACompositeElement(string name)
    {
        Name = name;
    }

    public virtual void Add(IProjectComponent component)
    {
        children.Add(component);
    }

    public virtual void Remove(IProjectComponent component)
    {
        children.Remove(component);
    }
}