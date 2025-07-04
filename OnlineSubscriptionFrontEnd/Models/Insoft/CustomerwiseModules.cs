﻿namespace OnlineSubscriptionFrontEnd.Models.Insoft
{

    public class CustomerwiseModules
    {
        public string? TokenNo { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int AgentId { get; set; }
        public float TotalPrice { get; set; }
        public string LatestLicenseKey { get; set; }
        public string MachineKey { get; set; }
        public string Initial { get; set; }
        public int IsPaidBased { get; set; }
        public string SerialNumber { get; set; }
        public  float InitialPaymentAmount { get; set; }
        public string SiteURL { get; set; }
        public string Sukey { get; set; }
        public bool Active { get; set; }
        public List<SubProduct> subProducts { get; set; }
    }

    public class SubProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubProductId { get; set; }
        public string JoinDate { get; set; }
        public string LastRenewDate { get; set; }
        public string ExpiryDate { get; set; }
        public string clientGUID { get; set; }
        public string ProductGUID { get; set; }
        public string MachineKey { get; set; }

        public float MonthlyCharge { get; set; }
        public string Remarks { get; set; }
        public int Plan { get; set; }
    }
}
