namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FightConfigurationManager : ConfigurationManager, IFightConfigurationManager
    {
    }

    public class FightConfigurationManagerSection :
        ConfigurationManagerSection,
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
    }
}