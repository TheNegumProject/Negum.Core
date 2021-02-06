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
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationRules IConfigurationManagerSection<INegumConfigurationRules>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationConfig IConfigurationManagerSection<INegumConfigurationConfig>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationDebug IConfigurationManagerSection<INegumConfigurationDebug>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationVideo IConfigurationManagerSection<INegumConfigurationVideo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationSound IConfigurationManagerSection<INegumConfigurationSound>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationMisc IConfigurationManagerSection<INegumConfigurationMisc>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationArcade IConfigurationManagerSection<INegumConfigurationArcade>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationInput IConfigurationManagerSection<INegumConfigurationInput>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        INegumConfigurationKeys IConfigurationManagerSection<INegumConfigurationKeys>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}