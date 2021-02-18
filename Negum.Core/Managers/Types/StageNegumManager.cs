namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageNegumManager : NegumManager, IStageNegumManager
    {
    }

    public class StageNegumManagerSection :
        NegumManagerSection,
        IStageNegumInfo,
        IStageNegumCamera,
        IStageNegumPlayerInfo,
        IStageNegumBound,
        IStageNegumStageInfo,
        IStageNegumShadow,
        IStageNegumReflection,
        IStageNegumMusic,
        IStageNegumBackgroundDef,
        IStageNegumBackground
    {
    }
}