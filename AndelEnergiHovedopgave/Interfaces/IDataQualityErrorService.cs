using AndelEnergiHovedopgave.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IDataQualityErrorService
    {
        public void Delete(DataQualityError error);
        public List<DataQualityError> GetAll();
        public List<DataQualityError> GetByDate(DateTime date);
        public DataQualityError GetById(int id);
        public DataQualityError GetByType(string errorType);
        public DataQualityError Insert(DataQualityError error);
    }
}
