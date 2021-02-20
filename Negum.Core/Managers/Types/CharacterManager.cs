namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterManager : Manager, ICharacterManager
    {
    }

    public class CharacterManagerSection :
        ManagerSection,
        ICharacterInfo,
        ICharacterFiles,
        ICharacterPaletteKeymap,
        ICharacterArcade
    {
    }
}