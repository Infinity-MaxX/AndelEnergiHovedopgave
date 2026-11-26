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
        private string _connectionString;
        #endregion

        #region SQL Queries
        private string dataQualityErrorExistsSQL =  "SELECT COUNT(*) FROM DataQualityError " +
                                                    "WHERE RegistrationDate = @RegistrationDate " +
                                                    "AND CustomerEventId = @CustomerEventId " +
                                                    "AND SeverityId = @ErrorSeverity " +
                                                    "AND ErrorType = @ErrorType";
        private string deleteSQL    =   "DELETE FROM DataQualityError WHERE Id = @Id";
        private string getAllSQL    =   "SELECT * FROM DataQualityError";
        private string getAllDates =    "SELECT * FROM DataQualityError WHERE RegistrationDate >= @StartOfDay AND RegistrationDate < @NextDay";
        private string getByDateSQL =   "SELECT * FROM DataQualityError WHERE RegistrationDate = @RegistrationDate";
        private string getByIdSQL   =   "SELECT * FROM DataQualityError WHERE Id = @Id";
        private string getByTypeSQL =   "SELECT * FROM DataQualityError WHERE ErrorType = @ErrorType";
        private string insertSQL    =   "INSERT INTO DataQualityError(RegistrationDate, CustomerEventId, SeverityId, ErrorType) " +
                                        "VALUES(@RegistrationDate, @CustomerEventId, @ErrorSeverity, @ErrorType)";
        #endregion

        #region Constructor
        public DataQualityErrorService(string connectionString)
        {
            _connectionString = connectionString 
                ?? throw new ArgumentNullException(nameof(connectionString));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether a data quality error already exists in the database. Used for testing purposes to prevent
        /// duplicate entries that will throw errors down in UnitTesting.
        /// </summary>
        /// <param name="dataQualityError">The data quality error whose identifier is checked.</param>
        /// <returns>true if a matching data quality error exists; otherwise, false.</returns>
        /// <exception cref="MySqlException">Thrown when a MySQL error occurs.</exception>
        /// <exception cref="Exception">Thrown when an error occurs while checking for the data quality error.</exception>
        public bool DataQualityErrorExists(DataQualityError dataQualityError)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(dataQualityErrorExistsSQL, connection);
                    command.Parameters.AddWithValue("@RegistrationDate", dataQualityError.RegistrationDate);
                    command.Parameters.AddWithValue("@CustomerEventId", dataQualityError.CustomerEventId);
                    command.Parameters.AddWithValue("@ErrorSeverity", dataQualityError.ErrorSeverity);
                    command.Parameters.AddWithValue("@ErrorType", dataQualityError.ErrorType);
                    connection.Open();

                    // ExecuteScalar returns the first object. because we want
                    // to get the count of rows, we convert it to an integer.
                    // Johanne's solution
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Database error occurred while checking if data quality error exists: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while checking if data quality error exists: {ex.Message}");
                }
                finally { connection.Close(); }
            }
        }

        /// <summary>
        /// Deletes the customer type with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the customer type to delete.</param>
        /// <exception cref="MySqlException">Thrown when a MySQL error occurs.</exception>
        /// <exception cref="Exception">Thrown when an error occurs while deleting the customer type.</exception>
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
                DataQualityError error = new DataQualityError();
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
            error.RegistrationDate = DateTime.Today;

            if (DataQualityErrorExists(error))
            {
                return error;
            }
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(insertSQL, connection);
                    command.Parameters.AddWithValue("@RegistrationDate", error.RegistrationDate);
                    command.Parameters.AddWithValue("@CustomerEventId", error.CustomerEventId);
                    command.Parameters.AddWithValue("@ErrorSeverity", error.ErrorSeverity);
                    command.Parameters.AddWithValue("@ErrorType", error.ErrorType);

                    connection.Open();
                    command.ExecuteNonQuery();

                    //Sætter id til at være det sisdste autogenererede id
                    error.Id = Convert.ToInt32(command.LastInsertedId);
                    
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
