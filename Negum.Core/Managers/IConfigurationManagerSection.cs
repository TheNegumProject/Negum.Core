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
    public interface IConfigurationManagerSection<out TConfigurationManagerSection>
        where TConfigurationManagerSection : IConfigurationManagerSection<TConfigurationManagerSection>
    {
        /// <summary>
        /// Scrapper used by this section.
        /// </summary>
        IConfigurationSectionScrapper Scrapper { get; }

        /// <summary>
        /// Setups current section.
        /// </summary>
        /// <param name="scrapper"></param>
        /// <returns>Current section.</returns>
        TConfigurationManagerSection Setup(IConfigurationSectionScrapper scrapper);
    }
}