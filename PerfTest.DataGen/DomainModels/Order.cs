namespace PerfTest.DataGen.DomainModels;

/// <summary>
/// Represents a customer order in the shop.
/// </summary>
/// <param name="Id">Unique identifier for the order.</param>
/// <param name="Customer">The customer who placed the order.</param>
/// <param name="Items">List of items included in the order.</param>
/// <param name="TotalAmount">Total cost of the order.</param>
/// <param name="Status">Current status of the order.</param>
/// <param name="CreatedAt">Timestamp when the order was created.</param>
public record Order(
    Guid Id,
    Customer Customer,
    List<OrderItem> Items,
    decimal TotalAmount,
    OrderStatus Status,
    DateTime CreatedAt
);

