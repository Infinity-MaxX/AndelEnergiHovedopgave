using AndelEnergiHovedopgave.Services;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using Microsoft.IdentityModel.Tokens;
using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;

//Import af services
ICustomerTypeService customerTypeService = new CustomerTypeService();
IProductAreaService ProductAreaService = new ProductAreaService();
ISalesChannelService salesChannelService = new SalesChannelService();
ImportService importService = new ImportService();

//Connection til databsen åbnes
MySqlConnection connection = new MySqlConnection(Secret.ConnectionString);
connection.Open();

//
string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\Channels.txt";

//________________Import af ProductArea fra JSON fil____________________
//List<ProductArea> ProductAreas =importService.ReadJasonFromFile<ProductArea>(path);

//foreach(ProductArea p in ProductAreas) 
//{
//    Console.WriteLine(p.ToString());
//    ProductAreaService.InsertWithId(p);
//}

//________________Import af CustomerType fra JSON fil____________________
//List<CustomerType> customerTypes = importService.ReadJasonFromFile<CustomerType>(path);

//foreach (CustomerType c in customerTypes)
//{
//    Console.WriteLine(c.ToString());
//    customerTypeService.InsertWithId(c);
//}

//________________Import af SalesChannel fra JSON fil____________________
List<SalesChannel> salesChannel = importService.ReadJasonFromFile<SalesChannel>(path);

foreach (SalesChannel s in salesChannel)
{
    Console.WriteLine(s.ToString());
    salesChannelService.InsertWithId(s);
}


//________________Import af EventReason fra JSON fil____________________



