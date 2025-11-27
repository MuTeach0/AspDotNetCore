using System.Security.AccessControl;

namespace M02.BuildingRESTFullApi.Requests;

public class CreateProductRequest
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}