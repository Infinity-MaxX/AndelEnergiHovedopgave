using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AndelEnergiHovedopgave.Services
{
    /// <summary>
    /// Provides operations for managing data quality errors.
    /// </summary>
    /// <remarks>Supports retrieving, creating, updating, and deleting recorded 
    /// data quality errors.</remarks>
    public class DataQualityErrorService : IDataQualityErrorService
    {
        #region Connection String
        private string _connectionString = Secret.ConnectionString;
        #endregion

        #region SQL Queries
        private string deleteSQL = "DELETE FROM DataQualityError WHERE Id = @Id";
        private string getAllSQL = "SELECT * FROM DataQualityError";
        private string getByDateSQL = "SELECT * FROM DataQualityError WHERE RegistrationDate = @RegistrationDate";
        private string getByIdSQL = "SELECT * FROM DataQualityError WHERE Id = @Id";
        private string getByTypeSQL = "SELECT * FROM DataQualityError WHERE ErrorType = @ErrorType";
        private string insertSQL = "INSERT INTO DataQualityError(Id, ErrorType, ErrorSeverity, RegistrationDate)" +
                                "VALUES(@Id, @ErrorType, @ErrorSeverity, @RegistrationDate)";
        #endregion

        #region Methods
        public void Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(deleteSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.OpenAsync();
                    command.ExecuteNonQuery();
                }
                catch(MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.CloseAsync(); }
            }
        }

        public List<DataQualityError> GetAll()
        {
            List<DataQualityError> errors = new List<DataQualityError>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(getAllSQL, connection);
                    connection.OpenAsync();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int customerEventId = reader.GetInt32(1);
                        string errorType = reader.GetString(2);
                        string errorSeverity = reader.GetString(3);
                        DateTime registrationDate = reader.GetDateTime(4);
                        DataQualityError error = new DataQualityError(id, customerEventId, errorType, errorSeverity, registrationDate);
                        errors.Add(error);
                    }
                    reader.CloseAsync();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.CloseAsync(); }
            }
            return errors;
        }

        public List<DataQualityError> GetByDate(DateTime date)
        {
            List<DataQualityError> errorsByDate = new List<DataQualityError>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(getByDateSQL, connection);
                    command.Parameters.AddWithValue("@RegistrationDate", date);
                    connection.OpenAsync();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int customerEventId = reader.GetInt32(1);
                        string errorType = reader.GetString(2);
                        string errorSeverity = reader.GetString(3);
                        DataQualityError error = new DataQualityError(id, customerEventId, errorType, errorSeverity, date);
                        errorsByDate.Add(error);
                    }
                    reader.CloseAsync();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.CloseAsync(); }
            }
            return errorsByDate;
        }

        public DataQualityError GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                DataQualityError error = null;
                try
                {
                    MySqlCommand command = new MySqlCommand(getByIdSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.OpenAsync();

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int customerEventId = reader.GetInt32(1);
                        string errorType = reader.GetString(2);
                        string errorSeverity = reader.GetString(3);
                        DateTime registrationDate = reader.GetDateTime(4);
                        error = new DataQualityError(id, customerEventId, errorType, errorSeverity, registrationDate);
                    }
                    reader.CloseAsync();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.CloseAsync(); }
                return error;
            }
        }

        public List<DataQualityError> GetByType(string type)
        {
            List<DataQualityError> errorsByType = new List<DataQualityError>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(getByTypeSQL, connection);
                    command.Parameters.AddWithValue("@ErrorType", type);
                    connection.OpenAsync();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int customerEventId = reader.GetInt32(1);
                        string errorSeverity = reader.GetString(3);
                        DateTime registrationDate = reader.GetDateTime(4);
                        DataQualityError error = new DataQualityError(id, customerEventId, type, errorSeverity, registrationDate);
                        errorsByType.Add(error);
                    }
                    reader.CloseAsync();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.CloseAsync(); }
            }
            return errorsByType;
        }

        public DataQualityError Insert(DataQualityError error)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insertSQL, connection);
                    command.Parameters.AddWithValue("@Id", error.Id);
                    command.Parameters.AddWithValue("@CustomerEventId", error.CustomerEventId);
                    command.Parameters.AddWithValue("@ErrorType", error.ErrorType);
                    command.Parameters.AddWithValue("@ErrorSeverity", error.ErrorSeverity);
                    command.Parameters.AddWithValue("@RegistrationDate", error.RegistrationDate);
                    
                    connection.OpenAsync();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.CloseAsync(); }
                return error;
            }
        }
        #endregion
    }
}
