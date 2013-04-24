namespace Necessities.Data
{
    public class ConsigneePaymentSalesItem
    {
        public int ConsigneePaymentId { get; set; } // ConsigneePaymentId (Primary key)
        public int SalesItemId { get; set; } // SalesItemId (Primary key)
        public decimal Amount { get; set; } // Amount

        // Foreign keys
        public virtual ConsigeePayment ConsigeePayment { get; set; } //  ConsigneePaymentId - FK_ConsigneePayments_ConsigneePaymentSalesItems_ConsigneePaymentId
        public virtual SalesItem SalesItem { get; set; } //  SalesItemId - FK_SalesItems_ConsigneePaymentSalesItems_SalesItemId
    }
}