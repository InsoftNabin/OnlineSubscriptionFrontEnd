namespace DataProvider
{
    public class OrganizationProfileInfo
    {
        public int UnkId { get; set; }
        public int AccountType { get; set; }
        public int VatPercentage { get; set; }
        public int ServiceChargePercentage { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string BusinessMotto { get; set; }
        public string PanNo { get; set; }
        public string FiscalYear { get; set; }
        public string CurDateNepali { get; set; }
        public string CurDateEnglish { get; set; }
        public string Cmplogo { get; set; }
        public string EstdDate { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Initial { get; set; }
        public bool ViewType { get; set; }
        public bool UseOrder { get; set; }
        public bool UseCallWaiterFunction { get; set; }
        public bool UseOTPVerification { get; set; }
        public bool RequiredGuestInfo { get; set; }
        public bool UseDiscountCupon { get; set; }
    }
}
