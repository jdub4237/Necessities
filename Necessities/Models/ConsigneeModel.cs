using System;

namespace Necessities.Models
{
    public class ConsigneeModel
    {
        public int ConsigneeId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string AddressOne { get; set; } 
        public string AddressTwo { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        public string PostalCode { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public Percentage Percentage { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}