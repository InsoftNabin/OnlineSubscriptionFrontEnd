namespace OnlineSubscriptionFrontEnd.Models.Insoft
{
    public class SMSResponse
    {

        public string TokenNo { get; set; }
        public int? ukid { get; set; }
        public string ReceiverType { get; set; }
        public string ReceiverName { get; set; }
        public string MobileNo { get; set; }
        public string SMS_Message { get; set; }
        public DateTime? Date { get; set; }
        public string response_code { get; set; }
        public string Responsebody { get; set; }
        public string message_id { get; set; }
        public int? total_numbers { get; set; }
        public string balance_deducted { get; set; }
        public string SMS_Cost { get; set; }
        public string message_type { get; set; }
        public DateTime? c_date { get; set; }
        public int? C_user { get; set; }
        public DateTime? M_Date { get; set; }
        public int? M_User { get; set; }
        public string senderId { get; set; }
        public string schoolcode { get; set; }
        public bool? Active { get; set; }
    }
}
