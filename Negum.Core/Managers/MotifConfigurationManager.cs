using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for IMotifConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public static class MotifConfigurationManager
    {
        /// <summary>
        /// Scrapper which is used to gather appropriate parsed data from given configuration.
        /// </summary>
        private static IConfigurationScrapper Scrapper { get; } =
            NegumContainer.Resolve<IConfigurationScrapper>().Use<IMotifConfiguration>();
    }
}