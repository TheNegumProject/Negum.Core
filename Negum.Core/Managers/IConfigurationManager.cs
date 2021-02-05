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
    public interface IConfigurationManager<out TConfigurationManager>
        where TConfigurationManager : IConfigurationManager<TConfigurationManager>
    {
        /// <summary>
        /// Scrapper used by the current Manager.
        /// </summary>
        IConfigurationScrapper Scrapper { get; }
        
        /// <summary>
        /// ASetups Manager.
        /// </summary>
        /// <param name="scrapper"></param>
        /// <returns>Current Manager.</returns>
        TConfigurationManager Setup(IConfigurationScrapper scrapper);
    }
}