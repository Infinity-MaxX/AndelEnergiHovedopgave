using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class DataQualityError
    {
        #region Instance fields
        private int _errorType;
        private string _errorSeverity;
        private DateTime _registrationDate;
        #endregion

        #region Properties
        public int ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }
        public string ErrorSeverity
        {
            get { return _errorSeverity; }
            set { _errorSeverity = value; }
        }
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }
        #endregion

        #region Constructor
        // base constructor
        public DataQualityError()
        {
        }

        // parameterized constructor
        public DataQualityError(int errorType, string errorSeverity, DateTime registrationDate)
        {
            _errorType = errorType;
            _errorSeverity = errorSeverity;
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
