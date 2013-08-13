using System;
using System.ComponentModel.DataAnnotations;

namespace Necessities.Models
{
    public class ConsigneeModel
    {
        public int ConsigneeId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        public string AddressOne { get; set; } 
        public string AddressTwo { get; set; } 
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; } 
        public string PostalCode { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        [Required(ErrorMessage = "Percentage is required")]
        public decimal Percentage { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}