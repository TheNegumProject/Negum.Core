namespace Negum.Core.Configurations.Constants;

/// <summary>
/// Represents a definition of a section in configuration which describe CNS aka Constants file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConstantsSection : IConfigurationSection
{
    /// <summary>
    /// Signifies the unique identifier for this state.
    /// Statedefs contains Subsections where each subsection has the same Id.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Represents a number or key after the state id.
    /// </summary>
    string? Action { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConstantsSection : ConfigurationSection, IConstantsSection
{
    public int Id { get; internal set; }
    public string? Action { get; internal set; }
}