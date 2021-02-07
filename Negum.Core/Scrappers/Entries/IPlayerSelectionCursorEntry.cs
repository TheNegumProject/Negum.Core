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
        string StartCell => this.Scrapper.GetString(this.KeyPrefix + ".startcell");
        IImageEntry Animation => this.Scrapper.GetImage(this.KeyPrefix + ".active");
        IMovementEntry Movement => this.Scrapper.GetMovement(this.KeyPrefix);
    }
}