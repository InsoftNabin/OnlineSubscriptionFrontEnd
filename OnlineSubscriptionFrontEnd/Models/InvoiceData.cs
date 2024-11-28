namespace OnlineSubscriptionFrontEnd.Models
{
    public class InvoiceData
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Product { get; set; }
        public string PlanName { get; set; }
        public string Amount { get; set; }
        public string TransactionId { get; set; }
        public string PaymentGateway { get; set; }
        public string TotalAmount { get; set; }
        public string Vat { get; set; }
        public string Subtotal { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public int? unqId { get; set; }
    }
}