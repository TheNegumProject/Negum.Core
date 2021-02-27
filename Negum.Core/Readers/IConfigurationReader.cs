using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    public interface IConfigurationReader : IFileReader<IConfiguration>, IStreamReader<IConfiguration>
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
        
        public async Task<IConfiguration> ReadAsync(Stream stream)
        {
            var lines = await ReadLinesAsync(stream);
            return await this.ReadFromLinesAsync(lines);
        }

        public async Task<IConfiguration> ReadAsync(string path)
        {
            IEnumerable<string> lines;
            
            if (path.StartsWith("http") || path.StartsWith("www"))
            {
                lines = await ReadLinesFromUrlAsync(path);
            }
            else
            {
                lines =  await File.ReadAllLinesAsync(path);
            }
            
            return await this.ReadFromLinesAsync(lines);
        }

        protected virtual async Task<IEnumerable<string>> ReadLinesFromUrlAsync(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            var response = await request.GetResponseAsync();
            
            return await this.ReadLinesAsync(response.GetResponseStream());
        }
        
        protected virtual async Task<List<string>> ReadLinesAsync(Stream stream)
        {
            using var reader = new StreamReader(stream);
            string line;
            var lines = new List<string>();

            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        protected virtual async Task<IConfiguration> ReadFromLinesAsync(IEnumerable<string> lines)
        {
            var cleanedLines = await this.CleanLinesAsync(lines);
            var configuration = await this.ProcessLinesAsync(cleanedLines);
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
            
                key = line[..index]
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

            this.AddSection(sectionName);
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
            this.InitializeConfiguration(configuration);
            return configuration;
        }

        /// <summary>
        /// Initializes configuration.
        /// </summary>
        /// <param name="configuration"></param>
        protected virtual void InitializeConfiguration(IConfiguration configuration) =>
            this.Sections
                .ToList()
                .ForEach(section => this.InitializeConfigurationSection(configuration, section));

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

            this.Entries.Add(newEntry);
        }

        /// <summary>
        /// </summary>
        /// <param name="sectionHeader"></param>
        /// <returns>Section name from the given header.</returns>
        protected virtual string GetSectionName(string sectionHeader) => sectionHeader[1..^1];

        /// <summary>
        /// Adds new section.
        /// </summary>
        /// <param name="sectionName"></param>
        protected virtual void AddSection(string sectionName)
        {
            var section = new ConfigurationSection
            {
                Name = sectionName,
                Entries = this.Entries,
            };

            this.Sections.Add(section);
        }
    }
}