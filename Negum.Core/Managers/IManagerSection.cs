using System;
using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Managers;

/// <summary>
/// Root manager's section definition.
/// Sections are what configurations are divided by.
/// It represent single area of configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IManagerSection
{
    /// <summary>
    /// Name of the current section.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// </summary>
    /// <param name="fieldKey"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>Value parsed to specified type</returns>
    TValue? GetValue<TValue>(string? fieldKey);

    /// <summary>
    /// </summary>
    /// <param name="fieldKey"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>Collection of values with the specified key.</returns>
    IEnumerable<TValue> GetValues<TValue>(string? fieldKey);

    /// <summary>
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>All entries of current section.</returns>
    IEnumerable<TValue> GetAll<TValue>();
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public abstract class ManagerSection : IManagerSection
{
    protected IConfigurationSection Section { get; }

    public string Name { get; }

    protected ManagerSection(string name, IConfigurationSection section)
    {
        Name = name;
        Section = section;
    }

    public TValue? GetValue<TValue>(string? fieldKey) =>
        GetValues<TValue>(fieldKey).FirstOrDefault();

    public IEnumerable<TValue> GetValues<TValue>(string? fieldKey)
    {
        if (fieldKey is null)
        {
            return Array.Empty<TValue>();
        }
            
        var entries = Section
            .Where(sectionEntry => sectionEntry.Key.StartsWith(fieldKey));

        return InitializeEntries<TValue>(entries, fieldKey);
    }

    public IEnumerable<TValue> GetAll<TValue>() =>
        InitializeEntries<TValue>(Section, null);

    protected virtual IEnumerable<TValue> InitializeEntries<TValue>(IEnumerable<IConfigurationSectionEntry> entries,
        string? fieldKey) => 
        entries
            .Select((sectionEntry, index) =>
            {
                var key = fieldKey ?? index.ToString();
                    
                var entry = NegumContainer.Resolve<IManagerSectionEntry<TValue>>();
                entry.Initialize(this, key, sectionEntry);

                return entry.Read();
            })
            .ToList();
}