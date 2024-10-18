using NUnit.Framework;
using System.Collections.Generic;
using BauProjekt;
using BauProjekt.CompositePattern;
using BauProjekt.Factory;
using BauProjekt.Logger;

[TestFixture]
public class ProjectTests
{
    private Project project;
    private ProjectManager projectManager;
    private ConstructionManager constructionManager;
    private Building building;
    private Room room;
    private Material material;

    [SetUp]
    public void Setup()
    {
        
        project = new Project();
        projectManager = new ProjectManager();
        constructionManager = new ConstructionManager();
        project.RegisterObserver(projectManager);
        project.RegisterObserver(constructionManager);

        building = new Building("Main Building");
        room = new Room("Office Room");
        material = new Material("Concrete");
    }

    [Test]
    public void Test_Adding_Room_To_Building()
    {
        building.Add(room);
        Assert.Contains(room, building.children);
    }

    [Test]
    public void Test_Removing_Room_From_Building()
    {
        building.Add(room);
        building.Remove(room);
        Assert.IsFalse(building.children.Contains(room));
    }

    [Test]
    public void Test_Adding_Material_To_Room()
    {
        room.Add(material);
        Assert.Contains(material, room.children);
    }

    [Test]
    public void Test_Removing_Material_From_Room()
    {
        room.Add(material);
        room.Remove(material);
        Assert.IsFalse(room.children.Contains(material));
    }

    [Test]
    public void Test_Logger_Singleton_Behavior()
    {
        var logger1 = MyLogger.Instance;
        var logger2 = MyLogger.Instance;
        Assert.AreSame(logger1, logger2, "Logger should be a singleton instance.");
    }


    [Test]
    public void Test_ProjectManager_Notification()
    {
        project.NotifyObservers("Project Updated");
 
    }

    [Test]
    public void Test_ConstructionManager_Notification()
    {
        project.NotifyObservers("Building Added");

    }

    [Test]
    public void Test_Factory_Creates_Building()
    {
        var factory = new BuildingFactory();
        var createdBuilding = factory.Create("Test Building");
        Assert.IsNotNull(createdBuilding);
        Assert.AreEqual("Test Building", createdBuilding.Name);
    }

    [Test]
    public void Test_Factory_Creates_Garden()
    {
        var factory = new GardenFactory();
        var createdGarden = factory.Create("Test Garden");
        Assert.IsNotNull(createdGarden);
        Assert.AreEqual("Test Garden", createdGarden.Name);
    }

    [Test]
    public void Test_Observer_Notification_When_Adding_Components()
    {
    
        ProjectManager pm = new ProjectManager();
        ConstructionManager cm = new ConstructionManager();
        project.RegisterObserver(pm);
        project.RegisterObserver(cm);

     
        var building = project.CreateAndAdd("New Building", new BuildingFactory());
        Assert.DoesNotThrow(() => project.NotifyObservers("Building Added"));
    }

    [Test]
    public void Test_Project_Logger_Writes_To_File()
    {
        MyLogger.Instance.Log("Test logging to file");
        MyLogger.Instance.WriteLogToFile("test_log.txt");
       
        Assert.AreEqual(0, MyLogger.Instance.MessageCount, "Logger should reset after writing to file.");
    }

    
    [Test]
    public void Test_Removing_Non_Existent_Room_From_Building_Does_Not_Throw()
    {
        Room nonExistentRoom = new Room("NonExistentRoom");
        Assert.DoesNotThrow(() => building.Remove(nonExistentRoom));
    }
}
