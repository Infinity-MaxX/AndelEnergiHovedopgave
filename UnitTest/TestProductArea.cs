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
        IProductAreaService pas = new ProductAreaService();
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
        IProductAreaService pas = new ProductAreaService();
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea("TestProductAreaInsert");

        //Act
        int countBeforeInsert = productAreas.Count;
        pas.Insert(newPa);
        ProductArea foundPa = pas.GetByArea("TestProductAreaInsert");
        int countAfterInsert = pas.GetAll().Count;
        pas.Delete(foundPa.Id);

        //Assert
        Assert.IsTrue(newPa.Area == foundPa.Area);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }

    [TestMethod]
    public void GetById()
    {
        //Arrange
        IProductAreaService pas = new ProductAreaService();
        List<ProductArea> productAreas = pas.GetAll();
        ProductArea newPa = new ProductArea(5, "TestProductAreaGetById");

        //Act
        int countBeforeInsert = productAreas.Count;
        pas.InsertWithId(newPa);
        ProductArea foundPa = pas.GetById(newPa.Id);
        int countAfterInsert = pas.GetAll().Count;
        pas.Delete(foundPa.Id);

        //Assert
        Assert.IsTrue(newPa.Id == foundPa.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }

}
