namespace Negum.Core.Configurations;

/// <summary>
/// Represents general definition of an entry in a section in configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConfigurationSectionEntry
{
    /// <summary>
    /// Entry's key.
    /// </summary>
    string Key { get; }

    /// <summary>
    /// Entry's value.
    /// </summary>
    string? Value { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConfigurationSectionEntry : IConfigurationSectionEntry
{
    public string Key { get; internal init; } = string.Empty;
    public string? Value { get; internal init; } // Null when the value is empty
}