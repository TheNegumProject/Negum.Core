using Negum.Core.Configurations;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent an Audio.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IAudioEntry
    {
        /// <summary>
        /// Initializes current entry with a value.
        /// </summary>
        /// <param name="scrapper">Scrapper used to get this Audio.</param>
        /// <param name="section">Section which contains details for Audio.</param>
        /// <param name="keyPrefix">Prefix for the Audio details.</param>
        /// <returns>Current entry with assigned value.</returns>
        IAudioEntry From(IConfigurationScrapper scrapper, IConfigurationSection section, string keyPrefix);

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