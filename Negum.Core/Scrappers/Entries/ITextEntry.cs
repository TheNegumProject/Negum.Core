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
        IVectorEntry Offset => this.Scrapper.GetVector(this.KeyPrefix + ".offset");

        /// <summary>
        /// Font the text.
        /// Set for -1 for none / no display.
        /// </summary>
        IVectorEntry Font => this.Scrapper.GetVector(this.KeyPrefix + ".font");

        IVectorEntry Spacing => this.Scrapper.GetVector(this.KeyPrefix + ".spacing");
        string Text => this.Scrapper.GetString(this.KeyPrefix + ".text");
        IVectorEntry Window => Scrapper.GetVector(this.KeyPrefix + ".window");
        string TextWrap => Scrapper.GetString(this.KeyPrefix + ".textwrap");
        ITimeEntry DisplayTime => Scrapper.GetTime(this.KeyPrefix + ".displaytime");
        int Layer => Scrapper.GetInt(this.KeyPrefix + ".layerno");
        IVectorEntry Scale => Scrapper.GetVector(this.KeyPrefix + ".scale");
        
        /// <summary>
        /// Set to true to shake the text.
        /// </summary>
        bool Shake => Scrapper.GetBoolean(this.KeyPrefix + ".shake");
    }
}