using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using AndelEnergiHovedopgave.Services;

namespace UnitTest;

[TestClass]
public class TestEventTypeService
{
    [TestMethod]
    public void GetAll()
    {
        //Arrange
        IEventTypeService ets = new EventTypeService(Secret.TestConnectionString);
        List<EventType> EventTypes = ets.GetAll();

        //Act
        int count = EventTypes.Count;

        //Assert
        Assert.IsNotEmpty(EventTypes);
        Assert.IsTrue(count > 0);
    }

    [TestMethod]
    public void Insert()
    {
        //Arrange
        IEventTypeService ets = new EventTypeService(Secret.TestConnectionString);
        List<EventType> EventTypes = ets.GetAll();
        EventType newEt = new EventType("TestEventTypeInsert");

        //Act
        int countBeforeInsert = EventTypes.Count;
        EventType insertedType = ets.Insert(newEt);

        int countAfterInsert = ets.GetAll().Count;

        ets.Delete(insertedType.Id);

        //Assert
        Assert.IsTrue(newEt.Type == insertedType.Type);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }


    [TestMethod]
    public void GetById()
    {
        //Arrange
        IEventTypeService ct = new EventTypeService(Secret.TestConnectionString);
        EventType type = new EventType("Test");

        //Act
        EventType insertedType = ct.Insert(type);
        EventType foundEvent = (ct.GetById(insertedType.Id));
        
        ct.Delete(insertedType.Id);

        //Assert
        Assert.AreEqual(insertedType.Id, foundEvent.Id);
    }

    [TestMethod]
    public void GetByType()
    {
        //Arrange
        IEventTypeService ct = new EventTypeService(Secret.TestConnectionString);
        EventType type = new EventType("Test");

        //Act
        EventType insertedType = ct.Insert(type);
        EventType foundType = ct.GetByType(type.Type);

        ct.Delete(insertedType.Id);

        //Assert
        Assert.AreEqual(insertedType.Type, foundType.Type);
    }
    [TestMethod]
    public void Delete()
    {
        //Arrange
        IEventTypeService ets = new EventTypeService(Secret.TestConnectionString);
        List<EventType> EventTypes = ets.GetAll();
        EventType newCt = new EventType("TestEventTypeInsert");

        //Act
        int countBeforeInsert = EventTypes.Count;
        EventType insertedType = ets.Insert(newCt);

        ets.Delete(insertedType.Id);

        int countAfterInsert = ets.GetAll().Count;

        //Assert
        Assert.IsTrue(newCt.Type == insertedType.Type);
        Assert.AreEqual(countBeforeInsert, countAfterInsert);
    }

    [TestMethod]
    public void EventReasonExists()
    {
        //Arrange
        IEventTypeService ets = new EventTypeService(Secret.TestConnectionString);
        List<EventType> EventTypes = ets.GetAll();
        EventType newCt = new EventType("TestEventTypeInsert");

        //Act
        ets.Insert(newCt);
        EventType foundEventType = ets.GetByType(newCt.Type); 
        bool typelExists = ets.EventTypeExists(foundEventType);
        
        ets.Delete(foundEventType.Id);

        //Assert
        Assert.IsTrue(typelExists);
    }
}
