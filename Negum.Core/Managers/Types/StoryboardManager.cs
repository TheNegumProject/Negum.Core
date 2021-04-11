using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StoryboardManager : Manager, IStoryboardManager
    {
        protected override IManagerSection GetNewManagerSection(string sectionName, IConfigurationSection configSection) =>
            new StoryboardManagerSection(sectionName, configSection);
    }

    public class StoryboardManagerSection :
        ManagerSection,
        IStoryboardSceneDef,
        IStoryboardScene
    {
        public StoryboardManagerSection(string name, IConfigurationSection section) :
            base(name, section)
        {
        }
    }
}