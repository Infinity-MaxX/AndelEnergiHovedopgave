using AndelEnergiHovedopgave.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface ICustomerEventService
    {
        public List<CustomerEvent> GetAll();
        public CustomerEvent Insert(CustomerEvent customerEvent);
        public CustomerEvent GetById(int id);

        public CustomerEvent GetByCustomerType(string customerType);
        public CustomerEvent GetByDate(DateTime month);
        public CustomerEvent GetByReason(string reason);
        public CustomerEvent GetBySalesChannel(string salesChannel);
        public void Delete(int id);
        public bool CustomerEventExists(CustomerEvent customerEvent);

    }
}
