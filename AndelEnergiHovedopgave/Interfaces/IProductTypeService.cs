using AndelEnergiHovedopgave.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IProductTypeService
    {
        public List<ProductType> GetAll();
        public void Insert(ProductType productType);
        public ProductType InsertWithID(ProductType productType);
        public ProductType GetById(int id);
        public ProductType GetByType(string type);
        public void Delete(int id);

    }
}
