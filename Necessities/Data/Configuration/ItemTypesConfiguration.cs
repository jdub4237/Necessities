using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class ItemTypesConfiguration : EntityTypeConfiguration<ItemType>
    {
        public ItemTypesConfiguration()
        {
            ToTable("dbo.ItemTypes");
            HasKey(x => x.ItemTypeId);

            Property(x => x.ItemTypeId).HasColumnName("ItemTypeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(50);
            Property(x => x.Active).HasColumnName("Active").IsRequired();
        }
    }
}