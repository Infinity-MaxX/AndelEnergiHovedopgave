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
    public class ProductTypeService:IProductTypeService
    {
        private string _connectionString = Secret.ConnectionString;
        string getAll= @"SELECT * FROM ProductArea";
        string insert = @"INSERT INTO ProductArea (Type) VALUES (@Type)";
        string insert_with_id = @"INSERT INTO ProductArea (Type,id) VALUES (@Type,@Id)";
        string getById = @"SELECT * FROM ProductArea WHERE Id = @Id";

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
                catch(MySqlException ex)
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
        

        public ProductType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductType productType)
        {
            
        }
    }
}
