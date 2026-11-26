using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class DataQualityError
    {
        #region Properties
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CustomerEventId { get; set; }
        public int ErrorSeverity { get; set; }
        public string ErrorType { get; set; }
        #endregion

        #region Constructor
        // default constructor
        public DataQualityError() { }

        // parameterized constructor
        public DataQualityError(DateTime registrationDate, int customerEventId, int errorSeverity, string errorType)
        {
            RegistrationDate = registrationDate;
            CustomerEventId = customerEventId;
            ErrorSeverity = errorSeverity;
            ErrorType = errorType;
        }

        public DataQualityError(int id, DateTime registrationDate, int customerEventId, int errorSeverity, string errorType)
        {
            Id = id;
            RegistrationDate = registrationDate;
            CustomerEventId = customerEventId;
            ErrorSeverity = errorSeverity;
            ErrorType = errorType;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"ID: {Id}\nRegistration Date: {RegistrationDate}\n" +
                $"CustomerEvent: {CustomerEventId}\nSeverity: {ErrorSeverity}\n" +
                $"Error Type: {ErrorType}";
        }
        #endregion
    }
}
