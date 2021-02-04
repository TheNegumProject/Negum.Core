namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PlayerSelectionCursorEntry : ScrappedEntry<IPlayerSelectionCursorEntry>, IPlayerSelectionCursorEntry
    {
        public string StartCell => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".startcell");
        public IAnimationEntry Animation => this.Scrapper.GetAnimation(this.Section.Name, this.KeyPrefix + ".active");
        public IMovementEntry Movement => this.Scrapper.GetMovement(this.Section.Name, this.KeyPrefix);
    }
}