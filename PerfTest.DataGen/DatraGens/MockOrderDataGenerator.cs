using Bogus;
using PerfTest.DataGen.DomainModels;

namespace PerfTest.DataGen.DatraGens;

/// <summary>
/// Provides methods to generate mock order data for testing purposes.
/// </summary>
public class MockOrderDataGenerator
{
    private static readonly Faker Faker = new();

    /// <summary>
    /// Generates a random address.
    /// </summary>
    /// <returns>A new instance of <see cref="Address"/> with random values.</returns>
    public static Address GenerateAddress()
    {
        return new Address(
            Faker.Address.StreetAddress(),
            Faker.Address.City(),
            Faker.Address.ZipCode(),
            Faker.Address.Country()
        );
    }

    /// <summary>
    /// Generates a random customer.
    /// </summary>
    /// <returns>A new instance of <see cref="Customer"/> with random values.</returns>
    public static Customer GenerateCustomer()
    {
        return new Customer(
            Guid.NewGuid(),
            Faker.Name.FullName(),
            Faker.Internet.Email(),
            GenerateAddress()
        );
    }

    /// <summary>
    /// Generates a list of random order items.
    /// </summary>
    /// <param name="itemCount">The number of items to generate (default is 3).</param>
    /// <returns>A list of <see cref="OrderItem"/> instances.</returns>
    public static List<OrderItem> GenerateOrderItems(int itemCount = 3)
    {
        var items = new List<OrderItem>();

        for (int i = 0; i < itemCount; i++)
        {
            items.Add(new OrderItem(
                Guid.NewGuid(),
                Faker.Commerce.ProductName(),
                Faker.Random.Int(1, 5),
                Faker.Random.Decimal(5, 1000)
            ));
        }

        return items;
    }

    /// <summary>
    /// Generates a random order with associated customer and items.
    /// </summary>
    /// <returns>A new instance of <see cref="Order"/> with random values.</returns>
    public static Order GenerateOrder(int count = 1)
    {
        var items = GenerateOrderItems(count);
        return new Order(
            Guid.NewGuid(),
            GenerateCustomer(),
            items,
            CalculateTotalAmount(items),
            Faker.PickRandom<OrderStatus>(),
            DateTime.UtcNow
        );
    }

    /// <summary>
    /// Calculates the total amount of an order based on its items.
    /// </summary>
    /// <param name="items">The list of order items.</param>
    /// <returns>The total cost of the order.</returns>
    private static decimal CalculateTotalAmount(List<OrderItem> items)
    {
        decimal total = 0;
        foreach (var item in items)
        {
            total += item.Quantity * item.Price;
        }
        return total;
    }
}
