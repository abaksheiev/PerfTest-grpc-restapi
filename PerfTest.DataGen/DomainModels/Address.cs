namespace PerfTest.DataGen.DomainModels;

/// <summary>
/// Represents the shipping address for a customer order.
/// </summary>
/// <param name="Street">Street address of the shipping location.</param>
/// <param name="City">City of the shipping address.</param>
/// <param name="PostalCode">Postal code of the shipping address.</param>
/// <param name="Country">Country of the shipping address.</param>
public record Address(
    string Street,
    string City,
    string PostalCode,
    string Country
);

