namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent a Fighting Player Win Types.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationWinEntry : IScrapperEntry<IFightConfigurationWinEntry>
    {
        /// <summary>
        /// Win by normal.
        /// </summary>
        IImageEntry Normal => Scrapper.GetImage(this.KeyPrefix + ".n");

        /// <summary>
        /// Win by special.
        /// </summary>
        IImageEntry Special => Scrapper.GetImage(this.KeyPrefix + ".s");

        /// <summary>
        /// Win by hyper (super).
        /// </summary>
        IImageEntry Hyper => Scrapper.GetImage(this.KeyPrefix + ".h");

        /// <summary>
        /// Win by normal throw.
        /// </summary>
        IImageEntry Throw => Scrapper.GetImage(this.KeyPrefix + ".throw");

        /// <summary>
        /// Win by cheese.
        /// </summary>
        IImageEntry Cheese => Scrapper.GetImage(this.KeyPrefix + ".c");

        /// <summary>
        /// Win by time over.
        /// </summary>
        IImageEntry TimeOver => Scrapper.GetImage(this.KeyPrefix + ".t");

        /// <summary>
        /// Win by suicide.
        /// </summary>
        IImageEntry Suicide => Scrapper.GetImage(this.KeyPrefix + ".suicide");

        /// <summary>
        /// Opponent beaten by his own teammate.
        /// </summary>
        IImageEntry Teammate => Scrapper.GetImage(this.KeyPrefix + ".n");

        /// <summary>
        /// Win by perfect.
        /// </summary>
        IImageEntry Perfect => Scrapper.GetImage(this.KeyPrefix + ".perfect");
    }
}