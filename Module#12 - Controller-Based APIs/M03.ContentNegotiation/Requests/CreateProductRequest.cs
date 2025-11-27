using System.Security.AccessControl;

namespace M03.ContentNegotiation.Requests;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}