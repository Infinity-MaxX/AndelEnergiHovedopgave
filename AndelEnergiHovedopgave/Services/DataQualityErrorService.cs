using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class DataQualityErrorService
    {
        // Notes: Consistency is important when there are multiple data sources,
        // as it ensures that the data is consistent across all sources. However,
        // since this project only has one data source, it becomes unnecessary
        // and irrelevant to implement consistency checks.

        // Notes: Timelessness, or Data Freshness, is especially important for
        // the CustomerEvent table, as it is used to track the customer's energy
        // consumption over time. If the data is not fresh, it can lead to
        // incorrect billing and other issues. Therefore, it is important to
        // ensure that the data is up-to-date and accurate.

        // Notes: Uniqueness is accounted for through the database itself,
        // using both Primary Key and Unique keys to ensure that no duplicates
        // are allowed. This is a good way to ensure that the data is unique,
        // as it is enforced at the database level.

        // Notes: Validity can be used to check for system conformity, fx
        // check if the CustomerType is 'GA' XOR 'CH' as no other type is
        // supported by the system. If the CustomerType is neither or both,
        // then it is invalid.
    }
}
