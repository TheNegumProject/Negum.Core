namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterCommandsManager : Manager, ICharacterCommandsManager
    {
    }

    public class CharacterCommandsManagerSection :
        ManagerSection,
        ICharacterCommandsRemap,
        ICharacterCommandsDefaults,
        ICharacterCommandsCommand,
        ICharacterCommandsCommandStatedef,
        ICharacterCommandsState
    {
    }
}