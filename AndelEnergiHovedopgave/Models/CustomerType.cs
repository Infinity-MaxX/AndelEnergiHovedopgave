using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class CustomerType
    {
        [JsonPropertyName("CustomerTypeId")]
        public int Id { get; set; }
        [NotNull]
        [JsonPropertyName("CustomerType")]
        public string Type { get; set; }

        public CustomerType()
        {
            
        }

        public CustomerType(string type)
        {
            Type = type;
        }
        public CustomerType(int id, string type)
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
