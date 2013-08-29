using System;
using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class SaleItem
    {
        public int SaleItemId { get; set; } // SaleItemId (Primary key)
        public decimal Amount { get; set; } // Amount
        public string Description { get; set; } // Description
        public int ItemTypeId { get; set; } // ItemTypeId
        public int ConsigneeId { get; set; } // ConsigneeId
        public int SaleId { get; set; } // SaleId
        public DateTime CreationDate { get; set; } // CreationDate
        public DateTime UpdatedDate { get; set; } // UpdatedDate

        // Reverse navigation
        public ICollection<ConsigneePaymentSaleItem> ConsigneePaymentSaleItems { get; set; } // ConsigneePaymentSaleItem.FK_SaleItems_ConsigneePaymentSaleItems_SaleItemId;

        // Foreign keys
        public ItemType ItemType { get; set; } //  ItemTypeId - FK_ItemTypes_SaleItems_ItemTypeId
        public Consignee Consignee { get; set; } //  ConsigneeId - FK_Consignees_SaleItems_CosnigneeId
        public Sale Sale { get; set; } //  SaleId - FK_Sales_SaleItems_SaleId

        public SaleItem()
        {
            ConsigneePaymentSaleItems = new List<ConsigneePaymentSaleItem>();
        }
    }
}