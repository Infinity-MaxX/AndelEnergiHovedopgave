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
        public int SeverityId { get; set; }
        public string ErrorType { get; set; }
        #endregion

        #region Constructor
        // default constructor
        public DataQualityError() { }

        // parameterized constructor
        public DataQualityError(DateTime registrationDate, int customerEventId, int severityId, string errorType)
        {
            RegistrationDate = registrationDate;
            CustomerEventId = customerEventId;
            SeverityId = severityId;
            ErrorType = errorType;
        }

        public DataQualityError(int id, DateTime registrationDate, int customerEventId, int severityId, string errorType)
        {
            Id = id;
            RegistrationDate = registrationDate;
            CustomerEventId = customerEventId;
            SeverityId = severityId;
            ErrorType = errorType;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"ID: {Id}\n\nRegistration Date: {RegistrationDate}\n\n" +
                $"CustomerEvent: {CustomerEventId}\n\nSeverity: {SeverityId}\n\n" +
                $"Error Type: {ErrorType}";
        }
        #endregion
    }
}
