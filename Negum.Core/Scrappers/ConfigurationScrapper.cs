using System.Collections.Generic;
using System.Linq;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationScrapper : IConfigurationScrapper
    {
        private IConfigurationDefinition ConfigDef { get; set; }

        public IConfigurationScrapper Setup(IConfigurationDefinition def)
        {
            this.ConfigDef = def;
            return this;
        }

        public IConfigurationSectionScrapper GetSection(string sectionName) =>
            NegumContainer.Resolve<IConfigurationSectionScrapper>().Setup(this.ConfigDef[sectionName], sectionName);

        public IEnumerable<IConfigurationSectionScrapper> GetSections(string sectionNamePrefix) =>
            this.ConfigDef.Sections
                .Where(section => section.Key.StartsWith(sectionNamePrefix))
                .Select(entry => this.GetSection(entry.Key))
                .ToList();

        public IEnumerable<IConfigurationSectionScrapper> GetInnerSections(IConfigurationSectionScrapper parent,
            string innerSectionsPrefix) =>
            this.ConfigDef.Sections
                .SkipWhile(section => !section.Key.Equals(parent.SectionName))
                .SkipWhile(section => section.Key.Equals(parent.SectionName))
                .TakeWhile(section => section.Key.StartsWith(innerSectionsPrefix))
                .Select(section => this.GetSection(section.Key))
                .ToList();
    }
}