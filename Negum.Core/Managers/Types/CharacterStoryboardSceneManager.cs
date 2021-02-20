namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterStoryboardSceneManager : Manager,
        ICharacterStoryboardSceneManager
    {
    }

    public class CharacterStoryboardSceneManagerSection :
        ManagerSection,
        ICharacterStoryboardSceneSceneDef,
        ICharacterStoryboardSceneScene
    {
    }
}