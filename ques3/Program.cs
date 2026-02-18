using System;
using System.Threading.Tasks;
using BkashApiIntegration.Services;

namespace BkashApiIntegration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== bKash Subscription API Integration ===\n");


            var bkashService = new BkashApiService();

            // You can customize these parameters
            string phoneNumber = "01712345678";  //  phone number
            decimal amount = 1;                   // Amount in BDT
            string frequency = "MONTHLY";         // DAILY, WEEKLY, or MONTHLY

            Console.WriteLine("Creating subscription request...");
            
            // Create the subscription request with auto-generated fields
            var request = bkashService.CreateSubscriptionRequest(
                phoneNumber: phoneNumber,
                amount: amount,
                frequency: frequency
            );

            // Send the request to bKash API
            Console.WriteLine("Sending request to bKash API...\n");
            var response = await bkashService.SendSubscriptionRequestAsync(request);

            if (response != null)
            {
                Console.WriteLine("\nRequest completed successfully!");
            }
            else
            {
                Console.WriteLine("\nRequest failed. Please check the error message above.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
