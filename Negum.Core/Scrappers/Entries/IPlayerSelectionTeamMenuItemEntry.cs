namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player Team Menu Item.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuItemEntry : IScrapperEntry
    {
        ITextEntry Item => Scrapper.GetText(this.KeyPrefix);
        IVectorEntry Active => Scrapper.GetVector(this.KeyPrefix + ".active");
        IVectorEntry Active2 => Scrapper.GetVector(this.KeyPrefix + ".active2");
        IImageEntry Cursor => Scrapper.GetImage(this.KeyPrefix + ".cursor");
    }
}