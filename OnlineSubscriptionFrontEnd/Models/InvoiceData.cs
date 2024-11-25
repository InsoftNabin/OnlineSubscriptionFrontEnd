namespace OnlineSubscriptionFrontEnd.Models
{
    public class InvoiceData
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Product { get; set; }
        public string PlanName { get; set; }
        public float Amount { get; set; }
        public string TransactionId { get; set; }
        public string PaymentGateway { get; set; }
        public float TotalAmount { get; set; }
        public float Vat { get; set; }
        public float Subtotal { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public int unqId { get; set; }
    }
}