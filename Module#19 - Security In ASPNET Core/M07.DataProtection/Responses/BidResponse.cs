using M07.DataProtection.Entities;
using Microsoft.AspNetCore.DataProtection;

namespace M07.DataProtection.Responses;

public class BidResponse
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime BidDate { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string Address { get; set; } = null!;

    public static BidResponse FromModel(Bid bid, IDataProtector protector)
    {
        ArgumentNullException.ThrowIfNull(bid);

        return new BidResponse
        {
            Id = bid.Id,
            Amount = bid.Amount,
            BidDate = bid.BidDate,
            FirstName = protector.Unprotect(bid.FirstName),
            LastName = protector.Unprotect(bid.LastName),
            Email = protector.Unprotect(bid.Email),
            Telephone = protector.Unprotect(bid.Telephone),
            Address = protector.Unprotect(bid.Address),
        };
    }
}