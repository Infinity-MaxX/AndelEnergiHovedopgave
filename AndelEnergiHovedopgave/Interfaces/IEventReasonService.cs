using System;
using System.Collections.Generic;
using System.Text;
using AndelEnergiHovedopgave.Models;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IEventReasonService
    {
        public List<EventReason> GetAll();
        public EventReason Insert(EventReason eventReason);
        public EventReason GetById(int id);
        public EventReason GetByReason(string reason);
        public void Delete(int id);
        public bool EventReasonExists(EventReason eventReason);

    }
}
