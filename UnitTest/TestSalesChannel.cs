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
        SalesChannel insertedChannel = cts.Insert(newSc);

        int countAfterInsert = cts.GetAll().Count;
        cts.Delete(insertedChannel.Id);


        //Assert
        Assert.AreEqual(countBeforeInsert+1, countAfterInsert);
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
        SalesChannel newSc = new SalesChannel("TestSalesChannelGetByChannel");

        //Act
        SalesChannel insertedChannel = cts.Insert(newSc);
        SalesChannel foundSc = cts.GetByChannel(newSc.Channel);

        cts.Delete(insertedChannel.Id);

        //Assert
        Assert.AreEqual(insertedChannel.Id,foundSc.Id);
        Assert.AreEqual(insertedChannel.Channel,foundSc.Channel);
    }

    [TestMethod]
    public void GetById()
    {
        //Arrange
        ISalesChannelService cts = new SalesChannelService(Secret.TestConnectionString);
        List<SalesChannel> salesChannels = cts.GetAll();
        SalesChannel newSc = new SalesChannel("TestSalesChannelGetById");

        //Act
        int countBeforeInsert = salesChannels.Count;

        SalesChannel insertedChannel = cts.Insert(newSc);
        SalesChannel foundSc = cts.GetById(insertedChannel.Id);

        int countAfterInsert = cts.GetAll().Count;
        cts.Delete(insertedChannel.Id);

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
