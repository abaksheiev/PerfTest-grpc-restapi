namespace PerfTest.Api.Dtos;

public class OrderDto
{
    public string OrderId { get; set; }
    public CustomerDto Customer { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public double TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }  // Use DateTime for timestamp
}

