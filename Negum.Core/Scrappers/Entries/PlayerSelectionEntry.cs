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
        public IPlayerSelectionCursorEntry Cursor => Scrapper.GetPlayerSelectionCursor(this.Section.Name, this.KeyPrefix + ".cursor");
        public IMovementEntry RandomMove => Scrapper.GetMovement(this.Section.Name, ".random");
    }
}