using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class ProductArea 
    {
        [JsonPropertyName("ProductAreaId")]
        public int Id { get; set; }
        [JsonPropertyName("ProductArea")]
        public string Area { get; set; }

        public ProductArea()
        {
            
        }
        public ProductArea(string area)
        {
            Area = area;
        }

        public ProductArea(int id, string area)
        {
            Id = id;
            Area = area;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Area: {Area}";
        }
    }
}
