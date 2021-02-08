using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageConfigurationManager : ConfigurationManager<IStageConfigurationManager>,
        IStageConfigurationManager
    {
    }

    public class StageConfigurationManagerSection :
        ConfigurationManagerSection<StageConfigurationManagerSection>,
        IStageConfigurationInfo,
        IStageConfigurationCamera,
        IStageConfigurationPlayerInfo,
        IStageConfigurationBound,
        IStageConfigurationStageInfo,
        IStageConfigurationShadow,
        IStageConfigurationReflection,
        IStageConfigurationMusic,
        IStageConfigurationBackgroundDef,
        IStageConfigurationBackground
    {
        IStageConfigurationInfo IConfigurationManagerSection<IStageConfigurationInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationCamera IConfigurationManagerSection<IStageConfigurationCamera>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationPlayerInfo IConfigurationManagerSection<IStageConfigurationPlayerInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationBound IConfigurationManagerSection<IStageConfigurationBound>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationStageInfo IConfigurationManagerSection<IStageConfigurationStageInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationShadow IConfigurationManagerSection<IStageConfigurationShadow>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationReflection IConfigurationManagerSection<IStageConfigurationReflection>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationMusic IConfigurationManagerSection<IStageConfigurationMusic>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationBackgroundDef IConfigurationManagerSection<IStageConfigurationBackgroundDef>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);

        IStageConfigurationBackground IConfigurationManagerSection<IStageConfigurationBackground>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(Scrapper);
    }
}