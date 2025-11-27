using FluentValidation;
using M04.MinimalFluentValidation.Requests;

namespace M04.MinimalFluentValidation.Validators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        // Name
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product Name is required")
            .Length(3, 255).WithMessage("Product name must be between 3 and 255 characters.");

        // Description
        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Description cannot exceed 1000 characters.");

        // SKU
        RuleFor(x => x.SKU)
            .NotEmpty().WithMessage("SKU is required.")
            .Matches(@"^PRD-\d{5}$").WithMessage("SKU must be 'PRD-' followed by 5 digits 'PRD-XXXXX'.");

        // Price
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0.01m)
            .WithMessage("Price must be at least 0.01.");

        // Stock Quantity
        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("StockQuantity must be at least 1.");

        // Launch Date
        RuleFor(x => x.LaunchDate)
            .NotEmpty().WithMessage("Launch date is required.")
            .Must(BeTodayOrFuture)
            .WithMessage("Launch date must be today or a future date.");

        // Category
        RuleFor(x => x.Category)
            .IsInEnum()
            .WithMessage("Invalid product category.");

        // Image URL
        RuleFor(x => x.ImageUrl)
            .Must(BeValidUrl)
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl))
            .WithMessage("ImageUrl must be a valid URL.");

        // Weight
        RuleFor(x => x.Weight)
            .InclusiveBetween(0.01m, 1000m)
            .WithMessage("Weight must be between 0.01 and 1000 kg.");

        // Warranty Period Months
        RuleFor(x => x.WarrantyPeriodMonths)
            .Must(v => v == 0 || v == 12 || v == 24 || v == 36)
            .WithMessage("Warranty must be 0, 12, 24, or 36 months.");

        // Return Policy Description
        RuleFor(x => x.ReturnPolicyDescription)
            .NotEmpty()
            .When(x => x.IsReturnable)
            .WithMessage("Return policy description is required if the product is returnable.");

        // Tags
        RuleFor(x => x.Tags)
            .Must(tags => tags == null || tags.Count <= 5)
            .WithMessage("A maximum of 5 tags is allowed.");
    }

    // Helpers
    private bool BeTodayOrFuture(DateTime date)
        => date.Date >= DateTime.UtcNow.Date;

    private bool BeValidUrl(string? url)
        => Uri.TryCreate(url, UriKind.Absolute, out var uri)
           && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
}