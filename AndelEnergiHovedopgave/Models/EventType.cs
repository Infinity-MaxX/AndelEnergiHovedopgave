using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public EventType()
        {

        }
        public EventType(string type)
        {
            Type = type;
        }
        public EventType(int id, string type)
        {
            Id = id;
            Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Type: {Type}";
        }
    }
}
