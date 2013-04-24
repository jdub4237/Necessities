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
        public ICollection<SalesItem> SalesItems { get; set; } // SalesItem.FK_Sales_SalesItems_SaleId;

        public Sale()
        {
            SalesItems = new List<SalesItem>();
        }
    }
}