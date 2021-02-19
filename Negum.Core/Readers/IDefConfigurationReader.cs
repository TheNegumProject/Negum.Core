using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations.Def;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle general DEF configuration file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDefConfigurationReader : IConfigurationReader<IDefConfiguration>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class DefConfigurationReader : AbstractConfigurationReader<IDefConfiguration>, IDefConfigurationReader
    {
        private ICollection<IDefConfigurationSection> Sections { get; } = new List<IDefConfigurationSection>();

        private ICollection<IDefConfigurationSectionEntry> Entries { get; set; } =
            new List<IDefConfigurationSectionEntry>();

        protected override IDefConfiguration GetConfiguration()
        {
            var configuration = new DefConfiguration();

            this.Sections
                .ToList()
                .ForEach(section => configuration.Sections.Add(section.Name, section));

            return configuration;
        }

        protected override void ProcessEntry(string line, string key, string value)
        {
            var newEntry = new DefConfigurationSectionEntry
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
            var section = new DefConfigurationSection
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
            this.Entries = new List<IDefConfigurationSectionEntry>();
        }
    }
}