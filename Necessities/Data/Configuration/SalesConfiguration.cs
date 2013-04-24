using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class SalesConfiguration : EntityTypeConfiguration<Sale>
    {
        public SalesConfiguration()
        {
            ToTable("dbo.Sales");
            HasKey(x => x.SaleId);

            Property(x => x.SaleId).HasColumnName("SaleId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Date).HasColumnName("Date").IsRequired();
            Property(x => x.TaxRate).HasColumnName("TaxRate").IsRequired();
            Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();
        }
    }
}