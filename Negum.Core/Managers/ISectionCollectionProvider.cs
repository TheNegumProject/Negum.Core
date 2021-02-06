using System.Collections.Generic;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Provides functionality to retrieve collection of sections from Configuration Scrapper.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISectionCollectionProvider
    {
        /// <summary>
        /// Setups collection of Section Managers.
        /// Remember to add " " (space) at the end of the prefix if you want to skip "-def" sections.
        /// </summary>
        /// <param name="scrappers"></param>
        /// <typeparam name="TConfigurationManagerSection"></typeparam>
        /// <returns>Setup enumerable.</returns>
        IEnumerable<TConfigurationManagerSection> SetupMultiple<TConfigurationManagerSection>(IEnumerable<IConfigurationSectionScrapper> scrappers) 
            where TConfigurationManagerSection : IConfigurationManagerSection<TConfigurationManagerSection>;
    }
}