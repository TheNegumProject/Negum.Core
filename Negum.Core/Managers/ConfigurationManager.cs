using System.Collections.Generic;
using System.Linq;
using Negum.Core.Containers;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager allows for easier interaction with ConfigurationDefinition's known fields.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationManager : IConfigurationManager
    {
        public IConfigurationScrapper Scrapper { get; protected set; }

        public IConfigurationManager Setup(IConfigurationScrapper scrapper)
        {
            this.Scrapper = scrapper;
            return this;
        }

        public TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : IConfigurationManagerSection
        {
            var managerSection = NegumContainer.Resolve<TManagerSection>();
            var scrapperSection = this.Scrapper.GetSection(sectionName);
            return (TManagerSection) managerSection.Setup(this, scrapperSection, sectionName);
        }

        public IEnumerable<TManagerSection> GetSections<TManagerSection>(string sectionNamePrefix)
            where TManagerSection : IConfigurationManagerSection =>
            this.Scrapper
                .GetSections(sectionNamePrefix)
                .Select(sectionScrapper => this.GetSection<TManagerSection>(sectionScrapper.SectionName))
                .ToList();

        public IEnumerable<IConfigurationManagerSection> GetInnerSections(IConfigurationManagerSection parent,
            string innerSectionsPrefix) =>
            this.Scrapper.GetInnerSections(parent.Scrapper, innerSectionsPrefix)
                .Select(section => this.GetSection<IConfigurationManagerSection>(section.SectionName))
                .ToList();
    }
}