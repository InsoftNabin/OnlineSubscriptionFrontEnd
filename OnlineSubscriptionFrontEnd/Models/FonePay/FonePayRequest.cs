namespace OnlineSubscriptionFrontEnd.Models.FonePay
{
    public class FonePayRequest
    {
        public float amount { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string merchantCode { get; set; }
        public string SecretKey { get; set; }
        public string prn { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Purpose { get; set; }
    }
}
