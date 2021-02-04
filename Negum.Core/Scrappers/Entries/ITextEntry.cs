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
        IPositionEntry Offset { get; }

        /// <summary>
        /// Font the text.
        /// Set for -1 for none / no display.
        /// </summary>
        IFontEntry Font { get; }

        IPositionEntry Spacing { get; }
        string Text { get; }
    }
}