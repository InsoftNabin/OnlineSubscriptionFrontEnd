namespace OnlineSubscriptionFrontEnd.Models.FonePay
{
    public class PaymentStatusResponse
    {
        public string prn { get; set; }
        public string merchantCode { get; set; }
        public string paymentStatus { get; set; }
        public int fonepayTraceId { get; set; }
        public float requestedAmount { get; set; }
        public float totalTransactionAmount { get; set; }

    }
}
