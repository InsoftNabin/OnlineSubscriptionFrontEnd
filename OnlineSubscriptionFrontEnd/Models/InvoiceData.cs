namespace OnlineSubscriptionFrontEnd.Models
{
    public class InvoiceData
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Product { get; set; }
        public string PlanName { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public string PaymentGateway { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Vat { get; set; }
        public decimal Subtotal { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
    }
}