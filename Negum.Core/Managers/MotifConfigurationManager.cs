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
    public class MotifConfigurationManager : ConfigurationManager<IMotifConfigurationManager>,
        IMotifConfigurationManager
    {
    }

    public class MotifConfigurationManagerSection :
        ConfigurationManagerSection<MotifConfigurationManagerSection>,
        IMotifConfigurationInfo,
        IMotifConfigurationFiles,
        IMotifConfigurationMusic,
        IMotifConfigurationTitleInfo,
        IMotifConfigurationInfobox,
        IMotifConfigurationSelectInfo,
        IMotifConfigurationVsScreen,
        IMotifConfigurationDemoMode,
        IMotifConfigurationContinueScreen,
        IMotifConfigurationGameOverScreen,
        IMotifConfigurationVictoryScreen,
        IMotifConfigurationWinScreen,
        IMotifConfigurationDefaultEnding,
        IMotifConfigurationEndCredits,
        IMotifConfigurationSurvivalResultsScreen,
        IMotifConfigurationScreenBg,
        IMotifConfigurationScreenBgDef
    {
        IMotifConfigurationInfo IConfigurationManagerSection<IMotifConfigurationInfo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationFiles IConfigurationManagerSection<IMotifConfigurationFiles>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationMusic IConfigurationManagerSection<IMotifConfigurationMusic>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationTitleInfo IConfigurationManagerSection<IMotifConfigurationTitleInfo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationInfobox IConfigurationManagerSection<IMotifConfigurationInfobox>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationSelectInfo IConfigurationManagerSection<IMotifConfigurationSelectInfo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationVsScreen IConfigurationManagerSection<IMotifConfigurationVsScreen>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationDemoMode IConfigurationManagerSection<IMotifConfigurationDemoMode>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationContinueScreen IConfigurationManagerSection<IMotifConfigurationContinueScreen>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationGameOverScreen IConfigurationManagerSection<IMotifConfigurationGameOverScreen>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationVictoryScreen IConfigurationManagerSection<IMotifConfigurationVictoryScreen>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationWinScreen IConfigurationManagerSection<IMotifConfigurationWinScreen>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationDefaultEnding IConfigurationManagerSection<IMotifConfigurationDefaultEnding>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationEndCredits IConfigurationManagerSection<IMotifConfigurationEndCredits>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationSurvivalResultsScreen IConfigurationManagerSection<IMotifConfigurationSurvivalResultsScreen>.
            Setup(IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationScreenBg IConfigurationManagerSection<IMotifConfigurationScreenBg>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationScreenBgDef IConfigurationManagerSection<IMotifConfigurationScreenBgDef>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);
    }
}