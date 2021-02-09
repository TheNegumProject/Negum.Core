namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Screen element.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IScreenElementEntry : IScrapperEntry<IScreenElementEntry>
    {
        /// <summary>
        /// Time to show current element.
        /// </summary>
        ITimeEntry Time => Scrapper.GetTime(this.KeyPrefix + ".time");

        /// <summary>
        /// Image to be displayed.
        /// </summary>
        IImageEntry Image => Scrapper.GetImage(this.KeyPrefix);

        /// <summary>
        /// Sound to play.
        /// </summary>
        IVectorEntry Sound => Scrapper.GetVector(this.KeyPrefix + ".snd");

        /// <summary>
        /// Time to play sound.
        /// </summary>
        ITimeEntry SoundTime => Scrapper.GetTime(this.KeyPrefix + ".sndtime");

        /// <summary>
        /// Text to display.
        /// </summary>
        ITextEntry Text => Scrapper.GetText(this.KeyPrefix);
    }
}