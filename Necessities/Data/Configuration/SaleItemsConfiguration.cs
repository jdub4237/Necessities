using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class SaleItemsConfiguration : EntityTypeConfiguration<SaleItem>
    {
        public SaleItemsConfiguration()
        {
            ToTable("dbo.SaleItems");
            HasKey(x => x.SaleItemId);

            Property(x => x.SaleItemId).HasColumnName("SaleItemId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Amount).HasColumnName("Amount").IsRequired();
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(50);
            Property(x => x.ItemTypeId).HasColumnName("ItemTypeId").IsRequired();
            Property(x => x.ConsigneeId).HasColumnName("ConsigneeId").IsRequired();
            Property(x => x.SaleId).HasColumnName("SaleId").IsRequired();
            Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();

            // Foreign keys
            HasRequired(a => a.ItemType).WithMany(b => b.SaleItems).HasForeignKey(c => c.ItemTypeId); // FK_ItemTypes_SaleItems_ItemTypeId
            HasRequired(a => a.Consignee).WithMany(b => b.SaleItems).HasForeignKey(c => c.ConsigneeId); // FK_Consignees_SaleItems_CosnigneeId
            HasRequired(a => a.Sale).WithMany(b => b.SaleItems).HasForeignKey(c => c.SaleId); // FK_Sales_SaleItems_SaleId
        }
    }
}