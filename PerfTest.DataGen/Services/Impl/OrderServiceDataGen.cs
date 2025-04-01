using Microsoft.Extensions.Caching.Memory;
using PerfTest.DataGen.DatraGens;
using PerfTest.DataGen.DomainModels;

namespace PerfTest.DataGen.Services.Impl;

public class OrderServiceDataGen : IOrderServiceDataGen
{
    private readonly IMemoryCache _memoryCache;
    public OrderServiceDataGen(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Order GetOrders(int count = 10000)
    {
        string cacheKey = $"order_{count}";

        // Try to get the order from cache
        if (!_memoryCache.TryGetValue(cacheKey, out Order order))
        {
            // If not found in cache, fetch from the database (simulated)
            order = MockOrderDataGenerator.GenerateOrder(count);

            // Set cache options (expires in 1 minute)
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));

            // Save in cache
            _memoryCache.Set(cacheKey, order, cacheEntryOptions);
        }

        return order;
    }
}
