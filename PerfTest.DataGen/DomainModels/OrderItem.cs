namespace PerfTest.DataGen.DomainModels;

/// <summary>
/// Represents an item within an order.
/// </summary>
/// <param name="Id">Unique identifier for the order item.</param>
/// <param name="Name">Name of the product in the order.</param>
/// <param name="Quantity">Quantity of the product in the order.</param>
/// <param name="Price">Price of the product per unit.</param>
public record OrderItem(
    Guid Id,
    string Name,
    int Quantity,
    decimal Price
);
