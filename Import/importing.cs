using AndelEnergiHovedopgave.Services;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using Microsoft.IdentityModel.Tokens;
using AndelEnergiHovedopgave;
using AndelEnergiHovedopgave.Interfaces;

//Import af services
ICustomerTypeService customerTypeService = new CustomerTypeService(Secret.ConnectionString);
IProductAreaService ProductAreaService = new ProductAreaService(Secret.ConnectionString);
ISalesChannelService salesChannelService = new SalesChannelService(Secret.ConnectionString);
IEventReasonService eventReasonService = new EventReasonService(Secret.ConnectionString);
IEventTypeService eventTypeService = new EventTypeService(Secret.ConnectionString);
ICustomerEventService customerEventService = new CustomerEventService(Secret.ConnectionString);
ImportService importService = new ImportService();

//Connection til databsen åbnes
MySqlConnection connection = new MySqlConnection(Secret.ConnectionString);
connection.Open();


//________________Import af ProductArea fra JSON fil____________________
//string path= "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\Product.txt";
//List<ProductArea> ProductAreas =importService.ReadJasonFromFile<ProductArea>(path);

//foreach(ProductArea p in ProductAreas) 
//{
//    Console.WriteLine(p.ToString());
//    ProductAreaService.InsertWithId(p);
//}

//________________Import af CustomerType fra JSON fil____________________
//string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\Customer.txt";
//List<CustomerType> customerTypes = importService.ReadJasonFromFile<CustomerType>(path);

//foreach (CustomerType c in customerTypes)
//{
//    Console.WriteLine(c.ToString());
//    customerTypeService.InsertWithId(c);
//}

//________________Import af SalesChannel fra JSON fil____________________
//string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\Channels.txt";
//List<SalesChannel> salesChannel = importService.ReadJasonFromFile<SalesChannel>(path);

//foreach (SalesChannel s in salesChannel)
//{
//    Console.WriteLine(s.ToString());
//    salesChannelService.InsertWithId(s);
//}


////________________Import af EventReason fra JSON fil____________________
//string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\CustomerEvents.txt";
//List<CustomerEvent> customerEvents = importService.ReadJasonFromFile<CustomerEvent>(path);

//foreach (CustomerEvent ce in customerEvents)
//{
//    Console.WriteLine(new EventReason(ce.OriginalEventReason).ToString());

//    eventReasonService.Insert(new EventReason(ce.OriginalEventReason));

//}
////________________Import af EventType fra JSON fil____________________
//string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\CustomerEvents.txt";
//List<CustomerEvent> customerEvents = importService.ReadJasonFromFile<CustomerEvent>(path);

//foreach (CustomerEvent ce in customerEvents)
//{
//    Console.WriteLine(new EventType(ce.OriginalEventType).ToString());

//    eventTypeService.Insert(new EventType(ce.OriginalEventType));
//}
//________________Import af CustomerEvent fra JSON fil____________________
string path = "C:\\Users\\johan\\OneDrive\\Skrivebord\\HovedopgaveAndelEnergiMockData\\CustomerEvents.txt";
List<CustomerEvent> customerEvents = importService.ReadJasonFromFile<CustomerEvent>(path);

foreach (CustomerEvent ce in customerEvents)
{
    int eventTypeId = (eventTypeService.GetByType(ce.OriginalEventType)).Id;
    int eventReasonId = (eventReasonService.GetByReason(ce.OriginalEventReason)).Id;
    Console.WriteLine($"Event Type ID: {eventTypeId}, Event Reason ID: {eventReasonId}");
    customerEventService.Insert(new CustomerEvent(ce.DateOfEvent, ce.ProductAreaId, ce.CustomerTypeId, eventTypeId, ce.SalesChannelId ?? 0, eventReasonId, ce.Count));
    Console.WriteLine(ce.ToString());
}


