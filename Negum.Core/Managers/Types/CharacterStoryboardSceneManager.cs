using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterStoryboardSceneManager : Manager, ICharacterStoryboardSceneManager
    {
        protected override IManagerSection GetNewManagerSection(string sectionName,
            IConfigurationSection configSection) =>
            new CharacterStoryboardSceneManagerSection(sectionName, configSection);
    }

    public class CharacterStoryboardSceneManagerSection :
        ManagerSection,
        ICharacterStoryboardSceneSceneDef,
        ICharacterStoryboardSceneScene
    {
        public CharacterStoryboardSceneManagerSection(string name, IConfigurationSection section) :
            base(name, section)
        {
        }
    }
}