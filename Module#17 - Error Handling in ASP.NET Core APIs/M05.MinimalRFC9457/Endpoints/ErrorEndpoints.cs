using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace M05.MinimalRFC9457.Endpoints;

public static class ErrorEndpoints
{
    public static RouteGroupBuilder MapErrorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/minimal-fake-errors");
        group.MapGet("/server-error", () =>
        {
            File.ReadAllText(@"C:\Settings\SomeSettings.json"); // not exist
            return Results.Created();
        });

        group.MapPost("bad-request", () => Results.BadRequest());
        // new ProblemDetails
        // {
        //     Title = "Product SKU is required"
        // }));
        group.MapPost("bad-request-2", () => Results.Problem
        (
            type: "http://example.com/prop/sku-required",
            title: "Bad Request",
            detail: "Product SKU is required",
            statusCode: StatusCodes.Status400BadRequest
        ));

        group.MapPost("not-found", () => Results.NotFound());
        //     new ProblemDetails
        //     {
        //         Title = "Product not found"
        //     }
        // ));
        group.MapPost("unauthorized",() => Results.Unauthorized());
        group.MapPost("conflict", () => Results.Conflict());
        //     new ProblemDetails
        //     {
        //         Title = "The Product already exists."
        //     }
        // ));
        group.MapPost("business-rule-error", () =>
        {
            throw new ValidationException("A discontinued product cannot be put on promotion.");
        });
        return group;
    }
}