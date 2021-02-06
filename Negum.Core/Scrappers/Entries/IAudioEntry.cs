namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent an Audio.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IAudioEntry : IScrapperEntry<IAudioEntry>
    {
        /// <summary>
        /// Audio file.
        /// </summary>
        IFileEntry File => this.Scrapper.GetFile(this.KeyPrefix);

        /// <summary>
        /// Volume scaling factor in percent.
        /// 100 is default.
        /// </summary>
        int Volume => this.Scrapper.GetInt(this.KeyPrefix + ".volume");

        /// <summary>
        /// Set to true to allow looping.
        /// Set to false to prevent looping.
        /// </summary>
        bool Loop => this.Scrapper.GetBoolean(this.KeyPrefix + ".loop");

        int LoopStart => this.Scrapper.GetInt(this.KeyPrefix + ".loopstart");

        int LoopEnd => this.Scrapper.GetInt(this.KeyPrefix + ".loopend");
    }
}