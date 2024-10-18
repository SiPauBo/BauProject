using BauProjekt.CompositePattern;

namespace BauProjekt.Factory;

public class RoomFactory : IProjectElementFactory<Room>
{
    public Room Create(string name)
    {
        return new Room(name);
    }
}