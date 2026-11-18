using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class EventReason
    {
        public int Id { get; set; }
        public string Reason { get; set; }

        public EventReason()
        {
            
        }
        public EventReason(string reason)
        {
            Reason = reason;
        }
        public EventReason(int id, string reason)
        {
            Id = id;
            Reason = reason;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Reason: {Reason}";
        }
    }
}
