
namespace OnlineSubscriptionFrontEnd.Models
{
    public class SendCode
    {
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public string Gcode { get; set; }
    }
}