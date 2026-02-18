using System;
using System.Text.Json;
using SubscriptionAPI.Models;

namespace SubscriptionAPI.Services
{

    public class SubscriptionGenerator
    {
        private static readonly Random _random = new Random();
        private static readonly string[] _currencies = { "USD", "EUR", "GBP", "BDT", "INR" };
        private static readonly string[] _frequencies = { "DAILY", "WEEKLY", "MONTHLY", "QUARTERLY", "YEARLY" };
        private static readonly string[] _subscriptionTypes = { "PREMIUM", "STANDARD", "BASIC", "ENTERPRISE" };
        private static readonly string[] _payerTypes = { "INDIVIDUAL", "BUSINESS", "CORPORATE" };
        private static readonly string[] _paymentTypes = { "CREDIT_CARD", "DEBIT_CARD", "BANK_TRANSFER", "MOBILE_WALLET" };


        public SubscriptionModel GenerateRandomSubscription()
        {
            var startDate = DateTime.Now.AddDays(_random.Next(0, 30));
            var expiryDate = startDate.AddMonths(_random.Next(1, 12));

            return new SubscriptionModel
            {
                Amount = (_random.Next(10, 1000) + _random.NextDouble()).ToString("F2"),
                FirstPaymentIncludedInCycle = _random.Next(0, 2) == 0 ? "true" : "false",
                ServiceId = $"SVC{_random.Next(10000, 99999)}",
                Currency = _currencies[_random.Next(_currencies.Length)],
                StartDate = startDate.ToString("yyyy-MM-dd"),
                ExpiryDate = expiryDate.ToString("yyyy-MM-dd"),
                Frequency = _frequencies[_random.Next(_frequencies.Length)],
                SubscriptionType = _subscriptionTypes[_random.Next(_subscriptionTypes.Length)],
                MaxCapRequired = _random.Next(0, 2) == 0 ? "true" : "false",
                MerchantShortCode = $"MRC{_random.Next(1000, 9999)}",
                PayerType = _payerTypes[_random.Next(_payerTypes.Length)],
                PaymentType = _paymentTypes[_random.Next(_paymentTypes.Length)],
                RedirectUrl = $"https://example.com/redirect/{Guid.NewGuid()}",
                SubscriptionRequestId = Guid.NewGuid().ToString(),
                SubscriptionReference = $"REF{_random.Next(100000, 999999)}",
                Ckey = Guid.NewGuid().ToString("N")
            };
        }


        public string GenerateRandomSubscriptionAsJson()
        {
            var subscription = GenerateRandomSubscription();
            
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Serialize(subscription, options);
        }
    }
}
