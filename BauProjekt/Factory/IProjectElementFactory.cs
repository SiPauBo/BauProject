using BauProjekt.CompositePattern;

namespace BauProjekt.Factory;

public interface IProjectElementFactory<T> where T : IProjectComponent
{
    T Create(string name);
}