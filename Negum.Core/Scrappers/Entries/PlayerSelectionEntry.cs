namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PlayerSelectionEntry : ScrappedEntry<IPlayerSelectionEntry>, IPlayerSelectionEntry
    {
        public IPlayerSelectionCursorEntry Cursor => this.Scrapper.GetPlayerSelectionCursor(this.Section.Name, this.KeyPrefix + ".cursor");
        public IMovementEntry RandomMove => this.Scrapper.GetMovement(this.Section.Name, this.KeyPrefix + ".random");
        public IImageEntry Face => this.Scrapper.GetImage(this.Section.Name, this.KeyPrefix + ".face");
        public ITextEntry Name => this.Scrapper.GetText(this.Section.Name, this.KeyPrefix + ".name");
    }
}