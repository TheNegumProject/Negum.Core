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
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationFightFx IConfigurationManagerSection<IFightConfigurationFightFx>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationLifebar IConfigurationManagerSection<IFightConfigurationLifebar>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationSimulLifebar IConfigurationManagerSection<IFightConfigurationSimulLifebar>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationTurnsLifebar IConfigurationManagerSection<IFightConfigurationTurnsLifebar>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationPowerbar IConfigurationManagerSection<IFightConfigurationPowerbar>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationFace IConfigurationManagerSection<IFightConfigurationFace>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationSimulFace IConfigurationManagerSection<IFightConfigurationSimulFace>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationTurnsFace IConfigurationManagerSection<IFightConfigurationTurnsFace>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationName IConfigurationManagerSection<IFightConfigurationName>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationSimulName IConfigurationManagerSection<IFightConfigurationSimulName>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationTurnsName IConfigurationManagerSection<IFightConfigurationTurnsName>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationTime IConfigurationManagerSection<IFightConfigurationTime>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationCombo IConfigurationManagerSection<IFightConfigurationCombo>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationRound IConfigurationManagerSection<IFightConfigurationRound>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        IFightConfigurationWinIcon IConfigurationManagerSection<IFightConfigurationWinIcon>.Setup(
            IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}