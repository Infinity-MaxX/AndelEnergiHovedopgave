using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class CustomerEvent
    {
        private DateTime _dateOfEvent;

        public int Id { get; set; }
        [JsonPropertyName("Month")]

        public DateTime DateOfEvent 
        {
            get {return _dateOfEvent; }
            set 
            { 
                if(value.Day != 1) 
                {
                    throw new ArgumentException("DateOfEvent must be the first day of the month.");
                }
                else
                {
                    _dateOfEvent = value;
                } 
 
            }
        }

        [JsonPropertyName("CustomerTypeId")]
        public int CustomerTypeId { get; set; }
        
        [JsonPropertyName("ProductAreaId")]
        public int ProductAreaId { get; set; }
        
        [JsonPropertyName("SalesChannelId")]
        public int SalesChannelId { get; set; }
        public int EventTypeId { get; set; }

        public int EventReasonId { get; set; }

        [JsonPropertyName("Count")]
        public int Count { get; set; }


        [JsonPropertyName("EventType")]
        public string OriginalEventType { get; set; }

        [JsonPropertyName("EventReason")]
        public string OriginalEventReason { get; set; }


        public CustomerEvent()
        {
            
        }

        public CustomerEvent(DateTime dateOfEvent, int customerTypeId, int productAreaId, int salesChannelId,int eventReason ,int count)
        {

            DateOfEvent = dateOfEvent;
            CustomerTypeId = customerTypeId;
            ProductAreaId = productAreaId;
            SalesChannelId = salesChannelId;
            EventReasonId = eventReason;
            Count = count;
        }
        public CustomerEvent(DateTime dateOfEvent, int customerTypeId, int productAreaId, int salesChannelId,string originalEventType, string originalEventReason, int count)
        {

            DateOfEvent = dateOfEvent;
            CustomerTypeId = customerTypeId;
            ProductAreaId = productAreaId;
            SalesChannelId = salesChannelId;
            OriginalEventType = originalEventType;
            OriginalEventReason = originalEventReason;
            Count = count;
        }
        public CustomerEvent(int id, DateTime dateOfEvent, int customerTypeId, int productAreaId, int salesChannelId, int eventReason, int count)
        {
            Id = id;
            DateOfEvent = dateOfEvent;
            CustomerTypeId = customerTypeId;
            ProductAreaId = productAreaId;
            SalesChannelId = salesChannelId;
            EventReasonId = eventReason;
            Count = count;
        }

        public override string ToString()
        {
            return $"Id: {Id}, DateOfEvent: {DateOfEvent}, CustomerTypeId: {CustomerTypeId}, ProductAreaId: {ProductAreaId}, SalesChannelId: {SalesChannelId            }";
        }

    }
}
