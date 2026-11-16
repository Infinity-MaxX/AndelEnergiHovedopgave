using System;
using System.Collections.Generic;
using System.Text;
using AndelEnergiHovedopgave.Models;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface ISalesChannelService
    {
        public List<SalesChannel> GetAll();
        public SalesChannel Insert(SalesChannel salesChannel);
        public SalesChannel GetById(int id);


    }
}