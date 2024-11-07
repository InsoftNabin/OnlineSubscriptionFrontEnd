namespace OnlineSubscriptionFrontEnd.Models.FonePay
{
    public class PaymentStatusRequest
    {
        public string prn { get; set; }
        public string merchantCode { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string qrHashKey { get; set; }

    }
}
