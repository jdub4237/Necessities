using System;
using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class SalesItem
    {
        public int SalesItemId { get; set; } // SalesItemId (Primary key)
        public decimal Amount { get; set; } // Amount
        public string Description { get; set; } // Description
        public int ItemTypeId { get; set; } // ItemTypeId
        public int ConsigneeId { get; set; } // ConsigneeId
        public int SalesId { get; set; } // SalesId
        public DateTime CreationDate { get; set; } // CreationDate
        public DateTime UpdatedDate { get; set; } // UpdatedDate

        // Reverse navigation
        public ICollection<ConsigneePaymentSalesItem> ConsigneePaymentSalesItems { get; set; } // ConsigneePaymentSalesItem.FK_SalesItems_ConsigneePaymentSalesItems_SalesItemId;

        // Foreign keys
        public ItemType ItemType { get; set; } //  ItemTypeId - FK_ItemTypes_SalesItems_ItemTypeId
        public Consignee Consignee { get; set; } //  ConsigneeId - FK_Consignees_SaleItems_CosnigneeId
        public Sale Sale { get; set; } //  SalesId - FK_Sales_SalesItems_SaleId

        public SalesItem()
        {
            ConsigneePaymentSalesItems = new List<ConsigneePaymentSalesItem>();
        }
    }
}