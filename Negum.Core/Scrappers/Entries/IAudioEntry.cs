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
        IFileEntry File { get; }

        /// <summary>
        /// Volume scaling factor in percent.
        /// 100 is default.
        /// </summary>
        int Volume { get; }

        /// <summary>
        /// Set to true to allow looping.
        /// Set to false to prevent looping.
        /// </summary>
        bool Loop { get; }

        int LoopStart { get; }

        int LoopEnd { get; }
    }
}