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
        IImageEntry BigPortrait => this.Scrapper.GetImage(this.Section.Name, this.KeyPrefix);
        IPlayerSelectionCursorEntry Cursor => this.Scrapper.GetPlayerSelectionCursor(this.Section.Name, this.KeyPrefix + ".cursor");
        IMovementEntry RandomMove => this.Scrapper.GetMovement(this.Section.Name, this.KeyPrefix + ".random");
        IImageEntry Face => this.Scrapper.GetImage(this.Section.Name, this.KeyPrefix + ".face");
        ITextEntry Name => this.Scrapper.GetText(this.Section.Name, this.KeyPrefix + ".name");
        IPlayerSelectionTeamMenuEntry MenuEntry => this.Scrapper.GetPlayerSelectionTeamMenu(this.Section.Name, this.KeyPrefix + ".teammenu");
    }
}