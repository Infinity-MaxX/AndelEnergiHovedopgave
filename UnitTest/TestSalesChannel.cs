using AndelEnergiHovedopgave;
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
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();

        //Act
        int count = salesChannels.Count;

        //Assert
        Assert.IsNotEmpty(salesChannels);
        Assert.IsTrue(count > 0);

    }

    [TestMethod]
    public void Insert()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel("TestSalesChannel");

        //Act
        int countBeforeInsert = salesChannels.Count;
        cts.Insert(newSc);
        SalesChannel foundSc = cts.GetByChannel("TestSalesChannel");
        cts.Delete(foundSc.Id);
        int countAfterInsert = cts.GetAll().Count;


        //Assert
        Assert.AreEqual(countBeforeInsert, countAfterInsert);
    }
    
    [TestMethod]
    public void Delete()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel(55,"TestSalesChannel");

        //Act
        cts.InsertWithId(newSc);
        int countBefore = salesChannels.Count;

        cts.Delete(newSc.Id);
        int countAfter = cts.GetAll().Count;


        //Assert
        Assert.AreEqual(countBefore,countAfter);
    }

    [TestMethod]
    public void GetByChannel()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel(57, "TestSalesChannelGetByChannel");

        //Act
        cts.InsertWithId(newSc);
        SalesChannel foundSc = cts.GetByChannel(newSc.Channel);
        cts.Delete(newSc.Id);

        //Assert
        Assert.IsTrue(newSc.Id == foundSc.Id);
    }

    [TestMethod]
    public void GetById()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel(56, "TestSalesChannelGetById");

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
    [TestMethod]
    public void salesChannelAreaExists()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel(57, "TestSalesChannelGetById");

        //Act
        cts.InsertWithId(newSc);
        bool ChannelExists = cts.SalesChannelTypeExists(newSc);
        cts.Delete(newSc.Id);

        //Assert
        Assert.IsTrue(ChannelExists);
    }

}
