namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class FontNegumManager : NegumManager, IFontNegumManager
    {
    }

    public class FontNegumManagerSection :
        NegumManagerSection,
        IFontNegumFontV2,
        IFontNegumDef
    {
    }
}