namespace PerfTest.DataGen.DomainModels;

/// <summary>
/// Represents the possible statuses of an order.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Order is pending and awaiting processing.
    /// </summary>
    Pending,

    /// <summary>
    /// Order is currently being processed.
    /// </summary>
    Processing,

    /// <summary>
    /// Order has been shipped.
    /// </summary>
    Shipped,

    /// <summary>
    /// Order has been delivered to the customer.
    /// </summary>
    Delivered,

    /// <summary>
    /// Order has been canceled.
    /// </summary>
    Canceled
}
