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
        /// <summary>
        /// Image to be displayed.
        /// </summary>
        ISpriteEntry Sprite => this.Scrapper.GetSprite(this.KeyPrefix + ".spr");

        /// <summary>
        /// Offset by which current image should be moved.
        /// </summary>
        IPositionEntry Offset => this.Scrapper.GetPosition(this.KeyPrefix + ".offset");

        /// <summary>
        /// Scales the image.
        /// </summary>
        IPositionEntry Scale => this.Scrapper.GetPosition(this.KeyPrefix + ".scale");

        /// <summary>
        /// Direction of image facing.
        /// </summary>
        int Facing => this.Scrapper.GetInt(this.KeyPrefix + ".facing");

        IBoxEntry Window => this.Scrapper.GetBox(this.KeyPrefix + ".window");
        int Animation => this.Scrapper.GetInt(this.KeyPrefix + ".anim");

        /// <summary>
        /// Describes how long to display current image.
        /// </summary>
        ITimeEntry Time => Scrapper.GetTime(this.KeyPrefix + ".time");
    }
}