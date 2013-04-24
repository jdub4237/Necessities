using System;
using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class ConsigeePayment
    {
        public int ConsigneePaymentId { get; set; } // ConsigneePaymentId (Primary key)
        public DateTime Date { get; set; } // Date
        public string Description { get; set; } // Description
        public int ConsigneeId { get; set; } // ConsigneeId
        public DateTime CreationDate { get; set; } // CreationDate
        public DateTime UpdatedDate { get; set; } // UpdatedDate

        // Reverse navigation
        public ICollection<ConsigneePaymentSalesItem> ConsigneePaymentSalesItems { get; set; } // ConsigneePaymentSalesItem.FK_ConsigneePayments_ConsigneePaymentSalesItems_ConsigneePaymentId;

        // Foreign keys
        public Consignee Consignee { get; set; } //  ConsigneeId - FK_Consignees_ConsigneePayments_ConsigneeId

        public ConsigeePayment()
        {
            ConsigneePaymentSalesItems = new List<ConsigneePaymentSalesItem>();
        }
    }
}