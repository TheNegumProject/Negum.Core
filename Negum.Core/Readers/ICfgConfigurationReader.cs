using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations.Cfg;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle CFG configuration file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ICfgConfigurationReader : IConfigurationReader<ICfgConfiguration>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CfgConfigurationReader : AbstractConfigurationReader<ICfgConfiguration>, ICfgConfigurationReader
    {
        private ICollection<ICfgConfigurationSection> Sections { get; } = new List<ICfgConfigurationSection>();

        private ICollection<ICfgConfigurationSectionEntry> Entries { get; set; } =
            new List<ICfgConfigurationSectionEntry>();

        protected override ICfgConfiguration GetConfiguration()
        {
            var configuration = new CfgConfiguration();

            this.Sections
                .ToList()
                .ForEach(section => configuration.Sections.Add(section.Name, section));

            return configuration;
        }

        protected override void ProcessEntry(string line, string key, string value)
        {
            var newEntry = new CfgConfigurationSectionEntry
            {
                Key = key,
                Value = value
            };

            this.Entries.Add(newEntry);
        }

        protected override string GetSectionName(string sectionHeader) =>
            sectionHeader.Substring(1, sectionHeader.Length - 2);

        protected override IEnumerable<string> GetSectionAttributes(string sectionHeader) => null;

        protected override void AddSection(string sectionHeader, string sectionName,
            IEnumerable<string> sectionAttributes)
        {
            var section = new CfgConfigurationSection
            {
                Name = sectionName,
                Attributes = sectionAttributes,
                Entries = this.Entries
            };
            
            this.Sections.Add(section);
        }
        
        protected override void ClearInitials()
        {
            base.ClearInitials();
            this.Entries = new List<ICfgConfigurationSectionEntry>();
        }
    }
}