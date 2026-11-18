using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class CustomerEventService : ICustomerEventService
    {
        private string _connectionString = Secret.ConnectionString;
        private readonly ICustomerTypeService _customerTypeService;
        private readonly ISalesChannelService _salesChannelService;
        private readonly IProductAreaService _productAreaService;
        private readonly IEventReasonService _eventReasonService;


        //Actions
        private string getAll = "SELECT * FROM CustomerEvents";
        private string insert = "INSERT INTO CustomerEvents (DateOfEvent, CustomerTypeId, ProductAreaId, SalesChannelId, EventReasonId, EventCount) VALUES (@DateOfEvent, @CustomerTypeId, @ProductAreaId, @SalesChannelId, @EventReasonId, @EventCount)";
        private string delete = "DELETE FROM CustomerEvents  WHERE Id = @Id";

        //Search queries
        private string getById = "SELECT * FROM CustomerEvents  WHERE Id = @Id";
        private string getByCustomerType = "SELECT * FROM CustomerEvents  WHERE CustomerTypeId = @CustomerTypeId";
        private string getByDate = "SELECT * FROM CustomerEvents  WHERE DateOfEvent = @DateOfEvent";
        private string getByReason = "SELECT * FROM CustomerEvents  WHERE EventReasonId = @EventReasonId";
        private string getBySalesChannel = "SELECT * FROM CustomerEvents  WHERE SalesChannelId = @SalesChannelId";
        private string existsCustomerEvents = "SELECT COUNT(*) FROM CustomerEvents  WHERE CustomerTypeId = @CustomerTypeId";



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
                                int customerTypeId = reader.GetInt32(2);
                                int productAreaId = reader.GetInt32(3);
                                int salesChannelId = reader.GetInt32(4);
                                int eventReasonId = reader.GetInt32(5);
                                int eventCount = reader.GetInt32(6);
                                int count = reader.GetInt32(7);
                                CustomerEvent customerEvent = new CustomerEvent(id,dateOfEvent,customerTypeId,productAreaId,salesChannelId, eventReasonId, count);
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
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int customerTypeId = reader.GetInt32(2);
                            int productAreaId = reader.GetInt32(3);
                            int salesChannelId = reader.GetInt32(4);
                            int eventReasonId = reader.GetInt32(5);
                            int count = reader.GetInt32(6);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent, customerTypeId, productAreaId, salesChannelId, eventReasonId, count));
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
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int customerTypeId = reader.GetInt32(2);
                            int productAreaId = reader.GetInt32(3);
                            int salesChannelId = reader.GetInt32(4);
                            int eventReasonId = reader.GetInt32(5);
                            int count = reader.GetInt32(6);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent, customerTypeId, productAreaId, salesChannelId, eventReasonId, count));
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
                            int customerTypeId = reader.GetInt32(2);
                            int productAreaId = reader.GetInt32(3);
                            int salesChannelId = reader.GetInt32(4);
                            int eventReasonId = reader.GetInt32(5);
                            int count = reader.GetInt32(6);
                            foundCustomerEvent = new CustomerEvent(foundId, dateOfEvent, customerTypeId, productAreaId, salesChannelId, eventReasonId, count);
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
                    MySqlCommand command = new MySqlCommand(getByCustomerType, connection);
                    command.Parameters.AddWithValue("@CustomerTypeId", foundReasonId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int customerTypeId = reader.GetInt32(2);
                            int productAreaId = reader.GetInt32(3);
                            int salesChannelId = reader.GetInt32(4);
                            int eventReasonId = reader.GetInt32(5);
                            int count = reader.GetInt32(6);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent, customerTypeId, productAreaId, salesChannelId, eventReasonId, count));
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
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime dateOfEvent = reader.GetDateTime(1);
                            int customerTypeId = reader.GetInt32(2);
                            int productAreaId = reader.GetInt32(3);
                            int salesChannelId = reader.GetInt32(4);
                            int eventReasonId = reader.GetInt32(5);
                            int count = reader.GetInt32(6);
                            customerEvents.Add(new CustomerEvent(id, dateOfEvent, customerTypeId, productAreaId, salesChannelId, eventReasonId, count));
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
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insert, connection);

                    command.Parameters.AddWithValue("@DateOfEvent", customerEvent.DateOfEvent);
                    command.Parameters.AddWithValue("@CustomerTypeId", customerEvent.CustomerTypeId);
                    command.Parameters.AddWithValue("@ProductAreaId", customerEvent.ProductAreaId);
                    command.Parameters.AddWithValue("@SalesChannelId", customerEvent.SalesChannelId);
                    command.Parameters.AddWithValue("@EventReasonId", customerEvent.EventReasonId);
                    command.Parameters.AddWithValue("@Count", customerEvent.Count);
                    command.ExecuteNonQuery();
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
                    command.Parameters.AddWithValue("@CustomerTypeId", customerEvent.CustomerTypeId);
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
