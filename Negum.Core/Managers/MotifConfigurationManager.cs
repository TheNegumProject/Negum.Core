namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for IMotifConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifConfigurationManager : ConfigurationManager, IMotifConfigurationManager
    {
    }

    public class MotifConfigurationManagerSection :
        ConfigurationManagerSection,
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
    }
}