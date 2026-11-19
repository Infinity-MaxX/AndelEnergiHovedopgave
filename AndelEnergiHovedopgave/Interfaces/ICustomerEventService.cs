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

        public List<CustomerEvent> GetByCustomerType(string customerType);
        public List<CustomerEvent> GetByDate(DateTime month);
        public List<CustomerEvent> GetByReason(string reason);
        public List<CustomerEvent> GetBySalesChannel(string salesChannel);
        public List<CustomerEvent> GetByProductArea(string productArea);
        public void Delete(int id);
        public bool CustomerEventExists(CustomerEvent customerEvent);

    }
}
