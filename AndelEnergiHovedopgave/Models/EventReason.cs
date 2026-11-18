using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class EventReason
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Reason")]
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
