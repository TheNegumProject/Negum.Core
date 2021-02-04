namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Image.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IImageEntry : IScrapperEntry<IImageEntry>
    {
        IPositionEntry Sprite { get; }
        IPositionEntry Offset { get; }
        IPositionEntry Scale { get; }
        int Facing { get; }
        IBoxEntry Window { get; }
    }
}