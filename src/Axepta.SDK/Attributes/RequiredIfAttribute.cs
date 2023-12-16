namespace Axepta.SDK.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal sealed class RequiredIfAttribute : ValidationAttribute
{
    private readonly string _propertyName;
    private readonly object _desiredValue;

    public RequiredIfAttribute(
        string propertyName, 
        object desiredValue
    )
    {
        _propertyName = propertyName;
        _desiredValue = desiredValue;
    }

    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext
    )
    {
        var property = validationContext.ObjectType.GetProperty(_propertyName);
        if (property is null)
            return new ValidationResult($"Unknown property: {_propertyName}");

        var propertyValue = property.GetValue(validationContext.ObjectInstance);

        if (
            Equals(propertyValue, _desiredValue) &&
            value is null
        )
            return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} is required.");

        return ValidationResult.Success;
    }
}
