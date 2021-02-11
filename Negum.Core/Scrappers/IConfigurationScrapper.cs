using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Scrappers
{
    /// <summary>
    /// Scraps over specified configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationScrapper
    {
        /// <summary>
        /// Sets configuration which should be scrapped.
        /// </summary>
        /// <returns>This scrapper.</returns>
        IConfigurationScrapper Setup(IConfigurationDefinition def);

        /// <summary>
        /// Creates new Configuration Section Scrapper for specified section.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns>New Configuration Section Scrapper</returns>
        IConfigurationSectionScrapper GetSection(string sectionName);

        /// <summary>
        /// Creates new Configuration Section Scrapper enumerable for specified section prefix.
        /// </summary>
        /// <param name="sectionNamePrefix"></param>
        /// <returns>Collection of Scrappers.</returns>
        IEnumerable<IConfigurationSectionScrapper> GetSections(string sectionNamePrefix);
    }
}