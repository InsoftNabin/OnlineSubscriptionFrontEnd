namespace OnlineSubscriptionFrontEnd.Models.FonePay
{
    public class FonePayResponse
    {
        public string hashKey { get; set; } = "";
        public string qrMessage { get; set; } = "";
        public string clientCode { get; set; } = "";
        public string status { get; set; } = "";
        public string statusCode { get; set; } = "";
        public string success { get; set; } = "";
        public string deviceId { get; set; } = "";
        public string requested_date { get; set; } = DateTime.Now.ToString();
        public string merchantCode { get; set; } = "";
        public string merchantWebSocketUrl { get; set; } = "";
        public string thirdpartyQrWebSocketUrl { get; set; } = "";
        public string nfcThirdPartyQrUrl { get; set; } = "";
    }
}
