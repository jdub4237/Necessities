using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class ConsigeePaymentsConfiguration : EntityTypeConfiguration<ConsigeePayment>
    {
        public ConsigeePaymentsConfiguration()
        {
            ToTable("dbo.ConsigeePayments");
            HasKey(x => x.ConsigneePaymentId);

            Property(x => x.ConsigneePaymentId).HasColumnName("ConsigneePaymentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Date).HasColumnName("Date").IsRequired();
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(50);
            Property(x => x.ConsigneeId).HasColumnName("ConsigneeId").IsRequired();
            Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();

            // Foreign keys
            HasRequired(a => a.Consignee).WithMany(b => b.ConsigeePayments).HasForeignKey(c => c.ConsigneeId); // FK_Consignees_ConsigneePayments_ConsigneeId
        }
    }
}