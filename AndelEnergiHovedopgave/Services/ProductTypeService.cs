using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private string _connectionString = Secret.ConnectionString;
        private string getAll = @"SELECT * FROM ProductArea";
        private string insert = @"INSERT INTO ProductArea (Type) VALUES (@Type)";
        private string insertWithId = @"INSERT INTO ProductArea (Id, Type) VALUES (@Id, @Type)";
        private string getById = @"SELECT * FROM ProductArea WHERE Id = @Id";
        private string getByType = @"SELECT * FROM ProductArea WHERE Type = @Type";
        private string delete = @"DELETE FROM ProductArea WHERE Id = @Id";

        public List<ProductType> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<ProductType> productTypes = new List<ProductType>();
                try
                {
                    MySqlCommand command = new MySqlCommand(getAll, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string type = reader.GetString(1);
                        ProductType productType = new ProductType(id, type);
                        productTypes.Add(productType);
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
                return productTypes;


            }
        }
        public ProductType Insert(ProductType productType)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insert, connection);
                    command.Parameters.AddWithValue("@Type", productType.Type);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
                return productType;
            }
        }
        public ProductType InsertWithId(ProductType productType)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insertWithId, connection);
                    command.Parameters.AddWithValue("@Id",productType.Id);
                    command.Parameters.AddWithValue("@Type", productType.Type);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }
            return productType;
        }

        public ProductType GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                ProductType foundProductType = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getById, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int foundId = reader.GetInt32(0);
                        string foundtype = reader.GetString(1);
                        foundProductType= new ProductType(foundId, foundtype);
                    }
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
                return foundProductType;

            }
        }

        public ProductType GetByType(string type)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                ProductType foundProductType = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getByType, connection);
                    command.Parameters.AddWithValue("@Type", type);

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int foundId = reader.GetInt32(0);
                        string foundtype = reader.GetString(1);
                        foundProductType = new ProductType(foundId, foundtype);
                    }
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
                return foundProductType;
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(delete, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
