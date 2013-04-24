using System.Collections.Generic;

namespace Necessities.Data
{
    public sealed class ItemType
    {
        public int ItemTypeId { get; set; } // ItemTypeId (Primary key)
        public string Description { get; set; } // Description
        public bool Active { get; set; } // Active

        // Reverse navigation
        public ICollection<SalesItem> SalesItems { get; set; } // SalesItem.FK_ItemTypes_SalesItems_ItemTypeId;

        public ItemType()
        {
            Active = true;
            SalesItems = new List<SalesItem>();
        }
    }
}