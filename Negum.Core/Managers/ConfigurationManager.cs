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
    public abstract class ConfigurationManager<TConfigurationManager> : IConfigurationManager<TConfigurationManager>
        where TConfigurationManager : IConfigurationManager<TConfigurationManager>
    {
        public IConfigurationScrapper Scrapper { get; protected set; }

        public TConfigurationManager Setup(IConfigurationScrapper scrapper)
        {
            this.Scrapper = scrapper;
            return (TConfigurationManager) (IConfigurationManager<TConfigurationManager>) this;
        }

        public TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : IConfigurationManagerSection<TManagerSection>
        {
            var managerSection = NegumContainer.Resolve<TManagerSection>();
            var scrapperSection = this.Scrapper.GetSection(sectionName);
            return managerSection.Setup(scrapperSection, sectionName);
        }

        public IEnumerable<TManagerSection> GetSections<TManagerSection>(string sectionNamePrefix)
            where TManagerSection : IConfigurationManagerSection<TManagerSection> =>
            this.Scrapper
                .GetSections(sectionNamePrefix)
                .Select(sectionScrapper => NegumContainer.Resolve<TManagerSection>()
                    .Setup(sectionScrapper, sectionScrapper.SectionName))
                .ToList();
    }
}