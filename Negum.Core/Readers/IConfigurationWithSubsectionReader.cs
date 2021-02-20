using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle specific configuration file by it's path with multiple subsections.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationWithSubsectionReader : IConfigurationReader
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationWithSubsectionReader : ConfigurationReader, IConfigurationWithSubsectionReader
    {
        protected bool IsParsingSubsection { get; set; }
        protected ICollection<IConfigurationSection> Subsections { get; set; } = new List<IConfigurationSection>();
        protected IConfigurationSection LastSection { get; set; }

        protected override void ProcessLine(string line)
        {
            if (line.StartsWith(SectionPrefixSymbol))
            {
                if (this.IsSubsectionHeader(line))
                {
                    this.IsParsingSubsection = true;
                }
                else
                {
                    this.IsParsingSubsection = false;
                    this.LastSection = this.Sections.LastOrDefault();
                }

                this.AddSection();
                this.ClearInitials();

                this.SectionHeaderBuilder.Append(line);
            }
            else
            {
                this.ProcessEntry(line);
            }
        }

        protected virtual bool IsSubsectionHeader(string line)
        {
            var lastSectionName = this.Sections.LastOrDefault()?.Name;

            return lastSectionName != null &&
                   line.StartsWith("[" + lastSectionName.Substring(0, lastSectionName.Length - 4) + " ");
        }

        protected override void ClearInitials()
        {
            base.ClearInitials();

            this.Subsections = new List<IConfigurationSection>();
        }

        protected override void AddSection(string sectionName,
            IEnumerable<IConfigurationSectionEntry> sectionAttributes)
        {
            var section = new ConfigurationSection
            {
                Name = sectionName,
                Attributes = sectionAttributes,
                Entries = this.Entries,
            };

            if (this.IsParsingSubsection)
            {
                this.Subsections.Add(section);
            }
            else
            {
                this.Subsections
                    .ToList()
                    .ForEach(subsection => this.LastSection.AddSubsection(subsection));

                this.Sections.Add(section);
            }
        }
    }
}