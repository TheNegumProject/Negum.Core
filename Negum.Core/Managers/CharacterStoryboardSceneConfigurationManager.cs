using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterStoryboardSceneConfigurationManager :
        ConfigurationManager<ICharacterStoryboardSceneConfigurationManager>,
        ICharacterStoryboardSceneConfigurationManager
    {
    }

    public class CharacterStoryboardSceneConfigurationManagerSection :
        ConfigurationManagerSection<CharacterStoryboardSceneConfigurationManagerSection>,
        ICharacterStoryboardSceneConfigurationSceneDef,
        ICharacterStoryboardSceneConfigurationScene
    {
        ICharacterStoryboardSceneConfigurationSceneDef
            IConfigurationManagerSection<ICharacterStoryboardSceneConfigurationSceneDef>.Setup(
                IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);

        ICharacterStoryboardSceneConfigurationScene
            IConfigurationManagerSection<ICharacterStoryboardSceneConfigurationScene>.Setup(
                IConfigurationSectionScrapper scrapper) => this.Setup(scrapper);
    }
}