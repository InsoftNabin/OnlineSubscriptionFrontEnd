namespace OnlineSubscriptionFrontEnd.Models
{
    public class approveOrg
    {
        public string TokenNo { get; set; }
        public string Token { get; set; }
        public string SiteUserName { get; set; }
        public string SitePassword { get; set; }
        public string SiteURL { get; set; }
        public string Remarks { get; set; }
        public string RejectedReason { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int RedirectCode { get; set; }
    }
}