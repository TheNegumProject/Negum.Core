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
        IMotifConfigurationOptionInfo
    {
        IMotifConfigurationInfo IConfigurationManagerSection<IMotifConfigurationInfo>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationFiles IConfigurationManagerSection<IMotifConfigurationFiles>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationMusic IConfigurationManagerSection<IMotifConfigurationMusic>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationTitleInfo IConfigurationManagerSection<IMotifConfigurationTitleInfo>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationTitleBgDef IConfigurationManagerSection<IMotifConfigurationTitleBgDef>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationInfobox IConfigurationManagerSection<IMotifConfigurationInfobox>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationSelectInfo IConfigurationManagerSection<IMotifConfigurationSelectInfo>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationSelectBgDef IConfigurationManagerSection<IMotifConfigurationSelectBgDef>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationVsScreen IConfigurationManagerSection<IMotifConfigurationVsScreen>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationVsBgDef IConfigurationManagerSection<IMotifConfigurationVsBgDef>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationDemoMode IConfigurationManagerSection<IMotifConfigurationDemoMode>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationContinueScreen IConfigurationManagerSection<IMotifConfigurationContinueScreen>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationGameOverScreen IConfigurationManagerSection<IMotifConfigurationGameOverScreen>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationVictoryScreen IConfigurationManagerSection<IMotifConfigurationVictoryScreen>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationWinScreen IConfigurationManagerSection<IMotifConfigurationWinScreen>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationDefaultEnding IConfigurationManagerSection<IMotifConfigurationDefaultEnding>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationEndCredits IConfigurationManagerSection<IMotifConfigurationEndCredits>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationSurvivalResultsScreen IConfigurationManagerSection<IMotifConfigurationSurvivalResultsScreen>.
            Setup(IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IMotifConfigurationOptionInfo IConfigurationManagerSection<IMotifConfigurationOptionInfo>.Setup(
            IConfigurationScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);
    }
}