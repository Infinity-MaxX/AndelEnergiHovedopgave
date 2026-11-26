using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using AndelEnergiHovedopgave.Services;

namespace UnitTest;

[TestClass]
public class TestCustomerEventService
{
    [TestMethod]
    public void GetAll()
    {
        //Arrange
        ICustomerEventService ces = new CustomerEventService(Secret.TestConnectionString);
        List<CustomerEvent> customerEvents = ces.GetAll();

        //Act
        int count = customerEvents.Count;

        //Assert
        Assert.IsNotEmpty(customerEvents);
        Assert.IsTrue(count > 0);

    }
    [TestMethod]
    public void Insert()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        List<CustomerEvent> customerEvents = ce.GetAll();
        CustomerEvent customerEvent = new CustomerEvent(new DateTime(2001,1,1),1,1,1,1,6,100);

        //Act
        int countBefore = customerEvents.Count();
        ce.Insert(customerEvent);

        int countAfter = ce.GetAll().Count();

        CustomerEvent foundEvent = (ce.GetByDate(customerEvent.DateOfEvent))[0];
        ce.Delete(foundEvent.Id);

        //Assert
        Assert.AreEqual(countBefore+1,countAfter);
    }
    [TestMethod]
    public void Delete()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        List<CustomerEvent> customerEvents = ce.GetAll();
        CustomerEvent customerEvent = new CustomerEvent(new DateTime(2001, 1, 1), 1, 1, 1, 1, 6, 101);

        //Act
        ce.Insert(customerEvent);
        int countBefore = customerEvents.Count();

        CustomerEvent foundEvent = (ce.GetByDate(customerEvent.DateOfEvent))[0];
        ce.Delete(foundEvent.Id);
        int countAfter = ce.GetAll().Count();

        //Assert
        Assert.AreEqual(countBefore, countAfter);
    }
    [TestMethod]
    public void GetById() 
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        ICustomerTypeService ct = new CustomerTypeService(Secret.TestConnectionString);
        CustomerType type = ct.GetById(1);
        DateTime date = new DateTime(2005, 1, 1);
        CustomerEvent newEvents = new CustomerEvent(date, 1, 1, 1, 1, 7, 102);

        //Act
        ce.Insert(newEvents);

        CustomerEvent foundEvent = ce.GetByDate(date)[0];
        int foundId = (ce.GetById(foundEvent.Id)).Id;

        //Assert
        Assert.AreEqual(foundEvent.Id, foundId);
    }
    [TestMethod]
    public void GetByCustomerType()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        ICustomerTypeService ct = new CustomerTypeService(Secret.TestConnectionString);
        CustomerType testCT = new CustomerType( "testType");
        CustomerType insertedCT = ct.Insert(testCT);
        List<CustomerEvent> customerEvents = ce.GetAll();
        CustomerType type = ct.GetById(1);
        List<CustomerEvent> newEvents = new List<CustomerEvent> { new CustomerEvent(new DateTime(2002, 1, 1), 1, 1, 1, 1, 7, 102), new CustomerEvent(new DateTime(2002, 1, 1), 1, 1, 1, 1, 8, 103) };

        //Act
        ce.Insert(newEvents[0]);
        ce.Insert(newEvents[1]);

        List<CustomerEvent> foundEvents = ce.GetByCustomerType(type.Type);

        ce.Delete(newEvent.Id);
        ce.Delete(newEvent2.Id);
        ct.Delete(insertedCT.Id);

        //Assert
        Assert.AreEqual(foundEvents[0].CustomerTypeId, type.Id);
        Assert.AreEqual(foundEvents[0].CustomerTypeId, type.Id);
    }
    [TestMethod]
    public void GetByDate()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        List<CustomerEvent> customerEvents = ce.GetAll();
        DateTime date = new DateTime(2001, 1, 1);
        List<CustomerEvent> newEvents = new List<CustomerEvent>{new CustomerEvent(date,1, 1, 1, 1, 7, 102),new CustomerEvent(date,1, 1, 1, 1, 8, 103)};

        //Act
        ce.Insert(newEvents[0]);
        ce.Insert(newEvents[1]);

        List<CustomerEvent> foundEvents = ce.GetByDate(date);

        ce.Delete(foundEvents[0].Id);
        ce.Delete(foundEvents[1].Id);

        //Assert
        Assert.AreEqual(foundEvents[0].DateOfEvent, date);
        Assert.AreEqual(foundEvents[1].DateOfEvent, date);
    }
    [TestMethod]
    public void GetByEventType()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        IEventTypeService et = new EventTypeService(Secret.TestConnectionString);
        List<CustomerEvent> customerEvents = ce.GetAll();
        EventType type = et.GetByType("Ga");
        List<CustomerEvent> newEvents = new List<CustomerEvent> { new CustomerEvent(new DateTime(2002, 1, 1), 1, 1, type.Id, 1, 7, 102), new CustomerEvent(new DateTime(2002, 1, 1), 1, 1, type.Id, 1, 8, 103) };

        //Act
        ce.Insert(newEvents[0]);
        ce.Insert(newEvents[1]);

        List<CustomerEvent> foundEvents = ce.GetBygetByEventType(type.Type);

        ce.Delete(foundEvents[0].Id);
        ce.Delete(foundEvents[1].Id);

        //Assert
        Assert.AreEqual(foundEvents[0].EventTypeId, type.Id);
        Assert.AreEqual(foundEvents[0].EventTypeId, type.Id);
    }
    [TestMethod]
    public void GetByEventReason()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        IEventReasonService er = new EventReasonService(Secret.TestConnectionString);
        List<CustomerEvent> customerEvents = ce.GetAll();
        EventReason reason = er.GetByReason("move in");
        List<CustomerEvent> newEvents = new List<CustomerEvent> { new CustomerEvent(new DateTime(2002, 1, 1), 1, 1, 1, 1,reason.Id , 102), new CustomerEvent(new DateTime(2002, 1, 1), 1, 1,1, 1, reason.Id, 103) };

        //Act
        ce.Insert(newEvents[0]);
        ce.Insert(newEvents[1]);

        List<CustomerEvent> foundEvents = ce.GetByReason(reason.Reason);

        ce.Delete(foundEvents[0].Id);
        ce.Delete(foundEvents[1].Id);

        //Assert
        Assert.AreEqual(foundEvents[0].EventReasonId, reason.Id);
        Assert.AreEqual(foundEvents[0].EventReasonId, reason.Id);
    }
    [TestMethod]
    public void CustomerExistsExists()
    {
        //Arrange
        ICustomerEventService ce = new CustomerEventService(Secret.TestConnectionString);
        IEventReasonService er = new EventReasonService(Secret.TestConnectionString);
        EventTypeService et = new EventTypeService(Secret.TestConnectionString);

        List<CustomerEvent> customerEvents = ce.GetAll();
        EventType type = et.GetByType("Ga");
        EventReason reason = er.GetByReason("move in");
        DateTime date = new DateTime(2004, 1, 1);
        CustomerEvent newEvent = new CustomerEvent(92,date, 1, 1, type.Id, 1, reason.Id, 102);

        //Act
        ce.Insert(newEvent);
        bool doseExist = ce.CustomerEventExists(newEvent);

        int foundId = (ce.GetByDate(date))[0].Id;
        ce.Delete(foundId);

        //Assert
        Assert.IsTrue(doseExist);
    }

}
