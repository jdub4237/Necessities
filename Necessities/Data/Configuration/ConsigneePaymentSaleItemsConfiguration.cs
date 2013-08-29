using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class ConsigneePaymentSaleItemsConfiguration : EntityTypeConfiguration<ConsigneePaymentSaleItem>
    {
        public ConsigneePaymentSaleItemsConfiguration()
        {
            ToTable("dbo.ConsigneePaymentSaleItems");
            HasKey(x => new { x.ConsigneePaymentId, x.SaleItemId });

            Property(x => x.ConsigneePaymentId).HasColumnName("ConsigneePaymentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SaleItemId).HasColumnName("SaleItemId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Amount).HasColumnName("Amount").IsRequired();

            // Foreign keys
            HasRequired(a => a.ConsigeePayment).WithMany(b => b.ConsigneePaymentSaleItems).HasForeignKey(c => c.ConsigneePaymentId); // FK_ConsigneePayments_ConsigneePaymentSaleItems_ConsigneePaymentId
            HasRequired(a => a.SaleItem).WithMany(b => b.ConsigneePaymentSaleItems).HasForeignKey(c => c.SaleItemId); // FK_SaleItems_ConsigneePaymentSaleItems_SaleItemId
        }
    }
}