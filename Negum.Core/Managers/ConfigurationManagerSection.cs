using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigurationManagerSection<TConfigurationManagerSection> : IConfigurationManagerSection<TConfigurationManagerSection>
        where TConfigurationManagerSection : IConfigurationManagerSection<TConfigurationManagerSection>
    {
        public IConfigurationSectionScrapper Scrapper { get; protected set; }
        public string SectionName { get; protected set; }
        
        public TConfigurationManagerSection Setup(IConfigurationSectionScrapper scrapper, string sectionName)
        {
            this.Scrapper = scrapper;
            this.SectionName = sectionName;
            return (TConfigurationManagerSection) (IConfigurationManagerSection<TConfigurationManagerSection>) this;
        }
    }
}