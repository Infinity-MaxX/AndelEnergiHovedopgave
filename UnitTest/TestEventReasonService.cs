using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using AndelEnergiHovedopgave.Services;

namespace UnitTest;

[TestClass]
public class TestEventReasonService
{

    [TestMethod]
    public void GetAll()
    {
        //Arrange
        IEventReasonService evs = new EventReasonService(Secret.TestConnectionString);
        List<EventReason> eventReasons = evs.GetAll();

        //Act
        int count = eventReasons.Count;

        //Assert
        Assert.IsNotEmpty(eventReasons);
        Assert.IsTrue(count > 0);
    }

    [TestMethod]
    public void Insert()
    {
        //Arrange
        IEventReasonService evs = new EventReasonService(Secret.TestConnectionString);
        List<EventReason> eventReasons = evs.GetAll();
        EventReason newEr = new EventReason("TestEventReasonInsert");

        //Act
        int countBeforeInsert = eventReasons.Count;
        EventReason insertedReason = evs.Insert(newEr);

        int countAfterInsert = evs.GetAll().Count;
        evs.Delete(insertedReason.Id);

        //Assert
        Assert.IsTrue(newEr.Reason == insertedReason.Reason);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }

    [TestMethod]
    public void GetById()
    {
        //Arrange
        IEventReasonService evs = new EventReasonService(Secret.TestConnectionString);
        List<EventReason> eventReasons = evs.GetAll();
        EventReason newEr = new EventReason("TestEventReasonGetById");

        //Act
        int countBeforeInsert = eventReasons.Count;
        EventReason insertedReason = evs.Insert(newEr);

        EventReason foundevrid = evs.GetById(insertedReason.Id);

        int countAfterInsert = evs.GetAll().Count;
        evs.Delete(insertedReason.Id);

        //Assert
        Assert.IsTrue(insertedReason.Id == foundevrid.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }
    [TestMethod]
    public void GetByReason()
    {
        //Arrange
        IEventReasonService er = new EventReasonService(Secret.TestConnectionString);
        EventReason reason = new EventReason("Test");

        //Act
        EventReason insertedReason = er.Insert(reason);
        EventReason foundReason = er.GetByReason(insertedReason.Reason);

        er.Delete(insertedReason.Id);

        //Assert
        Assert.AreEqual(insertedReason.Reason, foundReason.Reason);
    }

    [TestMethod]
    public void Delete()
    {
        //Arrange
        IEventReasonService er = new EventReasonService(Secret.TestConnectionString);
        List<EventReason> reasons = er.GetAll();
        EventReason reason = new EventReason("Test");

        //Act
        int countBeforeInsert = reasons.Count;
        EventReason insertedReason = er.Insert(reason);

        er.Delete(insertedReason.Id);

        int countAfterInsert = er.GetAll().Count;

        //Assert
        Assert.IsTrue(reason.Reason == insertedReason.Reason);
        Assert.AreEqual(countBeforeInsert, countAfterInsert);
    }
    [TestMethod]
    public void EventReasonExists()
    {
        //Arrange
        IEventReasonService er = new EventReasonService(Secret.TestConnectionString);
        List<EventReason> reasons = er.GetAll();
        EventReason reason = new EventReason("TestExists");

        //Act
        er.Insert(reason);
        EventReason eventReason = er.GetByReason(reason.Reason);
        bool reasonlExists = er.EventReasonExists(eventReason);
        er.Delete(reason.Id);

        //Assert
        Assert.IsTrue(reasonlExists);
    }
}
