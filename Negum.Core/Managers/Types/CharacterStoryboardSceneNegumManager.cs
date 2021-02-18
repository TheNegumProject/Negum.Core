namespace Negum.Core.Managers
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