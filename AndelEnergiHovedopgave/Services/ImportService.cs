using AndelEnergiHovedopgave.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AndelEnergiHovedopgave.Services
{
    public class ImportService: IImportService
    {
        public List<T> ReadJasonFromFile<T>(string filePath)
        {
            string jason=File.ReadAllText(filePath);

            List<T> importedObjects = JsonSerializer.Deserialize<List<T>>(jason);


            return importedObjects;

        }
    }
}
