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
        IVectorEntry Sprite => this.Scrapper.GetVector(this.KeyPrefix + ".spr");

        /// <summary>
        /// Offset by which current image should be moved.
        /// </summary>
        IVectorEntry Offset => this.Scrapper.GetVector(this.KeyPrefix + ".offset");

        /// <summary>
        /// Scales the image.
        /// </summary>
        IVectorEntry Scale => this.Scrapper.GetVector(this.KeyPrefix + ".scale");

        /// <summary>
        /// Direction of image facing.
        /// </summary>
        int Facing => this.Scrapper.GetInt(this.KeyPrefix + ".facing");

        IVectorEntry Window => this.Scrapper.GetVector(this.KeyPrefix + ".window");
        int Animation => this.Scrapper.GetInt(this.KeyPrefix + ".anim");

        /// <summary>
        /// Describes how long to display current image.
        /// </summary>
        ITimeEntry Time => Scrapper.GetTime(this.KeyPrefix + ".time");
    }
}