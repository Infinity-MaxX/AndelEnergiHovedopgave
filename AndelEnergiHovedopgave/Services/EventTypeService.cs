using AndelEnergiHovedopgave.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using Microsoft.IdentityModel.Tokens;

namespace AndelEnergiHovedopgave.Services
{
    public class EventTypeService : IEventTypeService
    {
        private string _connectionString = Secret.ConnectionString;
        private string getAll="SELECT * FROM EventTypes";
        private string insert = "INSERT INTO EventTypes (Type) VALUES (@Type)";
        private string getById = "SELECT * FROM EventTypes WHERE Id = @Id";
        private string getByType = "SELECT * FROM EventTypes WHERE Type = @Type";
        private string delete = "DELETE FROM EventTypes WHERE Id = @Id";

        public List<EventType> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString)) 
            {
                List<EventType> types = new List<EventType>();
                try 
                { 
                    MySqlCommand command = new MySqlCommand(getAll, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string type = reader.GetString(1);
                        types.Add(new EventType(id,type));
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
                return types;
            }
        }
        public EventType Insert(EventType eventType)
        {
            using(MySqlConnection connection= new MySqlConnection(_connectionString)) 
            {
                try 
                {
                    MySqlCommand command = new MySqlCommand(insert, connection);
                    command.Parameters.AddWithValue("@Type", eventType.Type);
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
                return eventType;
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

        public bool EventTypeExists(EventType eventType)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(getByType, connection);
                    command.Parameters.AddWithValue("@Type", eventType.Type);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
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

        public EventType GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                EventType foundEventType = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getById, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int eventTypeId = reader.GetInt32(0);
                        string type = reader.GetString(1);
                        foundEventType = new EventType(eventTypeId, type);
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving event type by ID: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving event type by ID: {ex.Message}");
                }
                return foundEventType;
            }
        }

        public EventType GetByType(string type)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                EventType foundEventType = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getByType, connection);
                    command.Parameters.AddWithValue("@Type", type);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int eventTypeId = reader.GetInt32(0);
                        string eventTypeName = reader.GetString(1);
                        foundEventType = new EventType(eventTypeId, eventTypeName);
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while retrieving event type by type: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while retrieving event type by type: {ex.Message}");
                }
                return foundEventType;
            }
        }

    }
}
