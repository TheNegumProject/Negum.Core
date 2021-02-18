namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterCommandsManager : NegumManager, ICharacterCommandsManager
    {
    }

    public class CharacterCommandsManagerSection :
        NegumManagerSection,
        ICharacterCommandsRemap,
        ICharacterCommandsDefaults,
        ICharacterCommandsCommand,
        ICharacterCommandsCommandStatedef,
        ICharacterCommandsState
    {
    }
}