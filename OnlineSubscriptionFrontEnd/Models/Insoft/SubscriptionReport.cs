namespace OnlineSubscriptionFrontEnd.Models.Insoft
{
    public class SubscriptionReport
    {
        public string TokenNo { get; set; }
        public int RemainingDays { get; set; }
        public string LicenseKey { get; set; }
        public string MachineKey { get; set; }
        public string SubscriptionGUID { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string initial { get; set; }
        public string ProductName { get; set; }
    }
}
