namespace Axepta.SDK.Regex;

public static class AllowedCharactersPatterns
{
    public const string DEFAULT_ALLOWED_CHARACTERS_PATTERN = @"^[A-Za-z0-9 ]+$";
    public const string DEFAULT_WITH_DASH_ALLOWED_CHARACTERS_PATTERN = @"^[A-Za-z0-9\-]+$";
    public const string ADDITIONAL_ALLOWED_CHARACTERS_PATTERN = @"^[A-Za-z0-9#&_""',./\s\u00C0-\u02C0]*$";
    public const string PHONE_NUMBER_PATTERN = @"^[+\- 0-9]*$";
}