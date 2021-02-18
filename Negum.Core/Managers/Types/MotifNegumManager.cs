namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for IMotifConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MotifNegumManager : NegumManager, IMotifNegumManager
    {
    }

    public class MotifNegumManagerSection :
        NegumManagerSection,
        IMotifNegumInfo,
        IMotifNegumFiles,
        IMotifNegumMusic,
        IMotifNegumTitleInfo,
        IMotifNegumInfobox,
        IMotifNegumSelectInfo,
        IMotifNegumVsScreen,
        IMotifNegumDemoMode,
        IMotifNegumContinueScreen,
        IMotifNegumGameOverScreen,
        IMotifNegumVictoryScreen,
        IMotifNegumWinScreen,
        IMotifNegumDefaultEnding,
        IMotifNegumEndCredits,
        IMotifNegumSurvivalResultsScreen,
        IMotifNegumScreenBg,
        IMotifNegumScreenBgDef
    {
    }
}