using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Configurations;

/// <summary>
/// Represents general definition of a section in configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConfigurationSection : IEnumerable<IConfigurationSectionEntry>
{
    /// <summary>
    /// Name of the current section.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Collection of inner sections.
    /// Only few files are using it.
    /// </summary>
    IEnumerable<IConfigurationSection> Subsections { get; }

    /// <summary>
    /// Adds new subsection to the current section.
    /// </summary>
    /// <param name="section"></param>
    void AddSubsection(IConfigurationSection section);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConfigurationSection : IConfigurationSection
{
    public string Name { get; internal set; } = string.Empty;

    public IEnumerable<IConfigurationSection> Subsections { get; internal set; } =
        new List<IConfigurationSection>();

    public ICollection<IConfigurationSectionEntry> Entries { get; internal set; } =
        new List<IConfigurationSectionEntry>();

    public void AddSubsection(IConfigurationSection section) =>
        ((List<IConfigurationSection>) Subsections).Add(section);

    public IEnumerator<IConfigurationSectionEntry> GetEnumerator() =>
        Entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}