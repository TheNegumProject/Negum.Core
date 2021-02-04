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
        IPositionEntry Offset { get; }
        IFontEntry Font { get; }
        IPositionEntry Spacing { get; }
        string Text { get; }
    }
}