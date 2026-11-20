using System;
using System.Collections.Generic;
using System.Text;
using AndelEnergiHovedopgave.Models;

namespace AndelEnergiHovedopgave.Interfaces
{
    public interface IEventTypeService
    {
        public List<EventType> GetAll();
        public EventType Insert(EventType eventType);
        public EventType GetById(int id);
        public EventType GetByType(string type);
        public void Delete(int id);
        public bool EventTypeExists(EventType eventType);

    }
}
