namespace M04.RefreshingAccessToken.Requests;

public class GenerateTokenRequest
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<string> Permissions { get; set; } = [];
    public List<string> Roles { get; set; } = [];
}