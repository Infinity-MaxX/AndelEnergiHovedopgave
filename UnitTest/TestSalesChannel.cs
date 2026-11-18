using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using AndelEnergiHovedopgave.Services;

namespace UnitTest;

[TestClass]
public class TestSalesChannel
{
    [TestMethod]
    public void GetAll()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService();
        List<SalesChannel> salesChannels = cts.GetAll();

        //Act
        int count = salesChannels.Count;

        //Assert
        Assert.IsNotEmpty(salesChannels);
    }

    [TestMethod]
    public void Insert()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService();
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel("TestSalesChannel");

        //Act
        int countBeforeInsert = salesChannels.Count;
        cts.Insert(newSc);
        SalesChannel foundSc = cts.GetByChannel("TestSalesChannel");
        int countAfterInsert = cts.GetAll().Count;
        cts.Delete(foundSc.Id);

        //Assert
        Assert.IsTrue(newSc.Channel == foundSc.Channel);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }


    [TestMethod]
    public void GetById()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService();
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel(55, "TestSalesChannelGetById");

        //Act
        int countBeforeInsert = salesChannels.Count;
        cts.InsertWithId(newSc);
        SalesChannel foundSc = cts.GetById(newSc.Id);
        int countAfterInsert = cts.GetAll().Count;
        cts.Delete(foundSc.Id);

        //Assert
        Assert.IsTrue(newSc.Id == foundSc.Id);
        Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
    }

}
