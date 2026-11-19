using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    /// <summary>
    /// Provides methods for identifying data-quality issues in customer events.
    /// </summary>
    public class DataQualityTest : IDataQualityTest
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

        #region Instance Field
        private List<CustomerEvent> _customerEvents;
        #endregion

        #region Methods

        /// <summary>
        /// Timelessness test, checks the freshness of the data, keeping it up to
        /// date.
        /// </summary>
        /// <param name="customerEvents"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<CustomerEvent> DataFreshness(DataQualityError customerEvents)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Completeness test, checks whether there are any null values in the
        /// updated dataset.
        /// </summary>
        /// <param name="customerEvents"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<CustomerEvent> NullValues(DataQualityError customerEvents)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Accuracy test, checks against outliers by using a statistical model.
        /// </summary>
        /// <param name="customerEvents"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<CustomerEvent> Outlier(DataQualityError customerEvents)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Validity tests, checks if updated datasets conform to the system's
        /// standards.
        /// </summary>
        /// <param name="customerEvents"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<CustomerEvent> Validity(DataQualityError customerEvents)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
