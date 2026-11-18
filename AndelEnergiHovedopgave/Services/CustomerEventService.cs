using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Services
{
    public class CustomerEventService : ICustomerEventService
    {
        public bool CustomerEventExists(CustomerEvent customerEvent)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerEvent> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerEvent GetByCustomerType(string customerType)
        {
            throw new NotImplementedException();
        }

        public CustomerEvent GetByDate(DateTime month)
        {
            throw new NotImplementedException();
        }

        public CustomerEvent GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerEvent GetByReason(string reason)
        {
            throw new NotImplementedException();
        }

        public CustomerEvent GetBySalesChannel(string salesChannel)
        {
            throw new NotImplementedException();
        }

        public CustomerEvent Insert(CustomerEvent customerEvent)
        {
            throw new NotImplementedException();
        }
    }
}
