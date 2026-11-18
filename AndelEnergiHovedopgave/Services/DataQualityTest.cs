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
        #region Instance Field
        private List<CustomerEvent> _customerEvents;
        #endregion

        #region Methods
        public List<CustomerEvent> DataFreshness(DataQualityError customerEvents)
        {
            throw new NotImplementedException();
        }

        public List<CustomerEvent> Outlier(DataQualityError customerEvents)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
