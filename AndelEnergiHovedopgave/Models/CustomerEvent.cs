using System;
using System.Collections.Generic;
using System.Text;

namespace AndelEnergiHovedopgave.Models
{
    public class CustomerEvent
    {
        public int Id { get; set; }
        public DateTime DateOfEvent { get; set; }
        public CustomerType CustomerType { get; set; }
        public ProductType ProductType { get; set; }
        public SalesChannel SalesChannel { get; set; }
        public string EventReason { get; set; }
        public int Count { get; set; }

        public CustomerEvent()
        {
            
        }
        public CustomerEvent(DateTime dateOfEvent, CustomerType customerType, ProductType productType, SalesChannel salesChannel)
        {
            DateOfEvent = dateOfEvent;
            CustomerType = customerType;
            ProductType = productType;
            SalesChannel = salesChannel;
        }
        public CustomerEvent(int id, DateTime dateOfEvent, CustomerType customerType, ProductType productType, SalesChannel salesChannel)
        {
            Id = id;
            DateOfEvent = dateOfEvent;
            CustomerType = customerType;
            ProductType = productType;
            SalesChannel = salesChannel;
        }

        public override string ToString()
        {
            return $"Id: {Id}, DateOfEvent: {DateOfEvent}, CustomerType: {CustomerType.Type}, ProductType: {ProductType.Type}, SalesChannel: {SalesChannel.Channel}";
        }

    }
}
