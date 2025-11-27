namespace M07.DataProtection.Requests;

public class CreateBidRequest
{
    public decimal Amount { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Address { get; set; } = null!;
}