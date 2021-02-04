namespace Negum.Core.Scrappers
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
        /// <param name="value">A valid path to the File.</param>
        /// <returns>Current entry with assigned value.</returns>
        IAudioEntry From(string value);
    }
}