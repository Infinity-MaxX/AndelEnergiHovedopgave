using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class CustomerEvent
    {
        public int Id { get; set; }
        [JsonPropertyName("Month")]
        public DateTime DateOfEvent { get; set; }

        [JsonPropertyName("CustomerTypeId")]
        public CustomerType CustomerType { get; set; }
        
        [JsonPropertyName("ProductAreaId")]
        public ProductArea ProductArea { get; set; }
        
        [JsonPropertyName("SalesChannelId")]
        public SalesChannel SalesChannel { get; set; }

        [JsonPropertyName("EventReason")]
        public string EventReason { get; set; }

        [JsonPropertyName("Count")]
        public int Count { get; set; }

        public CustomerEvent()
        {
            
        }
        public CustomerEvent(DateTime dateOfEvent, CustomerType customerType, ProductArea ProductArea, SalesChannel salesChannel)
        {
            DateOfEvent = dateOfEvent;
            CustomerType = customerType;
            ProductArea = ProductArea;
            SalesChannel = salesChannel;
        }
        public CustomerEvent(int id, DateTime dateOfEvent, CustomerType customerType, ProductArea ProductArea, SalesChannel salesChannel)
        {
            Id = id;
            DateOfEvent = dateOfEvent;
            CustomerType = customerType;
            ProductArea = ProductArea;
            SalesChannel = salesChannel;
        }

        public override string ToString()
        {
            return $"Id: {Id}, DateOfEvent: {DateOfEvent}, CustomerType: {CustomerType.Type}, ProductArea: {ProductArea.Area}, SalesChannel: {SalesChannel.Channel}";
        }

    }
}
