using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
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
        string Version => this.GetValue<string>("fntversion");

        /// <summary>
        /// Name of this Font.
        /// </summary>
        string Name => this.GetValue<string>("name");
    }

    public interface IFontNegumDef : INegumManagerSection
    {
        /// <summary>
        /// Type of this Font.
        /// Example: bitmap
        /// </summary>
        string Type => this.GetValue<string>("Type");

        /// <summary>
        /// Bank numbers are mapped to palette numbers (0, bank).
        /// </summary>
        string BankType => this.GetValue<string>("BankType");

        /// <summary>
        /// Size of font: width, height.  Width is used for spaces.
        /// </summary>
        IVectorEntry Size => this.GetValue<IVectorEntry>("Size");

        /// <summary>
        /// Spacing between font glyphs: width, height.
        /// </summary>
        IVectorEntry Spacing => this.GetValue<IVectorEntry>("Spacing");

        /// <summary>
        /// Drawing offset: x, y.
        /// </summary>
        IVectorEntry Offset => this.GetValue<IVectorEntry>("Offset");

        /// <summary>
        /// Filename of the sff containing the glyphs.
        /// </summary>
        IFileEntry File => this.GetValue<IFileEntry>("File");
    }
}