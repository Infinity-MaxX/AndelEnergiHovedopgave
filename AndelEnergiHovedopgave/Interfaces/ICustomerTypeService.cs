using System;
using System.Collections.Generic;
using System.Text;
using AndelEnergiHovedopgave.Models;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface ICustomerTypeService
    {
        public List<CustomerType> GetAll();
        public CustomerType Insert(CustomerType customerType);
        public CustomerType GetById(int id);
    }
}
