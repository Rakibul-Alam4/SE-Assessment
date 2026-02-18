using Newtonsoft.Json;

namespace BkashApiIntegration.Models
{
    public class BkashSubscriptionRequest
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("firstPaymentIncludedInCycle")]
        public string FirstPaymentIncludedInCycle { get; set; }

        [JsonProperty("serviceId")]
        public string ServiceId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("expiryDate")]
        public string ExpiryDate { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("subscriptionType")]
        public string SubscriptionType { get; set; }

        [JsonProperty("maxCapRequired")]
        public string MaxCapRequired { get; set; }

        [JsonProperty("merchantShortCode")]
        public string MerchantShortCode { get; set; }

        [JsonProperty("payerType")]
        public string PayerType { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("subscriptionRequestId")]
        public string SubscriptionRequestId { get; set; }

        [JsonProperty("subscriptionReference")]
        public string SubscriptionReference { get; set; }

        [JsonProperty("ckey")]
        public string Ckey { get; set; }
    }
}
