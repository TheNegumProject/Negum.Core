namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player Team Menu Item.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuItemEntry : IScrapperEntry<IPlayerSelectionTeamMenuItemEntry>
    {
        ITextEntry Item => Scrapper.GetText(this.KeyPrefix);
        IFontEntry Active => Scrapper.GetFont(this.KeyPrefix + ".active");
        IFontEntry Active2 => Scrapper.GetFont(this.KeyPrefix + ".active2");
        IImageEntry Cursor => Scrapper.GetImage(this.KeyPrefix + ".cursor");
    }
}