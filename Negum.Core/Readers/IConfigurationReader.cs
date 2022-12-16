using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is designed to handle specific configuration file by it's path or URL.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConfigurationReader : IStreamReader<IConfiguration>, IReader<string, IConfiguration>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConfigurationReader : IConfigurationReader
{
    public const string CommentSymbol = ";";
    public const string SectionPrefixSymbol = "[";
    public const string EqualsSymbol = "=";

    protected StringBuilder SectionHeaderBuilder { get; } = new();
    protected ICollection<IConfigurationSection> Sections { get; } = new List<IConfigurationSection>();

    protected ICollection<IConfigurationSectionEntry> Entries { get; set; } =
        new List<IConfigurationSectionEntry>();

    public async Task<IConfiguration> ReadAsync(string path)
    {
        var stream = await NegumContainer.Resolve<IFileContentReader>().ReadAsync(path);
        return await ReadAsync(stream);
    }

    public async Task<IConfiguration> ReadAsync(Stream stream)
    {
        var lines = await NegumContainer.Resolve<IStreamLinesReader>().ReadAsync(stream);
        return await ReadFromLinesAsync(lines);
    }

    protected virtual async Task<IConfiguration> ReadFromLinesAsync(IEnumerable<string> lines)
    {
        var cleanedLines = await CleanLinesAsync(lines);
        var configuration = await ProcessLinesAsync(cleanedLines);
        return configuration;
    }

    protected virtual async Task<IEnumerable<string>> CleanLinesAsync(IEnumerable<string> lines) =>
        await Task.FromResult(lines
                .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove empty line
                .Select(line => line.TrimStart()) // Remove whitespaces at the beginning of the line
                .Where(line => line.StartsWith(SectionPrefixSymbol) || char.IsLetterOrDigit(line.ElementAt(0))) // Remove lines which start from comment
                .Select(RemoveComment) // Removes comment at the end of the line
                .Select(line => line.TrimEnd()) // Remove white spaces at the end of the line);
        );

    protected virtual string RemoveComment(string line)
    {
        var index = line.IndexOf(CommentSymbol, StringComparison.Ordinal);
        return index > 0 ? line[..index] : line;
    }

    protected virtual async Task<IConfiguration> ProcessLinesAsync(IEnumerable<string> lines) =>
        await Task.FromResult(ProcessLines(lines));

    protected virtual IConfiguration ProcessLines(IEnumerable<string> lines)
    {
        ClearInitials();

        foreach (var line in lines)
        {
            ProcessLine(line);
        }

        AddSection();

        return GetConfiguration();
    }

    protected virtual void ProcessLine(string line)
    {
        if (line.StartsWith(SectionPrefixSymbol))
        {
            AddSection();
            ClearInitials();

            SectionHeaderBuilder.Append(line);
        }
        else
        {
            ProcessEntry(line);
        }
    }

    /// <summary>
    /// Parses and processes single entry.
    /// </summary>
    /// <param name="line"></param>
    protected virtual void ProcessEntry(string line)
    {
        string key;
        string value;

        if (line.Contains(EqualsSymbol))
        {
            var index = line.IndexOf(EqualsSymbol, StringComparison.Ordinal);

            key = line[..index]
                .Trim();

            value = line
                .Substring(index + 1, line.Length - index - 1)
                .Replace("\"", "")
                .Trim();
        }
        else
        {
            key = Entries.Count.ToString();
            value = line;
        }

        ProcessEntry(line, key, value);
    }

    /// <summary>
    /// Adds current section to collection.
    /// </summary>
    protected virtual void AddSection()
    {
        if (SectionHeaderBuilder.Length == 0)
        {
            return;
        }

        var sectionHeader = SectionHeaderBuilder.ToString();
        var sectionName = GetSectionName(sectionHeader);

        AddSection(sectionName);
    }

    /// <summary>
    /// Clears local values used during the process.
    /// </summary>
    protected virtual void ClearInitials()
    {
        SectionHeaderBuilder.Clear();
        Entries = new List<IConfigurationSectionEntry>();
    }

    /// <summary>
    /// </summary>
    /// <returns>Configuration with initialized sections and entries.</returns>
    protected virtual IConfiguration GetConfiguration()
    {
        var configuration = GetEmptyConfiguration();
        InitializeConfiguration(configuration);
        return configuration;
    }

    /// <summary>
    /// Initializes configuration.
    /// </summary>
    /// <param name="configuration"></param>
    protected virtual void InitializeConfiguration(IConfiguration configuration) =>
        Sections
            .ToList()
            .ForEach(section => InitializeConfigurationSection(configuration, section));

    /// <summary>
    /// Initializes configuration with specified section.
    /// The passed section is the one read from the file or URL.
    /// Section should be processed and add to the given configuration.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="section"></param>
    protected virtual void InitializeConfigurationSection(IConfiguration configuration,
        IConfigurationSection section) => configuration.AddSection(section);

    /// <summary>
    /// </summary>
    /// <returns>New empty configuration.</returns>
    protected virtual IConfiguration GetEmptyConfiguration() => new Configuration();

    /// <summary>
    /// Processes single entry for the newest section.
    /// </summary>
    /// <param name="line"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    protected virtual void ProcessEntry(string line, string key, string value)
    {
        var newEntry = new ConfigurationSectionEntry
        {
            Key = key,
            Value = value
        };

        Entries.Add(newEntry);
    }

    /// <summary>
    /// </summary>
    /// <param name="sectionHeader"></param>
    /// <returns>Section name from the given header.</returns>
    protected virtual string GetSectionName(string sectionHeader) => 
        sectionHeader[1..^1];

    /// <summary>
    /// Adds new section.
    /// </summary>
    /// <param name="sectionName"></param>
    protected virtual void AddSection(string sectionName)
    {
        var section = new ConfigurationSection
        {
            Name = sectionName,
            Entries = Entries,
        };

        Sections.Add(section);
    }
}