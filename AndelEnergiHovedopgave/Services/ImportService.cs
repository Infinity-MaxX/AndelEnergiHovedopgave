using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AndelEnergiHovedopgave.Services
{
    public class ImportService
    {
        public List<T> ReadJasonFromFile<T>(string filePath)
        {
            string jason=File.ReadAllText(filePath);
            Console.WriteLine(jason);

            List<T> importedObjects = JsonSerializer.Deserialize<List<T>>(jason);


            return importedObjects;

        }
    }
}
