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
        private string insertWithId = "INSERT INTO CustomerType (Type,Id) VALUES (@Type,@Id)";
        private string getById = "SELECT * FROM CustomerType WHERE Id = @Id";
        private string getByType = "SELECT * FROM CustomerType WHERE Type = @Type";
        private string deleteQuery = "DELETE FROM CustomerType WHERE Id = @Id";
        private string existsCustomerType = "SELECT COUNT(*) FROM CustomerType WHERE Type = @Type";


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
                    using (MySqlCommand comand = new MySqlCommand(getById, connection)) 
                    {
                        comand.Parameters.AddWithValue("@Id", id);
                        connection.Open();

                        MySqlDataReader reader = comand.ExecuteReader();
                        if (reader.Read()) 
                        {
                            int foundId = reader.GetInt32("Id");
                            string foundType = reader.GetString("Type");
                            foundCustomerType= new CustomerType(foundId, foundType);
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
        public CustomerType GetByType(string type)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                CustomerType foundCustomerType = new CustomerType();
                try
                {
                    using (MySqlCommand comand = new MySqlCommand(getByType,connection))
                    {
                        comand.Parameters.AddWithValue("@Type", type);
                        connection.Open();

                        MySqlDataReader reader = comand.ExecuteReader();
                        if (reader.Read())
                        {
                            int foundId = reader.GetInt32("Id");
                            string foundType = reader.GetString("Type");
                            foundCustomerType = new CustomerType(foundId, foundType);
                        }
                    }
                }
                catch (MySqlException ex)
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
            if(CustomerTypeTypeExists(customerType))
            {
                throw new Exception($"Customer type '{customerType.Type}' already exists.");
            }
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
        public CustomerType InsertWithId(CustomerType customerType)
        {
            if(CustomerTypeTypeExists(customerType))
            {
                return customerType;
            }
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(insertWithId, connection))
                    {
                        command.Parameters.AddWithValue("@Id", customerType.Id);
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

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                CustomerType deletedCustomerType = GetById(id);
                try
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
            }
        }

        public bool CustomerTypeTypeExists(CustomerType customerType)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try 
                {
                    using (MySqlCommand command= new MySqlCommand(existsCustomerType, connection))
                    {
                        command.Parameters.AddWithValue("@Type", customerType.Type);
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while checking if customer type exists: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while checking if customer type exists: {ex.Message}");
                }
            }
        }
    }
}
