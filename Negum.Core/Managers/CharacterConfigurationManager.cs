namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterConfigurationManager : ConfigurationManager, ICharacterConfigurationManager
    {
    }

    public class CharacterConfigurationManagerSection :
        ConfigurationManagerSection,
        ICharacterConfigurationInfo,
        ICharacterConfigurationFiles,
        ICharacterConfigurationPaletteKeymap,
        ICharacterConfigurationArcade
    {
    }
}