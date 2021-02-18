namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterStoryboardSceneNegumManager : NegumManager,
        ICharacterStoryboardSceneNegumManager
    {
    }

    public class CharacterStoryboardSceneNegumManagerSection :
        NegumManagerSection,
        ICharacterStoryboardSceneNegumSceneDef,
        ICharacterStoryboardSceneNegumScene
    {
    }
}