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
        CustomerEvent newCe = new CustomerEvent(1, DateTime.Now, 1, 1, 1, 1, 1);

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
        List<CustomerEvent> customerEvents = ces.GetAll();
        CustomerEvent newCe = new CustomerEvent(1, DateTime.Now, 1, 1, 1, 1, 1);

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
