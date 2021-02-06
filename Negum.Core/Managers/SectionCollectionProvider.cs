using System.Collections.Generic;
using System.Linq;
using Negum.Core.Containers;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SectionCollectionProvider : ISectionCollectionProvider
    {
        public IEnumerable<TConfigurationManagerSection> SetupMultiple<TConfigurationManagerSection>(
            IEnumerable<IConfigurationSectionScrapper> scrappers)
            where TConfigurationManagerSection : IConfigurationManagerSection<TConfigurationManagerSection> =>
            scrappers
                .Select(scrapper => NegumContainer.Resolve<TConfigurationManagerSection>().Setup(scrapper))
                .ToList();
    }
}