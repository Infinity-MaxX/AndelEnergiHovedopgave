using AndelEnergiHovedopgave.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IDataQualityTest
    {
        public List<CustomerEvent> DataFreshness(DataQualityError customerEvents);
        public List<CustomerEvent> NullValues(DataQualityError customerEvents);
        public List<CustomerEvent> Outlier(DataQualityError customerEvents);
        public List<CustomerEvent> Validity(DataQualityError customerEvents);
    }
}
