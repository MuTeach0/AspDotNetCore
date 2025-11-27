using System.ComponentModel.DataAnnotations;

namespace M01.ControllerDataAnnotations.Validators;

public class RequiredIf(string dependentProperty, object? targetValue) : ValidationAttribute
{
    private readonly string _dependentProperty = dependentProperty;
    private readonly object? _targetValue = targetValue;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var containerType = validationContext.ObjectInstance.GetType();
        var field = containerType.GetProperty(_dependentProperty);

        if(field is null)
            return new ValidationResult($"Unknown property: {_dependentProperty}");

        var dependentValue = field.GetValue(validationContext.ObjectInstance, null);

        if(Equals(dependentValue, _targetValue))
        {
            if (value is null || (value is string str && string.IsNullOrWhiteSpace(str)))
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} is required.");
        }

        return ValidationResult.Success;
    }
}