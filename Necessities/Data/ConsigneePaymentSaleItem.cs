namespace Necessities.Data
{
    public class ConsigneePaymentSaleItem
    {
        public int ConsigneePaymentId { get; set; } // ConsigneePaymentId (Primary key)
        public int SaleItemId { get; set; } // SaleItemId (Primary key)
        public decimal Amount { get; set; } // Amount

        // Foreign keys
        public virtual ConsigeePayment ConsigeePayment { get; set; } //  ConsigneePaymentId - FK_ConsigneePayments_ConsigneePaymentSaleItems_ConsigneePaymentId
        public virtual SaleItem SaleItem { get; set; } //  SaleItemId - FK_SaleItems_ConsigneePaymentSaleItems_SaleItemId
    }
}