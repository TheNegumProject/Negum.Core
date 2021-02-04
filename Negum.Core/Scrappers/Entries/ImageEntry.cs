namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ImageEntry : ScrappedEntry<IImageEntry>, IImageEntry
    {
        public IPositionEntry Sprite => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".spr");
        public IPositionEntry Offset => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".offset");
        public IPositionEntry Scale => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".scale");
        public int Facing => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".facing");
        public IBoxEntry Window => this.Scrapper.GetBox(this.Section.Name, this.KeyPrefix + ".window");
    }
}