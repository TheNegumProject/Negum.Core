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
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationCamera IConfigurationManagerSection<IStageConfigurationCamera>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationPlayerInfo IConfigurationManagerSection<IStageConfigurationPlayerInfo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationBound IConfigurationManagerSection<IStageConfigurationBound>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationStageInfo IConfigurationManagerSection<IStageConfigurationStageInfo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationShadow IConfigurationManagerSection<IStageConfigurationShadow>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationReflection IConfigurationManagerSection<IStageConfigurationReflection>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationMusic IConfigurationManagerSection<IStageConfigurationMusic>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationBackgroundDef IConfigurationManagerSection<IStageConfigurationBackgroundDef>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IStageConfigurationBackground IConfigurationManagerSection<IStageConfigurationBackground>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);
    }
}