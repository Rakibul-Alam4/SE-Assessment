using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BkashApiIntegration.Models;
using Newtonsoft.Json;

namespace BkashApiIntegration.Services
{
    public class BkashApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://bkashtest.shabox.mobi/home/MultiTournamentInBuildCheckoutUrl";
        private const string ApiKey = "796b8b9dbbf46b1d8fd73f68979ae31635da9afabc9dee147adf0440ee7118a8";

        public BkashApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("api-key", ApiKey);
        }

        public BkashSubscriptionRequest CreateSubscriptionRequest(
            string phoneNumber,
            decimal amount = 1,
            string frequency = "MONTHLY")
        {
            var startDate = DateTime.Now;
            var expiryDate = frequency switch
            {
                "DAILY" => startDate.AddDays(30),
                "WEEKLY" => startDate.AddMonths(3),
                "MONTHLY" => startDate.AddYears(1),
                _ => startDate.AddYears(1)
            };

            return new BkashSubscriptionRequest
            {
                Amount = amount.ToString(),
                FirstPaymentIncludedInCycle = "True",
                ServiceId = "100001",
                Currency = "BDT",
                StartDate = startDate.ToString("yyyy-MM-dd HH:mm:ss"),
                ExpiryDate = expiryDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Frequency = frequency,
                SubscriptionType = "BASIC",
                MaxCapRequired = "False",
                MerchantShortCode = "01307153119",
                PayerType = "CUSTOMER",
                PaymentType = "FIXED",
                RedirectUrl = "https://www.example.com/payment-success",
                SubscriptionRequestId = GenerateUniqueSubscriptionRequestId(),
                SubscriptionReference = phoneNumber,
                Ckey = "000001"
            };
        }

        private string GenerateUniqueSubscriptionRequestId()
        {
            // Generate unique subscription request ID using timestamp and GUID
            var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var guid = Guid.NewGuid().ToString("N").Substring(0, 8);
            return $"SUB{timestamp}{guid}";
        }

        public async Task<string> SendSubscriptionRequestAsync(BkashSubscriptionRequest request)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(request, Formatting.Indented);
                Console.WriteLine("=== Request Payload ===");
                Console.WriteLine(jsonContent);
                Console.WriteLine("=======================\n");

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(ApiUrl, content);

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine("=== Response ===");
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Body: {responseContent}");
                Console.WriteLine("================\n");

                return responseContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
