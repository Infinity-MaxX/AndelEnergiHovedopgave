using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class ProductType
    {
        public int Id { get; set; }
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
    }
}
