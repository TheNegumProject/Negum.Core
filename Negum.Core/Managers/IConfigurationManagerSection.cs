using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Describes section common stuff for Manager.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigurationManagerSection
    {
        /// <summary>
        /// Scrapper used by this section.
        /// </summary>
        IConfigurationSectionScrapper Scrapper { get; }
        
        /// <summary>
        /// Name of the current section.
        /// </summary>
        string SectionName { get; }

        /// <summary>
        /// Setups current section.
        /// </summary>
        /// <param name="scrapper"></param>
        /// <param name="sectionName"></param>
        /// <returns>Current section.</returns>
        IConfigurationManagerSection Setup(IConfigurationSectionScrapper scrapper, string sectionName);
    }
}