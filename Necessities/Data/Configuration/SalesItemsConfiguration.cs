using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class SalesItemsConfiguration : EntityTypeConfiguration<SalesItem>
    {
        public SalesItemsConfiguration()
        {
            ToTable("dbo.SalesItems");
            HasKey(x => x.SalesItemId);

            Property(x => x.SalesItemId).HasColumnName("SalesItemId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Amount).HasColumnName("Amount").IsRequired();
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(50);
            Property(x => x.ItemTypeId).HasColumnName("ItemTypeId").IsRequired();
            Property(x => x.ConsigneeId).HasColumnName("ConsigneeId").IsRequired();
            Property(x => x.SalesId).HasColumnName("SalesId").IsRequired();
            Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();

            // Foreign keys
            HasRequired(a => a.ItemType).WithMany(b => b.SalesItems).HasForeignKey(c => c.ItemTypeId); // FK_ItemTypes_SalesItems_ItemTypeId
            HasRequired(a => a.Consignee).WithMany(b => b.SalesItems).HasForeignKey(c => c.ConsigneeId); // FK_Consignees_SaleItems_CosnigneeId
            HasRequired(a => a.Sale).WithMany(b => b.SalesItems).HasForeignKey(c => c.SalesId); // FK_Sales_SalesItems_SaleId
        }
    }
}