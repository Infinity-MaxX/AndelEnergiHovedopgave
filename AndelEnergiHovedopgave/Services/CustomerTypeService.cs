using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private string _connectionString = Secret.ConnectionString;
        private string getAll = "SELECT * FROM CustomerType";
        private string insert = "INSERT INTO CustomerType (Type) VALUES (@Type)";
        private string getById = "SELECT * FROM CustomerType WHERE Id = @Id";
     

        public List<CustomerType> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString)) 
            {
                List<CustomerType> customerTypes = new List<CustomerType>();
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
                                string type = reader.GetString(1);
                                CustomerType customerType = new CustomerType(id, type);
                                customerTypes.Add(customerType);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer types:{ex.Message}");
                }
                catch(Exception ex) 
                {
                    throw new Exception($"An error occurred while retrieving customer types: {ex.Message}");
                }
                return customerTypes;
            }
        }

        public CustomerType GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString)) 
            {
                CustomerType foundCustomerType = new CustomerType();
                try 
                {
                    using (MySqlCommand comand = new MySqlCommand(getById)) 
                    {
                        comand.Parameters.AddWithValue("@Id", id);
                        connection.Open();

                        MySqlDataReader reader = comand.ExecuteReader();
                        if (reader.Read()) 
                        {
                            int customerId = reader.GetInt32("Id");
                            string customerType= reader.GetString("Type");
                            foundCustomerType= new CustomerType(customerId, customerType);
                        }
                    }
                }
                catch(MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving customer type by ID: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving customer type by ID: {ex.Message}");
                }
                return foundCustomerType;
            }
            
        }

        public CustomerType Insert(CustomerType customerType)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try 
                { 
                    using (MySqlCommand command = new MySqlCommand(insert, connection)) 
                    {
                        command.Parameters.AddWithValue("@Type", customerType.Type);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                { 
                    throw new Exception($"Database error occurred while inserting customer type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while inserting customer type: {ex.Message}");
                }
                return customerType;
            }
        }
    }
}
