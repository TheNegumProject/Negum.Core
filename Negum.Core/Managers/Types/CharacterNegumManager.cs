namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class CharacterNegumManager : NegumManager, ICharacterNegumManager
    {
    }

    public class CharacterNegumManagerSection :
        NegumManagerSection,
        ICharacterNegumInfo,
        ICharacterNegumFiles,
        ICharacterNegumPaletteKeymap,
        ICharacterNegumArcade
    {
    }
}