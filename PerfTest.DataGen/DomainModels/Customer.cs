namespace PerfTest.DataGen.DomainModels;

/// <summary>
/// Represents a customer in the shop.
/// </summary>
/// <param name="Id">Unique identifier for the customer.</param>
/// <param name="Name">Name of the customer.</param>
/// <param name="Email">Email address of the customer.</param>
/// <param name="ShippingAddress">Shipping address for the customer.</param>
public record Customer(
    Guid Id,
    string Name,
    string Email,
    Address ShippingAddress
);
