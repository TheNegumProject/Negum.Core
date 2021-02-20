namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StageManager : Manager, IStageManager
    {
    }

    public class StageManagerSection :
        ManagerSection,
        IStageInfo,
        IStageCamera,
        IStagePlayerInfo,
        IStageBound,
        IStageStageInfo,
        IStageShadow,
        IStageReflection,
        IStageMusic,
        IStageBackgroundDef,
        IStageBackground
    {
    }
}