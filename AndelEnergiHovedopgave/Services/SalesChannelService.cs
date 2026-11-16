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
        private string insertWithId = @"INSERT INTO SalesChannel(Id, Channel) VALUES(@Id, @Channel)";
        private string getByChannel = @"SELECT * FROM SalesChannel WHERE Channel=@Channel";
        private string getById = @"SELECT * FROM SalesChannel WHERE Id=@Id";
        private string delete = @"DELETE FROM SalesChannel WHERE Id=@Id";


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

        public SalesChannel GetByChannel(string type)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionstring))
            {
                SalesChannel foundSalesChannel = new SalesChannel();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(getByChannel, connection))
                    {
                        command.Parameters.AddWithValue("@Channel", type);
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int foundId = reader.GetInt32(0);
                            string foundChannel = reader.GetString(1);
                            foundSalesChannel = new SalesChannel(foundId, foundChannel);
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
            using(MySqlConnection connection= new MySqlConnection(_connectionstring))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(insert, connection))
                    {
                        command.Parameters.AddWithValue("@Channel", salesChannel.Channel);
                        connection.Open();
                        command.ExecuteNonQuery();
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
                return salesChannel;
            }
        }

        public SalesChannel InsertWithID(SalesChannel salesChannel)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionstring))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(insertWithId, connection))
                    {
                        command.Parameters.AddWithValue("@Id", salesChannel.Id);
                        command.Parameters.AddWithValue("@Channel", salesChannel.Channel);
                        connection.Open();
                        command.ExecuteNonQuery();
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
                return salesChannel;
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionstring))
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(delete, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        command.ExecuteNonQuery();
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
            }
        }
    }
}
