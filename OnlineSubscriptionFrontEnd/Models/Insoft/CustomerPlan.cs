﻿namespace OnlineSubscriptionFrontEnd.Models.Insoft
{
    public class CustomerPlan
    {
        public int fonepayTraceId { get; set; }
        public int CustomerId { get; set; }
        public string TokenNo { get; set; }
        public int ProductId { get; set; }
        public string ExpiryDate { get; set; }
        public int TransactionId { get; set; }
        public string Remarks { get; set; }
        public string PaymentMethod { get; set; }
        public int ReferenceId { get; set; }
        public string PaymentPartner { get; set; }
        public float PaidAmount { get; set; }
        public string GeneratedSerialNo { get; set; }
        public int SubscriptionType { get; set; }
        public string Machinekey { get; set; }
        public string SubscriptionPlan { get; set; }
        public int Id { get; set; }
        public string VoucherImage { get; set; }
        public string ActualExpiryDate { get; set; }
        public int IsVerifiedPayment { get; set; }
        //public List<ImageData> ImageFile { get; set; }

    }
}
