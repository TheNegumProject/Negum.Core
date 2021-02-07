namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent a Text.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ITextEntry : IScrapperEntry<ITextEntry>
    {
        /// <summary>
        /// Position of the text.
        /// </summary>
        IPositionEntry Offset => this.Scrapper.GetPosition(this.KeyPrefix + ".offset");

        /// <summary>
        /// Font the text.
        /// Set for -1 for none / no display.
        /// </summary>
        IFontEntry Font => this.Scrapper.GetFont(this.KeyPrefix + ".font");

        IPositionEntry Spacing => this.Scrapper.GetPosition(this.KeyPrefix + ".spacing");
        string Text => this.Scrapper.GetString(this.KeyPrefix + ".text");
        IBoxEntry Window => Scrapper.GetBox(this.KeyPrefix + ".window");
        string TextWrap => Scrapper.GetString(this.KeyPrefix + ".textwrap");
        ITimeEntry DisplayTime => Scrapper.GetTime(this.KeyPrefix + ".displaytime");
        int Layer => Scrapper.GetInt(this.KeyPrefix + ".layerno");
        IPositionEntry Scale => Scrapper.GetPosition(this.KeyPrefix + ".scale");
    }
}