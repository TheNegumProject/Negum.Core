namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterCommandsManager : ConfigurationManager, ICharacterCommandsManager
    {
    }

    public class CharacterCommandsManagerSection :
        ConfigurationManagerSection,
        ICharacterCommandsRemap,
        ICharacterCommandsDefaults,
        ICharacterCommandsCommand,
        ICharacterCommandsCommandStatedef,
        ICharacterCommandsState
    {
    }
}