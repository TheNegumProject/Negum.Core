using Negum.Core.Configurations;

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
        protected override IManagerSection GetNewManagerSection(string sectionName,
            IConfigurationSection configSection) => new StageManagerSection(sectionName, configSection);
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
        public StageManagerSection(string name, IConfigurationSection section) : 
            base(name, section)
        {
        }
    }
}