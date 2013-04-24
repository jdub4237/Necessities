using System.Data.Entity;
using Necessities.Data.Configuration;

namespace Necessities.Data
{
    public class NecessitiesContext : DbContext
    {
        public IDbSet<ConsigeePayment> ConsigeePayments { get; set; } // ConsigeePayment
        public IDbSet<ConsigneePaymentSalesItem> ConsigneePaymentSalesItems { get; set; } // ConsigneePaymentSalesItem
        public IDbSet<Consignee> Consignees { get; set; } // Consignee
        public IDbSet<ItemType> ItemTypes { get; set; } // ItemType
        public IDbSet<Sale> Sales { get; set; } // Sale
        public IDbSet<SalesItem> SalesItems { get; set; } // SalesItem
        public IDbSet<SalesTaxRate> SalesTaxRates { get; set; } 

        static NecessitiesContext()
        {
            Database.SetInitializer<NecessitiesContext>(null);
        }

        public NecessitiesContext()
            : base("Necessities123")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ConsigeePaymentsConfiguration());
            modelBuilder.Configurations.Add(new ConsigneePaymentSalesItemsConfiguration());
            modelBuilder.Configurations.Add(new ConsigneesConfiguration());
            modelBuilder.Configurations.Add(new ItemTypesConfiguration());
            modelBuilder.Configurations.Add(new SalesConfiguration());
            modelBuilder.Configurations.Add(new SalesItemsConfiguration());
            modelBuilder.Configurations.Add(new SalesTaxRatesConfiguration());
        }
    }
}