using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Contains common code for all other readers.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class AbstractConfigurationReader<TOutput> : IConfigurationReader<TOutput>
    {
        public const string CommentSymbol = ";";
        public const string SectionPrefixSymbol = "[";

        protected StringBuilder SectionHeaderBuilder { get; set; } = new();
        
        public virtual async Task<TOutput> ReadAsync(string path)
        {
            var fileLines = await File.ReadAllLinesAsync(path);
            var cleanedLines = await this.CleanLinesAsync(fileLines);
            var configuration = await this.ProcessLinesAsync(cleanedLines);
            return configuration;
        }

        protected virtual async Task<IEnumerable<string>> CleanLinesAsync(IEnumerable<string> lines) =>
            await Task.FromResult(lines
                    .Where(line => !string.IsNullOrWhiteSpace(line)) // Remove empty line
                    .Select(line => line.TrimStart()) // Remove whitespaces at the beginning of the line
                    .Where(line => !line.StartsWith(CommentSymbol)) // Remove lines which start from comment
                    .Select(RemoveComment) // Removes comment at the end of the line
                    .Select(line => line.TrimEnd()) // Remove white spaces at the end of the line);
            );
        
        protected virtual string RemoveComment(string line)
        {
            var index = line.IndexOf(CommentSymbol, StringComparison.Ordinal);
            return index > 0 ? line.Substring(0, index) : line;
        }

        protected virtual async Task<TOutput> ProcessLinesAsync(IEnumerable<string> lines) =>
            await Task.FromResult(this.ProcessLines(lines));

        protected virtual TOutput ProcessLines(IEnumerable<string> lines)
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
                var index = line.IndexOf("=", StringComparison.Ordinal);

                var key = line
                    .Substring(0, index)
                    .Trim();

                var value = line
                    .Substring(index + 1, line.Length - index - 1)
                    .Replace("\"", "")
                    .Trim();
                
                this.ProcessEntry(line, key, value);
            }
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
            
            this.AddSection(sectionHeader, sectionName, sectionAttributes);
        }

        /// <summary>
        /// Clears local values used during the process.
        /// </summary>
        protected virtual void ClearInitials()
        {
            this.SectionHeaderBuilder.Clear();
        }
        
        /// <summary>
        /// </summary>
        /// <returns>Returns combined configuration.</returns>
        protected abstract TOutput GetConfiguration();

        /// <summary>
        /// Processes single entry for the newest section.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected abstract void ProcessEntry(string line, string key, string value);

        /// <summary>
        /// </summary>
        /// <param name="sectionHeader"></param>
        /// <returns>Section name from the given header.</returns>
        protected abstract string GetSectionName(string sectionHeader);

        /// <summary>
        /// </summary>
        /// <param name="sectionHeader"></param>
        /// <returns>Section attributes from the given header.</returns>
        protected abstract IEnumerable<string> GetSectionAttributes(string sectionHeader);
        
        /// <summary>
        /// Adds new section.
        /// </summary>
        /// <param name="sectionHeader"></param>
        /// <param name="sectionName"></param>
        /// <param name="sectionAttributes"></param>
        protected abstract void AddSection(string sectionHeader, string sectionName, IEnumerable<string> sectionAttributes);
    }
}