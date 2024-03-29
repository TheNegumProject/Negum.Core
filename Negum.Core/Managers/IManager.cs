using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;

namespace Negum.Core.Managers;

/// <summary>
/// Root manager definition.
/// Managers are objects which wraps around configuration, and are used to easier interact with known fields.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IManager : IEnumerable<IManagerSection>
{
    /// <summary>
    /// Setups current Manager to use specified configuration.
    /// </summary>
    /// <param name="config"></param>
    /// <returns>Current manager.</returns>
    IManager UseConfiguration(IConfiguration config);

    /// <summary>
    /// </summary>
    /// <param name="sectionName">Name of the section to find.</param>
    /// <typeparam name="TManagerSection">Type of the searched section.</typeparam>
    /// <returns>Parsed found section.</returns>
    TManagerSection GetSection<TManagerSection>(string sectionName)
        where TManagerSection : IManagerSection;

    /// <summary>
    /// </summary>
    /// <param name="sectionName"></param>
    /// <typeparam name="TManagerSection"></typeparam>
    /// <returns>Collection of sections with the same name.</returns>
    IEnumerable<TManagerSection> GetSections<TManagerSection>(string sectionName)
        where TManagerSection : IManagerSection;

    /// <summary>
    /// </summary>
    /// <param name="sectionName"></param>
    /// <typeparam name="TManagerSection"></typeparam>
    /// <returns>Collection of subsections from the current section.</returns>
    IEnumerable<TManagerSection> GetSubsections<TManagerSection>(string sectionName)
        where TManagerSection : IManagerSection;
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public abstract class Manager : IManager
{
    private IConfiguration? Config { get; set; }

    public IManager UseConfiguration(IConfiguration config)
    {
        Config = config;
        return this;
    }

    public TManagerSection GetSection<TManagerSection>(string sectionName)
        where TManagerSection : IManagerSection =>
        GetSections<TManagerSection>(sectionName)
            .FirstOrDefault()
        ?? throw new ArgumentException($"Cannot find section: {sectionName}", nameof(sectionName));

    public IEnumerable<TManagerSection> GetSections<TManagerSection>(string sectionName)
        where TManagerSection : IManagerSection =>
        Config?
            .Where(section => section.Name.ToLower().Equals(sectionName.ToLower()))
            .Select(section => GetNewManagerSection(section.Name, section))
            .Cast<TManagerSection>()
            .ToList()
        ?? new List<TManagerSection>();

    public IEnumerable<TManagerSection> GetSubsections<TManagerSection>(string sectionName)
        where TManagerSection : IManagerSection =>
        Config?
            .First(section => section.Name.ToLower().StartsWith(sectionName.ToLower()))
            .Subsections
            .Select(subsection => GetNewManagerSection(subsection.Name, subsection))
            .Cast<TManagerSection>()
            .ToList()
        ?? new List<TManagerSection>();

    public IEnumerator<IManagerSection> GetEnumerator() =>
        Config?
            .Select(section => GetSection<IManagerSection>(section.Name))
            .ToList()
            .GetEnumerator()
        ?? new List<IManagerSection>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();

    /// <summary>
    /// </summary>
    /// <param name="sectionName"></param>
    /// <param name="configSection"></param>
    /// <returns>Returns related Manager's Section.</returns>
    protected abstract IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection);
}