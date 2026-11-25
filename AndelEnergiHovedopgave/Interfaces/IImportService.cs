using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IImportService
    {
        public List<T> ReadJasonFromFile<T>(string filePath);
    }
}
