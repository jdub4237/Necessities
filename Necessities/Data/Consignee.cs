using System;
using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class Consignee
    {
        public int ConsigneeId { get; set; } // ConsigneeId (Primary key)
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string AddressOne { get; set; } // AddressOne
        public string AddressTwo { get; set; } // AddressTwo
        public string City { get; set; } // City
        public string State { get; set; } // State
        public string PostalCode { get; set; } // PostalCode
        public string PhoneNumber { get; set; } // PhoneNumber
        public string Email { get; set; } // Email
        public decimal Percentage { get; set; } // Percentage
        public DateTime CreationDate { get; set; } // CreationDate
        public DateTime UpdatedDate { get; set; } // UpdatedDate

        // Reverse navigation
        public ICollection<ConsigeePayment> ConsigeePayments { get; set; } // ConsigeePayment.FK_Consignees_ConsigneePayments_ConsigneeId;
        public ICollection<SalesItem> SalesItems { get; set; } // SalesItem.FK_Consignees_SaleItems_CosnigneeId;

        public Consignee()
        {
            ConsigeePayments = new List<ConsigeePayment>();
            SalesItems = new List<SalesItem>();
        }
    }
}