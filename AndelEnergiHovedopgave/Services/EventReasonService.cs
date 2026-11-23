using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using Microsoft.AspNetCore.Identity;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class EventReasonService : IEventReasonService
    {
        private string _connectionString;
        private string getAll = "SELECT * FROM EventReason";
        private string insert = "INSERT INTO EventReason(Reason) VALUES(@Reason)";
        private string getById = "SELECT * FROM EventReason Where Id=@Id";
        private string getByReason = "SELECT * FROM EventReason Where Reason=@Reason";
        private string delete = "DELETE From EventReason WHERE Id=@Id";
        private string eventReasonExists = "SELECT COUNT(*)  FROM EventReason Where Reason=@Reason";

        public EventReasonService(string connectionstring)
        {
            _connectionString = connectionstring ?? throw new ArgumentNullException(nameof(connectionstring));
        }

        public List<EventReason> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                List<EventReason> eventReasons = new List<EventReason>();
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
                                string reason = reader.GetString(1);
                                EventReason eventReason = new EventReason(id, reason);
                                eventReasons.Add(eventReason);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving event reasons: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving event reasons: {ex.Message}");
                }
                return eventReasons;
            }
        }
        public EventReason Insert(EventReason eventReason)
        {
            if(EventReasonExists(eventReason))
            {
                return eventReason;
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insert, connection);
                    command.Parameters.AddWithValue("@Reason", eventReason.Reason);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while inserting event reason: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while inserting event reason: {ex.Message}");
                }
                return eventReason;
            }
        }
        public EventReason GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString)) 
            {
                EventReason foundEventReason = new EventReason();
                try 
                {
                    MySqlCommand command= new MySqlCommand(getById, connection);
                    command.Parameters.AddWithValue("@Id",id);
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) 
                    { 
                        int foundId =reader.GetInt32(0);
                        string foundReason = reader.GetString(1);
                        foundEventReason = new EventReason(foundId,foundReason);
                    }

                }
                catch(MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving event reason by ID: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving event reason by ID: {ex.Message}");
                }
                return foundEventReason;
            }    
        }
        public EventReason GetByReason(string reason) 
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString)) 
            {
                EventReason foundEventReason = new EventReason();
                try 
                {
                    MySqlCommand command = new MySqlCommand(getByReason, connection);
                    command.Parameters.AddWithValue("@Reason", reason);
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) 
                    {
                        int foundId= reader.GetInt32(0);
                        string foundReason = reader.GetString(1);
                        foundEventReason = new EventReason(foundId, foundReason);
                    }

                }
                catch(MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving event reason by reason: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving event reason by reason: {ex.Message}");
                }
                return foundEventReason;
            }
        }
        public void Delete(int id) 
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString)) 
            {
                try 
                { 
                    MySqlCommand command= new MySqlCommand(delete,connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    throw new Exception($"Database error occurred while deleting event reason: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting event reason: {ex.Message}");
                }
            }
        }
        public bool EventReasonExists(EventReason eventReason) 
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(eventReasonExists, connection);
                    command.Parameters.AddWithValue("@Reason", eventReason.Reason);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while checking if event reason exists: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while checking if event reason exists: {ex.Message}");
                }
            }
        }

    }
}
