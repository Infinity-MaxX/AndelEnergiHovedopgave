using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class SalesChannel
    {
        [JsonPropertyName("SalesChannelId")]
        public int Id { get; set; }
        [JsonPropertyName("SalesChanne")]
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
