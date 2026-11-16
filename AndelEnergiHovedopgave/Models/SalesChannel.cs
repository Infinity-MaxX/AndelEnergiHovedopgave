using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class SalesChannel
    {
        public int Id { get; set; }
        public string Channel { get; set; }

        public SalesChannel()
        {
            
        }
        public SalesChannel(string channel)
        {
            Channel = channel;
        }
        public SalesChannel(int id, string channel)
        {
            Id = id;
            Channel = channel;
        }
    }
}
