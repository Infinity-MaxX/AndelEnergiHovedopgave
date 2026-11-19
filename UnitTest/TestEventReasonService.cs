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
        IEventReasonService evs = new EventReasonService();
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
        IEventReasonService evs = new EventReasonService();
        List<EventReason> eventReasons = evs.GetAll();
        EventReason newEr = new EventReason("TestEventReasonInsert");

        //Act
        int countBeforeInsert = eventReasons.Count;
        evs.Insert(newEr);
        EventReason foundevr = evs.GetByReason("TestEventReasonInsert");
        int countAfterInsert = evs.GetAll().Count;
        evs.Delete(foundevr.Id);

        //Assert
        Assert.IsTrue(newEr.Reason == foundevr.Reason);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }

    [TestMethod]
    public void GetById()
    {
        //Arrange
        IEventReasonService evs = new EventReasonService();
        List<EventReason> eventReasons = evs.GetAll();
        EventReason newEr = new EventReason("TestEventReasonGetById");

        //Act
        int countBeforeInsert = eventReasons.Count;
        evs.Insert(newEr);
        EventReason foundevr = evs.GetByReason(newEr.Reason);
        EventReason foundevrid = evs.GetById(foundevr.Id);
        int countAfterInsert = evs.GetAll().Count;
        evs.Delete(foundevr.Id);

        //Assert
        Assert.IsTrue(foundevr.Id == foundevrid.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }
    [TestMethod]
    public void GetByReason()
    {
        //Arrange
        IEventReasonService er = new EventReasonService();
        EventReason reason = new EventReason("Test");

        //Act
        er.Insert(reason);
        EventReason foundReason = er.GetByReason(reason.Reason);
        er.Delete(reason.Id);

        //Assert
        Assert.AreEqual(reason.Reason, foundReason.Reason);
    }
    [TestMethod]
    public void Delete()
    {
        //Arrange
        IEventReasonService er = new EventReasonService();
        List<EventReason> reasons = er.GetAll();
        EventReason reason = new EventReason("Test");

        //Act
        int countBeforeInsert = reasons.Count;
        er.Insert(reason);

        EventReason foundEr = er.GetByReason("Test");
        er.Delete(foundEr.Id);

        int countAfterInsert = er.GetAll().Count;

        //Assert
        Assert.IsTrue(reason.Reason == foundEr.Reason);
        Assert.AreEqual(countBeforeInsert, countAfterInsert);
    }
}
