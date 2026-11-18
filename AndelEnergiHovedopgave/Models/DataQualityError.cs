using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class DataQualityError
    {
        #region Instance fields
        private DateTime _registrationDate;
        #endregion

        #region Properties
        public int ErrorType { get; set; }
        public string ErrorSeverity { get; set; }
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }
        #endregion

        #region Constructor
        // base constructor
        public DataQualityError() { }

        // parameterized constructor
        public DataQualityError(int errorType, string errorSeverity, DateTime registrationDate)
        {
            ErrorType = errorType;
            ErrorSeverity = errorSeverity;
            _registrationDate = registrationDate;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Error Type: {ErrorType}\nSeverity: {ErrorSeverity}\nRegistration Date: {RegistrationDate}";
        }
        #endregion
    }
}
