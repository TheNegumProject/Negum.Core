using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for INegumConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfigurationManager : ConfigurationManager<INegumConfigurationManager>,
        INegumConfigurationManager
    {
    }

    public class NegumConfigurationManagerSection :
        ConfigurationManagerSection<NegumConfigurationManagerSection>,
        INegumConfigurationOptions,
        INegumConfigurationRules,
        INegumConfigurationConfig,
        INegumConfigurationDebug,
        INegumConfigurationVideo,
        INegumConfigurationSound,
        INegumConfigurationMisc,
        INegumConfigurationArcade,
        INegumConfigurationInput,
        INegumConfigurationKeys
    {
        INegumConfigurationOptions IConfigurationManagerSection<INegumConfigurationOptions>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationRules IConfigurationManagerSection<INegumConfigurationRules>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationConfig IConfigurationManagerSection<INegumConfigurationConfig>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationDebug IConfigurationManagerSection<INegumConfigurationDebug>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationVideo IConfigurationManagerSection<INegumConfigurationVideo>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationSound IConfigurationManagerSection<INegumConfigurationSound>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationMisc IConfigurationManagerSection<INegumConfigurationMisc>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationArcade IConfigurationManagerSection<INegumConfigurationArcade>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationInput IConfigurationManagerSection<INegumConfigurationInput>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        INegumConfigurationKeys IConfigurationManagerSection<INegumConfigurationKeys>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);
    }
}