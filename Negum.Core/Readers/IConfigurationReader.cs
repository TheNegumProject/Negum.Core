using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negum.Core.Configurations;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle specific configuration file by it's path.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationReader : IFileReader<IConfiguration>
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
            var fileLines = await this.ReadLinesAsync(path);
            var cleanedLines = await this.CleanLinesAsync(fileLines);
            var configuration = await this.ProcessLinesAsync(cleanedLines);
            return configuration;
        }

        protected virtual async Task<IEnumerable<string>> ReadLinesAsync(string path) =>
            await File.ReadAllLinesAsync(path);

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
            return index > 0 ? line.Substring(0, index) : line;
        }

        protected virtual async Task<IConfiguration> ProcessLinesAsync(IEnumerable<string> lines) =>
            await Task.FromResult(this.ProcessLines(lines));

        protected virtual IConfiguration ProcessLines(IEnumerable<string> lines)
        {
            this.ClearInitials();

            foreach (var line in lines)
            {
                this.ProcessLine(line);
            }

            this.AddSection();

            return this.GetConfiguration();
        }

        protected virtual void ProcessLine(string line)
        {
            if (line.StartsWith(SectionPrefixSymbol))
            {
                this.AddSection();
                this.ClearInitials();

                this.SectionHeaderBuilder.Append(line);
            }
            else
            {
                this.ProcessEntry(line);
            }
        }

        /// <summary>
        /// Parses and processes single entry.
        /// </summary>
        /// <param name="line"></param>
        protected virtual void ProcessEntry(string line)
        {
            var key = string.Empty;
            var value = string.Empty;
            
            if (line.Contains(EqualsSymbol))
            {
                var index = line.IndexOf(EqualsSymbol, StringComparison.Ordinal);
            
                key = line
                    .Substring(0, index)
                    .Trim();

                value = line
                    .Substring(index + 1, line.Length - index - 1)
                    .Replace("\"", "")
                    .Trim();
            }
            else
            {
                key = this.Entries.Count.ToString();
                value = line;
            }
            
            this.ProcessEntry(line, key, value);
        }

        /// <summary>
        /// Adds current section to collection.
        /// </summary>
        protected virtual void AddSection()
        {
            if (this.SectionHeaderBuilder.Length == 0)
            {
                return;
            }

            var sectionHeader = this.SectionHeaderBuilder.ToString();
            var sectionName = this.GetSectionName(sectionHeader);
            var sectionAttributes = this.GetSectionAttributes(sectionHeader);

            this.AddSection(sectionName, sectionAttributes);
        }

        /// <summary>
        /// Clears local values used during the process.
        /// </summary>
        protected virtual void ClearInitials()
        {
            this.SectionHeaderBuilder.Clear();
            this.Entries = new List<IConfigurationSectionEntry>();
        }

        /// <summary>
        /// </summary>
        /// <returns>Configuration with initialized sections and entries.</returns>
        protected virtual IConfiguration GetConfiguration()
        {
            var configuration = this.GetEmptyConfiguration();

            this.Sections
                .ToList()
                .ForEach(section => configuration.AddSection(section));

            return configuration;
        }

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

            this.Entries.Add(newEntry);
        }

        /// <summary>
        /// </summary>
        /// <param name="sectionHeader"></param>
        /// <returns>Section name from the given header.</returns>
        protected virtual string GetSectionName(string sectionHeader) =>
            sectionHeader.Substring(1, sectionHeader.Length - 2);

        /// <summary>
        /// </summary>
        /// <param name="sectionHeader"></param>
        /// <returns>Section attributes from the given header.</returns>
        protected virtual IEnumerable<IConfigurationSectionEntry> GetSectionAttributes(string sectionHeader) => null;

        /// <summary>
        /// Adds new section.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="sectionAttributes"></param>
        protected virtual void AddSection(string sectionName, IEnumerable<IConfigurationSectionEntry> sectionAttributes)
        {
            var section = new ConfigurationSection
            {
                Name = sectionName,
                Attributes = sectionAttributes,
                Entries = this.Entries,
            };

            this.Sections.Add(section);
        }
    }
}