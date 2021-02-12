namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player selection.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionEntry : IScrapperEntry
    {
        IImageEntry BigPortrait => this.Scrapper.GetImage(this.KeyPrefix);
        IPlayerSelectionCursorEntry Cursor => this.Scrapper.GetPlayerSelectionCursor(this.KeyPrefix + ".cursor");
        IMovementEntry RandomMove => this.Scrapper.GetMovement(this.KeyPrefix + ".random");
        IImageEntry Face => this.Scrapper.GetImage(this.KeyPrefix + ".face");
        ITextEntry Name => this.Scrapper.GetText(this.KeyPrefix + ".name");
        IPlayerSelectionTeamMenuEntry MenuEntry => this.Scrapper.GetPlayerSelectionTeamMenu(this.KeyPrefix + ".teammenu");
    }
}