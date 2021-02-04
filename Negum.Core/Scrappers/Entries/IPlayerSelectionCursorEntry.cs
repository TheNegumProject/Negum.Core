namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player selection cursor.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionCursorEntry : IScrapperEntry<IPlayerSelectionCursorEntry>
    {
        string StartCell { get; }
        IAnimationEntry Animation { get; }
        IMovementEntry Movement { get; }
    }
}