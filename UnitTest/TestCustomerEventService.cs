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
        ICustomerEventService ces = new CustomerEventService();
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
        ICustomerEventService ces = new CustomerEventService();
        List<CustomerEvent> customerEvents = ces.GetAll();
        CustomerEvent newCe = new CustomerEvent(200, new DateTime(2026,1,1), 1, 1, 1,1, 1, 1);

        //Act
        int countBeforeInsert = customerEvents.Count;
        ces.Insert(newCe);
        CustomerEvent foundCe = ces.GetById(newCe.Id);
        int countAfterInsert = ces.GetAll().Count;
        ces.Delete(foundCe.Id);

        //Assert
        Assert.IsTrue(newCe.Id == foundCe.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }


    [TestMethod]
    public void GetById()
    {
        //Arrange
        ICustomerEventService ces = new CustomerEventService();
        IEventReasonService eventReasonService = new EventReasonService();
        IEventTypeService eventTypeService = new EventTypeService();
        List<CustomerEvent> customerEvents = ces.GetAll();
        int eventTypeId = eventTypeService.GetByType("GA").Id;
        int eventReasonId = eventReasonService.GetByReason("move in").Id;
        CustomerEvent newCe = new CustomerEvent(201,new DateTime(2023, 1, 1),1,1,eventTypeId,1,eventReasonId,1);

        //Act
        int countBeforeInsert = customerEvents.Count;
        ces.Insert(newCe);
        CustomerEvent foundCe = ces.GetById(newCe.Id);
        int countAfterInsert = ces.GetAll().Count;
        ces.Delete(foundCe.Id);

        //Assert
        Assert.IsTrue(newCe.Id == foundCe.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }
}
