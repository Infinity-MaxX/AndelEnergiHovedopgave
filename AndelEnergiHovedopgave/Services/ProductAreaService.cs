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
    public class ProductAreaService : IProductAreaService
    {
        private string _connectionString;
        private string getAll = @"SELECT * FROM ProductArea";
        private string insert = @"INSERT INTO ProductArea (Area) VALUES (@Area)";
        private string insertWithId = @"INSERT INTO ProductArea (Id, Area) VALUES (@Id, @Area)";
        private string getById = @"SELECT * FROM ProductArea WHERE Id = @Id";
        private string getByArea = @"SELECT * FROM ProductArea WHERE Area = @Area";
        private string delete = @"DELETE FROM ProductArea WHERE Id = @Id";
        private string existsByArea =@"SELECT COUNT(*) FROM ProductArea WHERE Area = @Area";

        public ProductAreaService(string connectionstring)
        {
            _connectionString = connectionstring ?? throw new ArgumentNullException(nameof(connectionstring));
        }

        public List<ProductArea> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<ProductArea> productAreas = new List<ProductArea>();
                try
                {
                    MySqlCommand command = new MySqlCommand(getAll, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string Area = reader.GetString(1);
                        ProductArea productArea = new ProductArea(id, Area);
                        productAreas.Add(productArea);
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
                return productAreas;


            }
        }
        public ProductArea Insert(ProductArea productArea)
        {
            if (ProductAreaExists(productArea))
            {
                return productArea;
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insert, connection);
                    command.Parameters.AddWithValue("@Area", productArea.Area);
                    connection.Open();
                    command.ExecuteNonQuery();
                    productArea.Id = Convert.ToInt32(command.LastInsertedId);
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
                return productArea;
            }
        }
        public ProductArea InsertWithId(ProductArea productArea)
        {
            if (ProductAreaExists(productArea))
            {
                return productArea;
            }
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insertWithId, connection);
                    command.Parameters.AddWithValue("@Id",productArea.Id);
                    command.Parameters.AddWithValue("@Area", productArea.Area);
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
            return productArea;
        }

        public ProductArea GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                ProductArea foundProductArea = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getById, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int foundId = reader.GetInt32(0);
                        string foundArea = reader.GetString(1);
                        foundProductArea= new ProductArea(foundId, foundArea);
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
                return foundProductArea;

            }
        }

        public ProductArea GetByArea(string area)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                ProductArea foundProductArea = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getByArea, connection);
                    command.Parameters.AddWithValue("@Area", area);

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int foundId = reader.GetInt32(0);
                        string foundArea = reader.GetString(1);
                        foundProductArea = new ProductArea(foundId, foundArea);
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
                return foundProductArea;
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

        public bool ProductAreaExists(ProductArea productArea)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command =new MySqlCommand(existsByArea, connection);

                    command.Parameters.AddWithValue("@Area",productArea.Area);

                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception(
                        $"Database error: {ex.Message}");
                }
            }
        }
    }
}
