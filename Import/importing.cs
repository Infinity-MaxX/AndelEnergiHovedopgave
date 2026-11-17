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
string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\Product.txt";

//________________Import af ProductArea fra JSON fil____________________
List<ProductArea> ProductAreas =importService.ReadJasonFromFile<ProductArea>(path);

foreach(ProductArea p in ProductAreas) 
{
    Console.WriteLine(p.ToString());
    ProductAreaService.InsertWithId(p);
}

//________________Import af CustomerType fra JSON fil____________________


//________________Import af SalesChannel fra JSON fil____________________



//________________Import af EventReason fra JSON fil____________________



