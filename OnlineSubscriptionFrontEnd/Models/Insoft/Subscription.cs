namespace OnlineSubscriptionFrontEnd.Models.Insoft
{
    public class Subscription
    {
        public string TokenNo { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int NoOfMonths { get; set; }
        public bool IsPaidBased { get; set; }
        public bool IsTrial { get; set; }

    }
}
