namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageConfigurationManager : ConfigurationManager, IStageConfigurationManager
    {
    }

    public class StageConfigurationManagerSection :
        ConfigurationManagerSection,
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
    }
}