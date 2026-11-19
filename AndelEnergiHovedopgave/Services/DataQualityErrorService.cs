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
                    connection.Open();
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
                finally { connection.Close(); }
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
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        DateTime registrationDate = reader.GetDateTime(1);
                        int customerEventId = reader.GetInt32(2);
                        int errorSeverity = reader.GetInt32(3);
                        string errorType = reader.GetString(4);
                        DataQualityError error = new DataQualityError(id, registrationDate, customerEventId, errorSeverity, errorType);
                        errors.Add(error);
                    }
                    reader.Close();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.Close(); }
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
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int customerEventId = reader.GetInt32(2);
                        int errorSeverity = reader.GetInt32(3);
                        string errorType = reader.GetString(4);
                        DataQualityError error = new DataQualityError(id, date, customerEventId, errorSeverity, errorType);
                        errorsByDate.Add(error);
                    }
                    reader.Close();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.Close(); }
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
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime registrationDate = reader.GetDateTime(1);
                        int customerEventId = reader.GetInt32(2);
                        int errorSeverity = reader.GetInt32(3);
                        string errorType = reader.GetString(4);
                        error = new DataQualityError(id, registrationDate, customerEventId, errorSeverity, errorType);
                    }
                    reader.Close();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.Close(); }
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
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        DateTime registrationDate = reader.GetDateTime(1);
                        int customerEventId = reader.GetInt32(2);
                        int errorSeverity = reader.GetInt32(3);
                        DataQualityError error = new DataQualityError(id, registrationDate, customerEventId, errorSeverity, type);
                        errorsByType.Add(error);
                    }
                    reader.Close();
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception($"Database error occurred while deleting customer type: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting customer type: {ex.Message}");
                }
                finally { connection.Close(); }
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
                    command.Parameters.AddWithValue("@RegistrationDate", error.RegistrationDate);
                    command.Parameters.AddWithValue("@CustomerEventId", error.CustomerEventId);
                    command.Parameters.AddWithValue("@ErrorSeverity", error.ErrorSeverity);
                    command.Parameters.AddWithValue("@ErrorType", error.ErrorType);
                    
                    connection.Open();
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
                finally { connection.Close(); }
                return error;
            }
        }
        #endregion
    }
}
