using System;
using SubscriptionAPI.Services;

namespace SubscriptionAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Subscription Generator Demo ===\n");
            
            var generator = new SubscriptionGenerator();
            

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Generated Subscription #{i}:");
                Console.WriteLine(new string('-', 60));
                
                string jsonResult = generator.GenerateRandomSubscriptionAsJson();
                Console.WriteLine(jsonResult);
                
                Console.WriteLine(new string('-', 60));
                Console.WriteLine();
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
