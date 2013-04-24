using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Necessities.Data.Configuration
{
    public class ConsigneesConfiguration : EntityTypeConfiguration<Consignee>
    {
        public ConsigneesConfiguration()
        {
            ToTable("dbo.Consignees");
            HasKey(x => x.ConsigneeId);

            Property(x => x.ConsigneeId).HasColumnName("ConsigneeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(15);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(15);
            Property(x => x.AddressOne).HasColumnName("AddressOne").IsRequired().HasMaxLength(50);
            Property(x => x.AddressTwo).HasColumnName("AddressTwo").IsRequired().HasMaxLength(50);
            Property(x => x.City).HasColumnName("City").IsRequired().HasMaxLength(50);
            Property(x => x.State).HasColumnName("State").IsRequired().HasMaxLength(2);
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsRequired().HasMaxLength(10);
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(10);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(300);
            Property(x => x.Percentage).HasColumnName("Percentage").IsRequired();
            Property(x => x.CreationDate).HasColumnName("CreationDate").IsRequired();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsRequired();
        }
    }
}