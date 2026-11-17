using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class ProductType 
    {
        [JsonPropertyName("ProductAreaId")]
        public int Id { get; set; }
        [JsonPropertyName("ProductArea")]
        public string Type { get; set; }

        public ProductType()
        {
            
        }
        public ProductType(string type)
        {
            Type = type;
        }

        public ProductType(int id, string type)
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
