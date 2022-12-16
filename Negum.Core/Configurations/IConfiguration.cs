using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Configurations;

/// <summary>
/// Represents general definition for configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConfiguration : IEnumerable<IConfigurationSection>
{
    /// <summary>
    /// Adds new section to the current configuration.
    /// </summary>
    /// <param name="section"></param>
    void AddSection(IConfigurationSection section);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class Configuration : IConfiguration
{
    private ICollection<IConfigurationSection> Sections { get; } =
        new List<IConfigurationSection>();

    public void AddSection(IConfigurationSection section) =>
        Sections.Add(section);

    public IEnumerator<IConfigurationSection> GetEnumerator() =>
        Sections.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}