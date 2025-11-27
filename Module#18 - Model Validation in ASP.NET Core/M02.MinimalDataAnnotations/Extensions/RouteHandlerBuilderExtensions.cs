using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace M02.MinimalDataAnnotations.Extensions;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder Validate<T>(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilter(async (context, next) =>
        {
            var argument = context.Arguments.OfType<T>().FirstOrDefault();
            if (argument is null)
                return Results.Problem(new ProblemDetails
                {
                    Title = "Bad request.",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = $"{nameof(T)} is null"
                });

            List<ValidationResult> validationResult = [];
            var isValid = Validator.TryValidateObject(
                                    argument,
                                    new ValidationContext(argument),
                                    validationResult, true);

            if (!isValid)
            {
                var errorGroups = validationResult
                .SelectMany(v => (v.MemberNames.Any() ? v.MemberNames : new[] { "" })
                .Select(name => new { name, v.ErrorMessage }))
                .GroupBy(x => x.name)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage!).ToArray()
                );
                return Results.ValidationProblem(errorGroups);
            }
            return await next(context);
        });
        return builder;
    }
}