namespace Axepta.SDK.Exceptions;

internal sealed class AxeptaException : Exception
{
    public AxeptaException(string msg) : base(msg) { }

    public AxeptaException(IReadOnlyList<ValidationError>? validationErrors) : base(CreateValidationExceptionMessage(validationErrors)) { }

    private static string CreateValidationExceptionMessage(IReadOnlyList<ValidationError>? validationErrors)
    {
        if (validationErrors is null)
            return string.Empty;

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Validation errors occurred:");

        foreach (var error in validationErrors)
            stringBuilder.AppendLine($"- {error.Property}: {error.Message}");

        return stringBuilder.ToString();
    }
}
