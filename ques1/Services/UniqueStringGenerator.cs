using System;

namespace UniqueStringApi.Services
{
    public class UniqueStringGenerator : IUniqueStringGenerator
    {
        private long _counter = 0;
        private readonly object _lock = new object();

        public string Generate()
        {
  
            long counter;
            lock (_lock)
            {
                counter = ++_counter;
            }

            var guid = Guid.NewGuid().ToString("N");
            var timestamp = DateTime.UtcNow.Ticks;
            
            return $"{guid}-{timestamp}-{counter}";
        }
    }
}
