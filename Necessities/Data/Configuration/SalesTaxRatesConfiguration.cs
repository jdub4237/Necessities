using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class SalesTaxRatesConfiguration : EntityTypeConfiguration<SalesTaxRate>
    {
        public SalesTaxRatesConfiguration()
        {
            ToTable("dbo.SalesTaxRates");
            HasKey(x => x.StartDate);
            
            Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
            Property(x => x.TaxRate).HasColumnName("TaxRate").IsRequired();
        }
    }
}