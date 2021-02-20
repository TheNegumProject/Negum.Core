namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontManager : Manager, IFontManager
    {
    }

    public class FontManagerSection :
        ManagerSection,
        IFontFontV2,
        IFontDef
    {
    }
}