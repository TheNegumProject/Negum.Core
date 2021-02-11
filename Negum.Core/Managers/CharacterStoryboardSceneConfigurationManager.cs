namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterStoryboardSceneConfigurationManager : ConfigurationManager,
        ICharacterStoryboardSceneConfigurationManager
    {
    }

    public class CharacterStoryboardSceneConfigurationManagerSection :
        ConfigurationManagerSection,
        ICharacterStoryboardSceneConfigurationSceneDef,
        ICharacterStoryboardSceneConfigurationScene
    {
    }
}