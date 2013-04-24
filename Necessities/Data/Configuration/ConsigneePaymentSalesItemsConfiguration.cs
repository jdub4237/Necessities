using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class ConsigneePaymentSalesItemsConfiguration : EntityTypeConfiguration<ConsigneePaymentSalesItem>
    {
        public ConsigneePaymentSalesItemsConfiguration()
        {
            ToTable("dbo.ConsigneePaymentSalesItems");
            HasKey(x => new { x.ConsigneePaymentId, x.SalesItemId });

            Property(x => x.ConsigneePaymentId).HasColumnName("ConsigneePaymentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SalesItemId).HasColumnName("SalesItemId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Amount).HasColumnName("Amount").IsRequired();

            // Foreign keys
            HasRequired(a => a.ConsigeePayment).WithMany(b => b.ConsigneePaymentSalesItems).HasForeignKey(c => c.ConsigneePaymentId); // FK_ConsigneePayments_ConsigneePaymentSalesItems_ConsigneePaymentId
            HasRequired(a => a.SalesItem).WithMany(b => b.ConsigneePaymentSalesItems).HasForeignKey(c => c.SalesItemId); // FK_SalesItems_ConsigneePaymentSalesItems_SalesItemId
        }
    }
}