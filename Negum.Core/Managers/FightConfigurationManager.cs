using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FightConfigurationManager : ConfigurationManager<IFightConfigurationManager>,
        IFightConfigurationManager
    {
    }

    public class FightConfigurationManagerSection :
        ConfigurationManagerSection<FightConfigurationManagerSection>,
        IFightConfigurationFiles,
        IFightConfigurationFightFx,
        IFightConfigurationLifebar,
        IFightConfigurationSimulLifebar,
        IFightConfigurationTurnsLifebar,
        IFightConfigurationPowerbar,
        IFightConfigurationFace,
        IFightConfigurationSimulFace,
        IFightConfigurationTurnsFace,
        IFightConfigurationName,
        IFightConfigurationSimulName,
        IFightConfigurationTurnsName,
        IFightConfigurationTime,
        IFightConfigurationCombo,
        IFightConfigurationRound,
        IFightConfigurationWinIcon
    {
        IFightConfigurationFiles IConfigurationManagerSection<IFightConfigurationFiles>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationFightFx IConfigurationManagerSection<IFightConfigurationFightFx>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationLifebar IConfigurationManagerSection<IFightConfigurationLifebar>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationSimulLifebar IConfigurationManagerSection<IFightConfigurationSimulLifebar>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationTurnsLifebar IConfigurationManagerSection<IFightConfigurationTurnsLifebar>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationPowerbar IConfigurationManagerSection<IFightConfigurationPowerbar>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationFace IConfigurationManagerSection<IFightConfigurationFace>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationSimulFace IConfigurationManagerSection<IFightConfigurationSimulFace>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationTurnsFace IConfigurationManagerSection<IFightConfigurationTurnsFace>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationName IConfigurationManagerSection<IFightConfigurationName>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationSimulName IConfigurationManagerSection<IFightConfigurationSimulName>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationTurnsName IConfigurationManagerSection<IFightConfigurationTurnsName>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationTime IConfigurationManagerSection<IFightConfigurationTime>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationCombo IConfigurationManagerSection<IFightConfigurationCombo>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationRound IConfigurationManagerSection<IFightConfigurationRound>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);

        IFightConfigurationWinIcon IConfigurationManagerSection<IFightConfigurationWinIcon>.Setup(
            IConfigurationSectionScrapper scrapper, string sectionName) => this.Setup(scrapper, sectionName);
    }
}