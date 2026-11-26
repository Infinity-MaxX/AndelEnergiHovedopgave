using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using AndelEnergiHovedopgave.Services;

namespace UnitTest;

[TestClass]
public class TestProductArea
{
    [TestMethod]
    public void GetAll()
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService(Secret.TestConnectionString);
        List<ProductArea> productAreas = pas.GetAll();

        //Act
        int count = productAreas.Count;

        //Assert
        Assert.IsNotEmpty(productAreas);
        Assert.IsTrue(count > 0);

    }

    [TestMethod]
    public void Insert()
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService(Secret.TestConnectionString);
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea("TestProductAreaInsert");

        //Act
        int countBeforeInsert = productAreas.Count;
        ProductArea insertedArea = pas.Insert(newPa);

        int countAfterInsert = pas.GetAll().Count;

        pas.Delete(insertedArea.Id);

        //Assert
        Assert.IsTrue(newPa.Area == insertedArea.Area);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }

    [TestMethod]
    public void GetById()
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService(Secret.TestConnectionString);
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea(5, "TestProductAreaGetById");

        //Act
        int countBeforeInsert = productAreas.Count;

        ProductArea insertedArea = pas.InsertWithId(newPa);
        ProductArea foundPa = pas.GetById(newPa.Id);

        int countAfterInsert = pas.GetAll().Count;
        pas.Delete(newPa.Id);

        //Assert
        Assert.IsTrue(newPa.Id == foundPa.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }
    [TestMethod]
    public void Delete()
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService(Secret.TestConnectionString);
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea(5, "TestDelete");

        //Act
        ProductArea insertedArea = pas.InsertWithId(newPa);

        int countBeforeInsert = productAreas.Count;

        pas.Delete(insertedArea.Id);
        int countAfterInsert = pas.GetAll().Count;
       

        //Assert
        Assert.IsTrue(newPa.Id == insertedArea.Id);
        Assert.AreEqual(countBeforeInsert, countAfterInsert);
    }

    [TestMethod]
    public void GetByArea() 
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService(Secret.TestConnectionString);
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea("TestGetByArea");

        //Act
        ProductArea insertedArea = pas.Insert(newPa);
        ProductArea foundArea = pas.GetByArea(newPa.Area);

        //Assert
        Assert.AreEqual(newPa.Area,foundArea.Area);
        Assert.AreEqual(insertedArea.Id,foundArea.Id);
    }
    [TestMethod]
    public void ProductAreaExists()
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService(Secret.TestConnectionString);
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea(5, "TestGetByArea");

        //Act
        pas.InsertWithId(newPa);
        bool ProductExists = pas.ProductAreaExists(newPa);
        pas.Delete(newPa.Id);

        //Assert
        Assert.IsTrue(ProductExists);
    }

}
