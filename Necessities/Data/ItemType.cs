using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class ItemType
    {
        public int ItemTypeId { get; set; } // ItemTypeId (Primary key)
        public string Description { get; set; } // Description
        public bool Active { get; set; } // Active

        // Reverse navigation
        public ICollection<SaleItem> SaleItems { get; set; } // SaleItem.FK_ItemTypes_SaleItems_ItemTypeId;

        public ItemType()
        {
            Active = true;
            SaleItems = new List<SaleItem>();
        }
    }
}