namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Stage configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStageConfigurationManager : IConfigurationManager<IStageConfigurationManager>
    {
    }

    public interface IStageConfigurationInfo : IConfigurationManagerSection<IStageConfigurationInfo>
    {
    }
    
    public interface IStageConfigurationCamera : IConfigurationManagerSection<IStageConfigurationCamera>
    {
    }
    
    public interface IStageConfigurationPlayerInfo : IConfigurationManagerSection<IStageConfigurationPlayerInfo>
    {
    }
    
    public interface IStageConfigurationBound : IConfigurationManagerSection<IStageConfigurationBound>
    {
    }
    
    public interface IStageConfigurationStageInfo : IConfigurationManagerSection<IStageConfigurationStageInfo>
    {
    }
    
    public interface IStageConfigurationShadow : IConfigurationManagerSection<IStageConfigurationShadow>
    {
    }
    
    public interface IStageConfigurationReflection : IConfigurationManagerSection<IStageConfigurationReflection>
    {
    }
    
    public interface IStageConfigurationMusic : IConfigurationManagerSection<IStageConfigurationMusic>
    {
    }
    
    public interface IStageConfigurationBackgroundDef : IConfigurationManagerSection<IStageConfigurationBackgroundDef>
    {
    }
    
    public interface IStageConfigurationBackground : IConfigurationManagerSection<IStageConfigurationBackground>
    {
    }
}