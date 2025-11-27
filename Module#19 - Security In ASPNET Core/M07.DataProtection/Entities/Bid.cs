namespace M07.DataProtection.Entities;

public class Bid
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime BidDate { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string Address { get; set; } = null!;
}