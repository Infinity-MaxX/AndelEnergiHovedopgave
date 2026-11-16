using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class SalesChannelService : ISalesChannelService
    {
        private string _connectionstring = Secret.ConnectionString;
        private string getAll = @"SELECT * FROM SalesChannel";
        private string insert = @"INSERT INTO SalesChannel(Channel) VALUES(@Channel)";
        private string getById = @"SELECT * FROM SalesChannel WHERE Id=@Id";


        public List<SalesChannel> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionstring))
            {
                List<SalesChannel> salesChannels = new List<SalesChannel>();
                try 
                {
                    using (MySqlCommand command = new MySqlCommand(getAll, connection)) 
                    {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read()) 
                        {
                            int id = reader.GetInt32(0);
                            string channel = reader.GetString(1);
                            salesChannels.Add(new SalesChannel(id, channel));
                        }
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
                return salesChannels;
            }
        }

        public SalesChannel GetById(int id)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionstring))
            {
                SalesChannel foundSalesChannel = new SalesChannel();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(getById, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int foundId = reader.GetInt32(0);
                            string foundchannel = reader.GetString(1);
                            foundSalesChannel = new SalesChannel(foundId, foundchannel);
                        }
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
                return foundSalesChannel;
            }
        }

        public SalesChannel Insert(SalesChannel salesChannel)
        {
            throw new NotImplementedException();
        }
    }
}
