namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Image.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IImageEntry : IScrapperEntry<IImageEntry>
    {
        ISpriteEntry Sprite => this.Scrapper.GetSprite(this.Section.Name, this.KeyPrefix + ".spr");
        IPositionEntry Offset => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".offset");
        IPositionEntry Scale => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".scale");
        int Facing => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".facing");
        IBoxEntry Window => this.Scrapper.GetBox(this.Section.Name, this.KeyPrefix + ".window");
    }
}