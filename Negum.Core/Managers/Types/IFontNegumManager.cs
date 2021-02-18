using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Font configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFontNegumManager : INegumManager
    {
        IFontNegumFontV2 FontV2 => this.GetSection<IFontNegumFontV2>("FNT V2");
        IFontNegumDef Def => this.GetSection<IFontNegumDef>("Def");
    }

    public interface IFontNegumFontV2 : INegumManagerSection
    {
        /// <summary>
        /// Version of this Font.
        /// </summary>
        string Version => Scrapper.GetString("fntversion");

        /// <summary>
        /// Name of this Font.
        /// </summary>
        string Name => Scrapper.GetString("name");
    }

    public interface IFontNegumDef : INegumManagerSection
    {
        /// <summary>
        /// Type of this Font.
        /// Example: bitmap
        /// </summary>
        string Type => Scrapper.GetString("Type");

        /// <summary>
        /// Bank numbers are mapped to palette numbers (0, bank).
        /// </summary>
        string BankType => Scrapper.GetString("BankType");

        /// <summary>
        /// Size of font: width, height.  Width is used for spaces.
        /// </summary>
        IVectorEntry Size => Scrapper.GetVector("Size");

        /// <summary>
        /// Spacing between font glyphs: width, height.
        /// </summary>
        IVectorEntry Spacing => Scrapper.GetVector("Spacing");

        /// <summary>
        /// Drawing offset: x, y.
        /// </summary>
        IVectorEntry Offset => Scrapper.GetVector("Offset");

        /// <summary>
        /// Filename of the sff containing the glyphs.
        /// </summary>
        IFileEntry File => Scrapper.GetFile("File");
    }
}