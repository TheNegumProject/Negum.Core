namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player selection.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionEntry : IScrapperEntry<IPlayerSelectionEntry>
    {
        IPlayerSelectionCursorEntry Cursor { get; }
        // IPlayerSelectionRandomEntry Random { get; }
        // IPlayerSelectionImageEntry Face { get; }
        // IPlayerSelectionImageEntry Name { get; }
        // IPlayerSelectionTeamMenuEntry MenuEntry { get; }
    }
}