using AndelEnergiHovedopgave.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IProductAreaService
    {
        public List<ProductArea> GetAll();
        public ProductArea Insert(ProductArea ProductArea);
        public ProductArea InsertWithId(ProductArea ProductArea);
        public ProductArea GetById(int id);
        public ProductArea GetByArea(string area);
        public void Delete(int id);
        public bool ProductAreaExists(ProductArea ProductArea); 


    }
}
