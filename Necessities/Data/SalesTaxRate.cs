using System;

namespace Necessities.Data
{
    public sealed class SalesTaxRate
    {
        public DateTime StartDate { get; set; } // StartDate (Primary key)
        public decimal TaxRate { get; set; } // TaxRate
    }
}