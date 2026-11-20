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


        /// <summary>
        /// Retrieves all customer types from the database.
        /// </summary>
        /// <returns>A list of all customer types.</returns>
        /// <exception cref="Exception">A database or data retrieval error occurred.</exception>
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

        /// <summary>
        /// Retrieves a customer type by identifier.
        /// </summary>
        /// <param name="id">The customer type identifier.</param>
        /// <returns>The customer type matching the specified identifier, or a default CustomerType when no match is found.</returns>
        /// <exception cref="Exception">The database operation or retrieval fails.</exception>
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

        /// <summary>
        /// Retrieves a customer type by its type name.
        /// </summary>
        /// <param name="type">The customer type name to retrieve.</param>
        /// <returns>The matching CustomerType, or a new CustomerType instance if no match is found.</returns>
        /// <exception cref="Exception">Thrown when a database or processing error occurs while retrieving the customer type.</exception>
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

        /// <summary>
        /// Inserts a customer type if it does not already exist.
        /// </summary>
        /// <param name="customerType">The customer type to insert.</param>
        /// <returns>The inserted customer type, or the existing customer type.</returns>
        /// <exception cref="Exception">Thrown when a database or general error occurs while inserting the customer type.</exception>
        public CustomerType Insert(CustomerType customerType)
        {
            if(CustomerTypeTypeExists(customerType))
            {
                return customerType;
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

        /// <summary>
        /// Inserts a customer type if it does not already exist.
        /// </summary>
        /// <param name="customerType">The customer type to insert.</param>
        /// <returns>The inserted customer type, or the existing customer type.</returns>
        /// <exception cref="Exception">A database or general error occurs while inserting the customer type.</exception>
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

        /// <summary>
        /// Deletes the customer type identified by the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the customer type to delete.</param>
        /// <exception cref="Exception">A database or general error occurs while deleting the customer type.</exception>
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

        /// <summary>
        /// Determines whether a customer type already exists in the database, by getting the count of objects in the database.
        /// </summary>
        /// <param name="customerType">The customerType to check.</param>
        /// <returns><see langword="true"/> if the customer type exists; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">A database or other error occurred while checking whether the customer type exists.</exception>
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
                        //It extracts the first object(the count value) and converts it into an int
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
