using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    /// <summary>
    /// Provides operations for managing data quality errors.
    /// </summary>
    /// <remarks>Supports retrieving, creating, updating, and deleting recorded 
    /// data quality errors.</remarks>
    public class DataQualityErrorService : IDataQualityErrorService
    {
        // Notes: Accuracy is important to ensure that the data is correct and
        // free from errors. This can be achieved through a STATISTICAL MODEL that
        // checks for outliers and other anomalies in the data. If any errors are
        // found,they should be LOGGED AND REPORTED to the appropriate parties for
        // correction.

        // Notes: Completeness is important to ensure that all required data is
        // present. NULL values would need to be CHECKED FOR IN EACH COLUMN in the
        // database, especially after every update and freshness of the dataset.

        // Notes: Consistency is important when there are multiple data sources,
        // as it ensures that the data is consistent across all sources. However,
        // since this project only has ONE data source, it becomes UNNECESSARY
        // and IRRELEVANT to implement consistency checks.

        // Notes: Timelessness, or Data Freshness, is especially important for
        // the CustomerEvent table, as it is used to track the customer's energy
        // consumption over time. If the data is not fresh, it can lead to
        // incorrect billing and other issues. Therefore, it is important to
        // ensure that the data is up-to-date and accurate, and functionality
        // needs to be implemented that TRACKS WHEN THE LAST TIME THE DATASET WAS
        // UPDATED. If it is not up-to-date, then the system should SEND AN ERROR
        // WARNING.

        // Notes: Uniqueness is ACCOUNTED FOR through the database itself, using
        // both Primary Key and Unique keys to ensure that no duplicates are
        // allowed. This is a good way to ensure that the data is unique, as it
        // is enforced at the database level. Therefore, NO FURTHER FUNCTIONALITY
        // is needed for Uniqueness.

        // Notes: Validity can be used to check for system conformity, fx check
        // if the CustomerType is 'GA' XOR 'CH' as no other type is supported by
        // the system. If the CustomerType is neither or both, then it is invalid.

        #region Connection String
        private string _connectionString = Secret.ConnectionString;
        #endregion

        #region SQL Queries
        private string deleteQuery = "DELETE FROM DataQualityError WHERE Id = @Id";
        private string getAll = "SELECT * FROM DataQualityError";
        private string getByDate = "SELECT * FROM DataQualityError WHERE RegistrationDate = @RegistrationDate";
        private string getById = "SELECT * FROM DataQualityError WHERE Id = @Id";
        private string insert = "INSERT INTO DataQualityError(Id, ErrorType, ErrorSeverity, RegistrationDate)" +
                                "VALUES(@Id, @ErrorType, @ErrorSeverity, @RegistrationDate)";
        #endregion

        #region Methods
        public void Delete(DataQualityError error)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {

            }
        }

        public List<DataQualityError> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<DataQualityError> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public DataQualityError GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataQualityError GetByType(int errorType)
        {
            throw new NotImplementedException();
        }

        public DataQualityError Insert(DataQualityError error)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
