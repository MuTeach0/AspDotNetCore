using System;
using System.ComponentModel.DataAnnotations;

namespace M02.MinimalDataAnnotations.Validators;

public static class LaunchDateValidator
{
    public static ValidationResult? MustBeTodayOrFuture(DateTime dateTime, ValidationContext validationContext)
    {
        if (dateTime.Date >= DateTime.UtcNow.Date)
            return ValidationResult.Success;

        return new ValidationResult("Launch date must be today or future.",
        [validationContext.MemberName ?? "LaunchDate"]);
    }
}