namespace BauProjekt.Factory;

public class BuildingFactory : IProjectElementFactory<Building>
{
    public Building Create(string name)
    {
        return new Building(name);
    }
}