using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Font configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFontConfigurationManager : IConfigurationManager<IFontConfigurationManager>
    {
        IFontConfigurationFontV2 FontV2 =>
            NegumContainer.Resolve<IFontConfigurationFontV2>().Setup(this.Scrapper.GetSection("FNT V2"));

        IFontConfigurationDef Def =>
            NegumContainer.Resolve<IFontConfigurationDef>().Setup(this.Scrapper.GetSection("Def"));
    }

    public interface IFontConfigurationFontV2 : IConfigurationManagerSection<IFontConfigurationFontV2>
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

    public interface IFontConfigurationDef : IConfigurationManagerSection<IFontConfigurationDef>
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