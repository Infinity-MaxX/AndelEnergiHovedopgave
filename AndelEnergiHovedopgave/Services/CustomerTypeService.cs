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
            throw new NotImplementedException();
        }

        public CustomerType Insert(CustomerType customerType)
        {
            throw new NotImplementedException();
        }
    }
}
