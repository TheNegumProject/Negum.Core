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
        ISpriteEntry Sprite => this.Scrapper.GetSprite(this.KeyPrefix + ".spr");
        IPositionEntry Offset => this.Scrapper.GetPosition(this.KeyPrefix + ".offset");
        IPositionEntry Scale => this.Scrapper.GetPosition(this.KeyPrefix + ".scale");
        int Facing => this.Scrapper.GetInt(this.KeyPrefix + ".facing");
        IBoxEntry Window => this.Scrapper.GetBox(this.KeyPrefix + ".window");
    }
}