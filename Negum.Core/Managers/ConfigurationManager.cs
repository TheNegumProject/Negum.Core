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
    }
}