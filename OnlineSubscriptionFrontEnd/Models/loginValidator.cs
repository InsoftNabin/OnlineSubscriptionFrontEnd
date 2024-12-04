namespace OnlineSubscriptionFrontEnd.Models
{
    public class loginValidator
    {
        public int status { get; set; }
        public string message { get; set; }
        public string tokenNo { get; set; }
        public string UserName { get; set; }
        public int Customer { get; set; }
        public int Product { get; set; }
        public string Role { get; set; }
        public string Secret { get; set; }
    }
}