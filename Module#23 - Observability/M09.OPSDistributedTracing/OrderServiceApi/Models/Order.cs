namespace OrderServiceApi.Models;


public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? PaidAt { get; set; }
    public string? PaymentReference { get; set; }
    public decimal TotalAmount => Items.Sum(i => i.Total);
    public List<OrderItem> Items { get; set; } = [];

    private Order() { }
    public Order(Guid customerId, List<OrderItem> items)
    {
        if (items is null || items.Count == 0)
            throw new ArgumentException("Order must have at least one item.");
            
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        Items = [.. items];
    }
}