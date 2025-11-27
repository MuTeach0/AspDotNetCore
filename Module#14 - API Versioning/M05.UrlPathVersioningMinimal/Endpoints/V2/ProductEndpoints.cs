using System.Text;
using M05.UrlPathVersioningMinimal.Data;
using M05.UrlPathVersioningMinimal.Models;
using M05.UrlPathVersioningMinimal.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using M05.UrlPathVersioningMinimal.Responses.V2;
using Asp.Versioning.Builder;
using Asp.Versioning;

namespace M05.UrlPathVersioningMinimal.Endpoints.V2;


public static class ProductEndpoints
{
	public static RouteGroupBuilder MapProductEndpointsV2(this IEndpointRouteBuilder app, ApiVersionSet apiVersionSet)
	{

		// var defaultApi = app
		// 	.MapGroup("/api/products")
		// 	.WithApiVersionSet(apiVersionSet)
		// 	.HasApiVersion(new ApiVersion(2.0));

		var productApi = app
			.MapGroup("/api/v{apiVersion:apiVersion}/products")
			.WithApiVersionSet(apiVersionSet);

		// defaultApi.MapGet("{productId:guid}", GetProductById)
		// 	.WithName("GetProductByIdDefault");

		productApi.MapGet("{productId:guid}", GetProductById)
			.HasApiVersion(new ApiVersion(2.0))
			.WithName("GetProductByIdV2");

		return productApi;
	}



    private static Results<Ok<ProductResponse>, NotFound<string>> GetProductById(
        Guid productId,
        ProductRepository repository)
    {
        var product = repository.GetProductById(productId);

        if (product is null)
            return TypedResults.NotFound($"Product with Id '{productId}' not found");

        return TypedResults.Ok(ProductResponse.FromModel(product));
    }

}