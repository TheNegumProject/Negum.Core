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
        IMotifConfigurationTitleBgDef,
        IMotifConfigurationInfobox,
        IMotifConfigurationSelectInfo,
        IMotifConfigurationSelectBgDef,
        IMotifConfigurationVsScreen,
        IMotifConfigurationVsBgDef,
        IMotifConfigurationDemoMode,
        IMotifConfigurationContinueScreen,
        IMotifConfigurationGameOverScreen,
        IMotifConfigurationVictoryScreen,
        IMotifConfigurationWinScreen,
        IMotifConfigurationDefaultEnding,
        IMotifConfigurationEndCredits,
        IMotifConfigurationSurvivalResultsScreen,
        IMotifConfigurationOptionInfo,
        IMotifConfigurationScreenBg
    {
        IMotifConfigurationInfo IConfigurationManagerSection<IMotifConfigurationInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationFiles IConfigurationManagerSection<IMotifConfigurationFiles>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationMusic IConfigurationManagerSection<IMotifConfigurationMusic>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationTitleInfo IConfigurationManagerSection<IMotifConfigurationTitleInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationTitleBgDef IConfigurationManagerSection<IMotifConfigurationTitleBgDef>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationInfobox IConfigurationManagerSection<IMotifConfigurationInfobox>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationSelectInfo IConfigurationManagerSection<IMotifConfigurationSelectInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationSelectBgDef IConfigurationManagerSection<IMotifConfigurationSelectBgDef>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationVsScreen IConfigurationManagerSection<IMotifConfigurationVsScreen>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationVsBgDef IConfigurationManagerSection<IMotifConfigurationVsBgDef>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationDemoMode IConfigurationManagerSection<IMotifConfigurationDemoMode>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationContinueScreen IConfigurationManagerSection<IMotifConfigurationContinueScreen>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationGameOverScreen IConfigurationManagerSection<IMotifConfigurationGameOverScreen>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationVictoryScreen IConfigurationManagerSection<IMotifConfigurationVictoryScreen>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationWinScreen IConfigurationManagerSection<IMotifConfigurationWinScreen>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationDefaultEnding IConfigurationManagerSection<IMotifConfigurationDefaultEnding>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationEndCredits IConfigurationManagerSection<IMotifConfigurationEndCredits>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationSurvivalResultsScreen IConfigurationManagerSection<IMotifConfigurationSurvivalResultsScreen>.
            Setup(IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationOptionInfo IConfigurationManagerSection<IMotifConfigurationOptionInfo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IMotifConfigurationScreenBg IConfigurationManagerSection<IMotifConfigurationScreenBg>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}