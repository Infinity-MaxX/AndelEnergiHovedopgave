using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;

namespace AndelEnergiHovedopgave.Models
{
    public class CustomerEvent
    {
        //private DateTime _dateOfEvent;

        public int Id { get; set; }

        [NotNull]
        [JsonPropertyName("Month")]
        public DateTime DateOfEvent { get; set; }
        //public DateTime DateOfEvent 
        //{
        //    get {return _dateOfEvent; }
        //    set 
        //    { 
        //        if(value.Day != 1) 
        //        {
        //            throw new ArgumentException("DateOfEvent must be the first day of the month.");
        //        }
        //        else
        //        {
        //            _dateOfEvent = value;
        //        } 
 
        //    }
        //}
        [NotNull]
        [JsonPropertyName("CustomerTypeId")]
        public int CustomerTypeId { get; set; }

        [NotNull]
        [JsonPropertyName("ProductAreaId")]
        public int ProductAreaId { get; set; }

        [NotNull]
        [JsonPropertyName("SalesChannelId")]
        public int? SalesChannelId { get; set; }
        public int EventTypeId { get; set; }

        public int EventReasonId { get; set; }
        [NotNull]
        [JsonPropertyName("Count")]
        public int Count { get; set; }


        [JsonPropertyName("EventType")]
        public string OriginalEventType { get; set; }

        [JsonPropertyName("EventReason")]
        public string OriginalEventReason { get; set; }


        public CustomerEvent()
        {
            
        }

        public CustomerEvent(DateTime dateOfEvent, int productAreaId, int customerTypeId, int eventTypeId, int salesChannelId, int eventReason, int count)
        {
            DateOfEvent = dateOfEvent;
            ProductAreaId = productAreaId;
            CustomerTypeId = customerTypeId;
            EventTypeId = eventTypeId;
            SalesChannelId = salesChannelId;
            EventReasonId = eventReason;
            Count = count;
        }
        public CustomerEvent(int id, DateTime dateOfEvent, int productAreaId, int customerTypeId, int eventTypeId, int salesChannelId, int eventReason, int count)
        {
            Id = id;
            DateOfEvent = dateOfEvent;
            ProductAreaId = productAreaId;
            CustomerTypeId = customerTypeId;
            EventTypeId = eventTypeId;
            SalesChannelId = salesChannelId;
            EventReasonId = eventReason;
            Count = count;
        }
        /// <summary>
        /// Initializes a customer event with its date, classification, source details, and count.
        /// </summary>The date of the event.The identifier of the customer type.The identifier of the product area.The identifier of the sales channel.The original event type.The original reason for the event.The number of events.
        public CustomerEvent(DateTime dateOfEvent, int customerTypeId, int productAreaId, int salesChannelId, string originalEventType, string originalEventReason, int count)
        {

            DateOfEvent = dateOfEvent;
            ProductAreaId = productAreaId;
            CustomerTypeId = customerTypeId;
            OriginalEventType = originalEventType;
            SalesChannelId = salesChannelId;
            OriginalEventReason = originalEventReason;
            Count = count;
        }

        public override string ToString()
        {
            return $"Id: {Id}, DateOfEvent: {DateOfEvent}, ProductAreaId: {ProductAreaId}, CustomerTypeId: {CustomerTypeId}, EventTypeId: {EventTypeId} ,SalesChannelId: {SalesChannelId}, Count: {Count}";
        }

    }
}
