using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
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
    }
}
