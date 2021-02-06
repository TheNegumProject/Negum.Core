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
        /// <typeparam name="TConfiguration"></typeparam>
        /// <returns>Returns this scrapper.</returns>
        IConfigurationScrapper Setup(IConfigurationDefinition def);

        /// <summary>
        /// Creates new Configuration Section Scrapper for specified section.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns>Returns new Configuration Section Scrapper</returns>
        IConfigurationSectionScrapper ForSection(string sectionName);
    }
}