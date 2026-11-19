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
    public void GetByCustomerType()
    {
        //Arrange
        ICustomerEventService ces = new CustomerEventService();
        ICustomerTypeService ct = new CustomerTypeService();
        CustomerType customertype = ct.GetById(1);

        //Act
        List<CustomerEvent> events = ces.GetByCustomerType(customertype.Type);

        //Assert
        Assert.IsNotEmpty(events);
    }
}
