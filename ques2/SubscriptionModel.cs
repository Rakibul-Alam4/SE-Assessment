namespace SubscriptionAPI.Models
{

    public class SubscriptionModel
    {
        public string Amount { get; set; } = string.Empty;
        public string FirstPaymentIncludedInCycle { get; set; } = string.Empty;
        public string ServiceId { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string SubscriptionType { get; set; } = string.Empty;
        public string MaxCapRequired { get; set; } = string.Empty;
        public string MerchantShortCode { get; set; } = string.Empty;
        public string PayerType { get; set; } = string.Empty;
        public string PaymentType { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = string.Empty;
        public string SubscriptionRequestId { get; set; } = string.Empty;
        public string SubscriptionReference { get; set; } = string.Empty;
        public string Ckey { get; set; } = string.Empty;
    }
}
