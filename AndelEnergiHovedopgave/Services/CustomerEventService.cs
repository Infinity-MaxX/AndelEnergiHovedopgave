using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using Microsoft.Data.SqlClient.Internal;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AndelEnergiHovedopgave.Services
{
    public class CustomerEventService : ICustomerEventService
    {  
        private string _connectionString;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly ISalesChannelService _salesChannelService;
        private readonly IProductAreaService _productAreaService;
        private readonly IEventReasonService _eventReasonService;
        private readonly IEventTypeService _eventTypeService;


        //Actions
        private string getAll = "SELECT * FROM CustomerEvents";
        private string insert = "INSERT INTO CustomerEvents (DateOfEvent, ProductAreaId, CustomerTypeId, EventTypeId, SalesChannelId, EventReasonId, EventCount) VALUES (@DateOfEvent,  @ProductAreaId, @CustomerTypeId, @EventTypeId, @SalesChannelId, @EventReasonId, @EventCount)";
        private string delete = "DELETE FROM CustomerEvents  WHERE Id = @Id";

        //Search queries
        private string getById = "SELECT * FROM CustomerEvents  WHERE Id = @Id";
        private string getByCustomerType = "SELECT * FROM CustomerEvents  WHERE CustomerTypeId = @CustomerTypeId";
        private string getByDate = "SELECT * FROM CustomerEvents  WHERE DateOfEvent = @DateOfEvent";
        private string getByReason = "SELECT * FROM CustomerEvents  WHERE EventReasonId = @EventReasonId";
        private string getByEventType = "SELECT * FROM CustomerEvents  WHERE EventTypeId = @EventTypeId";
        private string getBySalesChannel = "SELECT * FROM CustomerEvents  WHERE SalesChannelId = @SalesChannelId";
        private string getByProductArea = "SELECT * FROM CustomerEvents  WHERE ProductAreaId = @ProductAreaId";
        private string existsCustomerEvents = "SELECT COUNT(*) FROM CustomerEvents  WHERE DateOfEvent = @DateOfEvent AND ProductAreaId = @ProductAreaId AND CustomerTypeId = @CustomerTypeId AND EventTypeId = @EventTypeId AND SalesChannelId = @SalesChannelId AND EventReasonId = @EventReasonId";

        public CustomerEventService(string connectionstring)
        {
            _connectionString = connectionstring ?? throw new ArgumentNullException(nameof(connectionstring));
            _customerTypeService = new CustomerTypeService(_connectionString);
            _salesChannelService = new SalesChannelService(_connectionString);
            _productAreaService = new ProductAreaService(_connectionString);
            _eventReasonService = new EventReasonService(_connectionString);
            _eventTypeService = new EventTypeService(_connectionString);
        }
        public List<CustomerEvent> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(getAll, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                DateTime dateOfEvent = reader.GetDateTime(1);
                                int productAreaId = reader.GetInt32(2);
                                int customerTypeId = reader.GetInt32(3);
                                int eventTypeId = reader.GetInt32(4);
                                int salesChannelId = reader.GetInt32(5);
                                int eventReasonId = reader.GetInt32(6);
                                int count = reader.GetInt32(7);
                                CustomerEvent customerEvent = new CustomerEvent(id, dateOfEvent, productAreaId, customerTypeId,eventTypeId ,salesChannelId , eventReasonId, count);
                                customerEvents.Add(customerEvent);

                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer types:{ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer types: {ex.Message}");
                }
                return customerEvents;
            }
        }
        

        public List<CustomerEvent> GetByCustomerType(string customerType)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try
                {
                    int foundCustomerTypeId = (_customerTypeService.GetByType(customerType)).Id;
                    MySqlCommand command = new MySqlCommand(getByCustomerType, connection);
                    command.Parameters.AddWithValue("@CustomerTypeId", foundCustomerTypeId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int productAreaId = reader.GetInt32(2);
                            int customerTypeId = reader.GetInt32(3);
                            int eventTypeId = reader.GetInt32(4);
                            int salesChannelId = reader.GetInt32(5);
                            int eventReasonId = reader.GetInt32(6);
                            int count = reader.GetInt32(7);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent,productAreaId, customerTypeId,eventTypeId, salesChannelId, eventReasonId, count));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by type: {ex.Message}");
                }
                return customerEvents;
            }
        }

        public List<CustomerEvent> GetByEventType(string eventType)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try
                {
                    int foundEventTypeId = (_eventTypeService.GetByType(eventType)).Id;
                    MySqlCommand command = new MySqlCommand(getByEventType, connection);
                    command.Parameters.AddWithValue("@EventTypeId", foundEventTypeId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int productAreaId = reader.GetInt32(2);
                            int customerTypeId = reader.GetInt32(3);
                            int eventTypeId = reader.GetInt32(4);
                            int salesChannelId = reader.GetInt32(5);
                            int eventReasonId = reader.GetInt32(6);
                            int count = reader.GetInt32(7);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent, productAreaId, customerTypeId, eventTypeId, salesChannelId, eventReasonId, count));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by type: {ex.Message}");
                }
                return customerEvents;
            }
        }
        
        public List<CustomerEvent> GetByDate(DateTime month)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try
                {
                    MySqlCommand command = new MySqlCommand(getByDate, connection);
                    command.Parameters.AddWithValue("@DateOfEvent", month);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int productAreaId = reader.GetInt32(2);
                            int customerTypeId = reader.GetInt32(3);
                            int eventTypeId = reader.GetInt32(4);
                            int salesChannelId = reader.GetInt32(5);
                            int eventReasonId = reader.GetInt32(6);
                            int count = reader.GetInt32(7);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent, productAreaId, customerTypeId, eventTypeId, salesChannelId, eventReasonId, count));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by type: {ex.Message}");
                }
                return customerEvents;
            }

        }

        public CustomerEvent GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                CustomerEvent foundCustomerEvent = new CustomerEvent();
                try
                {
                    MySqlCommand command = new MySqlCommand(getById, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int foundId = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int productAreaId = reader.GetInt32(2);
                            int customerTypeId = reader.GetInt32(3);
                            int eventTypeId = reader.GetInt32(4);
                            int salesChannelId = reader.GetInt32(5);
                            int eventReasonId = reader.GetInt32(6);
                            int count = reader.GetInt32(7);
                            foundCustomerEvent = new CustomerEvent(foundId, dateOfEvent,productAreaId, customerTypeId, eventTypeId, salesChannelId, eventReasonId, count);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by type: {ex.Message}");
                }
                return foundCustomerEvent;
            }
        }

        public List<CustomerEvent> GetByReason(string reason)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try
                {
                    int foundReasonId = (_eventReasonService.GetByReason(reason)).Id;
                    MySqlCommand command = new MySqlCommand(getByReason, connection);
                    command.Parameters.AddWithValue("@EventReasonId", foundReasonId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int productAreaId = reader.GetInt32(2);
                            int customerTypeId = reader.GetInt32(3);
                            int eventTypeId = reader.GetInt32(4);
                            int salesChannelId = reader.GetInt32(5);
                            int eventReasonId = reader.GetInt32(6);
                            int count = reader.GetInt32(7);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent,productAreaId, customerTypeId, eventTypeId, salesChannelId, eventReasonId, count));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by type: {ex.Message}");
                }
                return customerEvents;
            }
        }

        public List <CustomerEvent> GetBySalesChannel(string salesChannel)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try
                {
                    int foundSalesChannelId = (_salesChannelService.GetByChannel(salesChannel)).Id;
                    MySqlCommand command = new MySqlCommand(getBySalesChannel, connection);
                    command.Parameters.AddWithValue("@SalesChannelId", foundSalesChannelId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int productAreaId = reader.GetInt32(2);
                            int customerTypeId = reader.GetInt32(3);
                            int eventTypeId = reader.GetInt32(4);
                            int salesChannelId = reader.GetInt32(5);
                            int eventReasonId = reader.GetInt32(6);
                            int count = reader.GetInt32(7);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent,productAreaId ,customerTypeId,eventTypeId ,salesChannelId, eventReasonId, count));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by type: {ex.Message}");
                }
                return customerEvents;
            }
        }

        public CustomerEvent Insert(CustomerEvent customerEvent)
        {
            if(CustomerEventExists(customerEvent))
            {
                return customerEvent;
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insert, connection);

                    command.Parameters.AddWithValue("@DateOfEvent", customerEvent.DateOfEvent);
                    command.Parameters.AddWithValue("@ProductAreaId", customerEvent.ProductAreaId);
                    command.Parameters.AddWithValue("@CustomerTypeId", customerEvent.CustomerTypeId);
                    command.Parameters.AddWithValue("@EventTypeId", customerEvent.EventTypeId);
                    command.Parameters.AddWithValue("@SalesChannelId", customerEvent.SalesChannelId);
                    command.Parameters.AddWithValue("@EventReasonId", customerEvent.EventReasonId);
                    command.Parameters.AddWithValue("@EventCount", customerEvent.Count);

                    command.ExecuteNonQuery();
                    customerEvent.Id = Convert.ToInt32(command.LastInsertedId);

                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while inserting customer event: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while inserting customer event: {ex.Message}");
                }
            }
            return customerEvent;
        }

        public List<CustomerEvent> GetByProductArea(string productArea)
        {
            using(MySqlConnection conection = new MySqlConnection(_connectionString))
            {
                List<CustomerEvent> customerEvents = new List<CustomerEvent>();
                try 
                {
                    MySqlCommand command = new MySqlCommand(getByProductArea, conection);
                    int foundProductAreaId = (_productAreaService.GetByArea(productArea)).Id;
                    command.Parameters.AddWithValue("@ProductAreaId", foundProductAreaId);
                    conection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        int id = reader.GetInt32(0);
                        DateTime dateOfEvent = reader.GetDateTime(1);
                        int productAreaId = reader.GetInt32(2);
                        int customerTypeId = reader.GetInt32(3);
                        int eventTypeId = reader.GetInt32(4);
                        int salesChannelId = reader.GetInt32(5);
                        int eventReasonId = reader.GetInt32(6);
                        int count = reader.GetInt32(7);
                        customerEvents.Add(new CustomerEvent(id, dateOfEvent, productAreaId, customerTypeId, eventTypeId, salesChannelId, eventReasonId, count));
                    }

                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer event by product area: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer event by product area: {ex.Message}");
                }
                return customerEvents;
            }
        }


        public void Delete(int id)
        { 
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(delete, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while deleting customer event: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer event: {ex.Message}");
                }
            }
        }

        public bool CustomerEventExists(CustomerEvent customerEvent)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(existsCustomerEvents, connection);
                    command.Parameters.AddWithValue("@DateOfEvent", customerEvent.DateOfEvent);
                    command.Parameters.AddWithValue("@ProductAreaId", customerEvent.ProductAreaId);
                    command.Parameters.AddWithValue("@CustomerTypeId", customerEvent.CustomerTypeId);
                    command.Parameters.AddWithValue("@EventTypeId", customerEvent.EventTypeId);
                    command.Parameters.AddWithValue("@SalesChannelId", customerEvent.SalesChannelId);
                    command.Parameters.AddWithValue("@EventReasonId", customerEvent.EventReasonId);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while checking if customer event exists: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while checking if customer event exists: {ex.Message}");
                }
            }
        }
    }
}
