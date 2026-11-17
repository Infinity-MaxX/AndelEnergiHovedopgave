using AndelEnergiHovedopgave.Services;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using Microsoft.IdentityModel.Tokens;
using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;

//Import af services
ICustomerTypeService customerTypeService = new CustomerTypeService();
IProductTypeService productTypeService = new ProductTypeService();
ISalesChannelService salesChannelService = new SalesChannelService();
ImportService importService = new ImportService();

//Connection til databsen åbnes
MySqlConnection connection = new MySqlConnection(Secret.ConnectionString);
connection.Open();

//________________Import af ProductType fra JSON fil____________________
List<ProductType> productTypes =importService.ReadJasonFromFile<ProductType>(path);

foreach(ProductType p in productTypes) 
{
    Console.WriteLine(p.ToString());
    //productTypeService.InsertWithId(p);
}

//________________Import af CustomerType fra JSON fil____________________


//________________Import af SalesChannel fra JSON fil____________________



//________________Import af EventReason fra JSON fil____________________



