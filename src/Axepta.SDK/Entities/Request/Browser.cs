namespace Axepta.SDK;

/// <summary>
/// Represents information about a user's web browser, including details such as IP address, language, and user agent.
/// </summary>
public sealed record Browser
{
    /// <summary>
    /// Gets or initializes the IP address of the user's browser.
    /// </summary>
    [JsonPropertyName("ip")]
    public required string IpAddress { get; init; }

    /// <summary>
    /// Gets or initializes the language preference of the user's browser.
    /// </summary>
    [JsonPropertyName("language")]
    public required string Language { get; init; }

    /// <summary>
    /// Gets or initializes a boolean indicating whether JavaScript is enabled in the user's browser.
    /// </summary>
    [JsonPropertyName("jsEnabled")]
    public required bool JsEnabled { get; init; }

    /// <summary>
    /// Gets or initializes the timezone offset of the user's browser in minutes.
    /// </summary>
    [JsonPropertyName("timezoneOffset")]
    public required int TimezoneOffset { get; init; }

    /// <summary>
    /// Gets or initializes the user agent string representing the user's browser.
    /// </summary>
    [JsonPropertyName("userAgent")]
    public required string UserAgent { get; init; }

    /// <summary>
    /// Gets or initializes the Accept header indicating the types of content the user's browser can handle.
    /// </summary>
    [JsonPropertyName("accept")]
    public required string Accept { get; init; }

    /// <summary>
    /// Gets or initializes a boolean indicating whether Java is enabled in the user's browser.
    /// </summary>
    [JsonPropertyName("javaEnabled")]
    public required bool JavaEnabled { get; init; }

    /// <summary>
    /// Gets or initializes the color depth of the user's screen in bits per pixel.
    /// </summary>
    [JsonPropertyName("screenColorDepth")]
    public required int ScreenColorDepth { get; init; }

    /// <summary>
    /// Gets or initializes the height of the user's screen in pixels.
    /// </summary>
    [JsonPropertyName("screenHeight")]
    public required int ScreenHeight { get; init; }

    /// <summary>
    /// Gets or initializes the width of the user's screen in pixels.
    /// </summary>
    [JsonPropertyName("screenWidth")]
    public required int ScreenWidth { get; init; }
}
