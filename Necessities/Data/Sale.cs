using System;
using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class Sale
    {
        public int SaleId { get; set; } // SaleId (Primary key)
        public DateTime Date { get; set; } // Date
        public decimal TaxRate { get; set; } // TaxRate
        public DateTime CreationDate { get; set; } // CreationDate
        public DateTime UpdatedDate { get; set; } // UpdatedDate

        // Reverse navigation
        public ICollection<SaleItem> SaleItems { get; set; } // SaleItem.FK_Sales_SaleItems_SaleId;

        public Sale()
        {
            SaleItems = new List<SaleItem>();
        }
    }
}