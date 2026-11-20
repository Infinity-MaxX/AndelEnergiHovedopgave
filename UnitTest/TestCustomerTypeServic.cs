namespace UnitTest
{
    using AndelEnergiHovedopgave.Interfaces;
    using AndelEnergiHovedopgave.Models;
    using AndelEnergiHovedopgave.Services;
    using Microsoft.AspNetCore.Authentication.OAuth.Claims;

    [TestClass]
    public sealed class TestCustomerTypeServic
    {
        [TestMethod]
        public void GetAll()
        {
            //Arrange
            ICustomerTypeService cts = new CustomerTypeService();
            List<CustomerType> customerTypes = cts.GetAll();

            //Act
            int count = customerTypes.Count;

            //Assert
            Assert.IsNotEmpty(customerTypes);
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void Insert()
        {
            //Arrange
            ICustomerTypeService cts = new CustomerTypeService();
            List<CustomerType> customerTypes = cts.GetAll();
            CustomerType newCt = new CustomerType("TestCustomerTypeInsert");

            //Act
            int countBeforeInsert = customerTypes.Count;
            cts.Insert(newCt);
            CustomerType foundCt= cts.GetByType("TestCustomerTypeInsert");
            int countAfterInsert = cts.GetAll().Count;
            cts.Delete(foundCt.Id);

            //Assert
            Assert.IsTrue(newCt.Type == foundCt.Type);
            Assert.AreEqual((countBeforeInsert+1), countAfterInsert);
        }


        [TestMethod]
        public void GetById()
        {
            //Arrange
            ICustomerTypeService cts = new CustomerTypeService();
            List<CustomerType> customerTypes = cts.GetAll();
            CustomerType newCt = new CustomerType(5,"TestCustomerTypeGetById");

            //Act
            int countBeforeInsert = customerTypes.Count;
            cts.InsertWithId(newCt);
            CustomerType foundCt = cts.GetById(newCt.Id);
            int countAfterInsert = cts.GetAll().Count;
            cts.Delete(foundCt.Id);

            //Assert
            Assert.IsTrue(newCt.Id == foundCt.Id);
            Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
        }

        [TestMethod]
        public void GetByType() 
        {
            //Arrange
            ICustomerTypeService ct = new CustomerTypeService();
            CustomerType type = new CustomerType("Test");

            //Act
            ct.Insert(type);
            CustomerType foundType = ct.GetByType(type.Type);

            //Assert
            Assert.AreEqual(type.Type, foundType.Type);
        }
        [TestMethod]
        public void Delete()
        {
            //Arrange
            ICustomerTypeService cts = new CustomerTypeService();
            List<CustomerType> customerTypes = cts.GetAll();
            CustomerType newCt = new CustomerType("TestCustomerTypeInsert");

            //Act
            int countBeforeInsert = customerTypes.Count;
            cts.Insert(newCt);

            CustomerType foundCt = cts.GetByType("TestCustomerTypeInsert");
            cts.Delete(foundCt.Id);

            int countAfterInsert = cts.GetAll().Count;
            
            //Assert
            Assert.IsTrue(newCt.Type == foundCt.Type);
            Assert.AreEqual(countBeforeInsert, countAfterInsert);
        }
        [TestMethod]
        public void EventReasonExists()
        {
            //Arrange
            ICustomerTypeService cts = new CustomerTypeService();
            List<CustomerType> customerTypes = cts.GetAll();
            CustomerType newCt = new CustomerType(80,"TestCustomerTypeInsert");

            //Act
            cts.InsertWithId(newCt);
            bool typelExists = cts.CustomerTypeTypeExists(newCt);
            cts.Delete(newCt.Id);

            //Assert
            Assert.IsTrue(typelExists);
        }
    }


}
