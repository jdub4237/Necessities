using System;
using System.Collections.Generic;

namespace Necessities.Models
{
    public class SaleModel
    {
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public decimal TaxRate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public List<SaleItemModel> SaleItems { get; set; }
    }

    public class SaleItemModel
    {
        public int SaleItemId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int ItemTypeId { get; set; }

        public int ConsigneeId { get; set; }

        public int SaleId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}