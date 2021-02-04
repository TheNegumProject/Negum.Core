namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent a File.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFileEntry
    {
        /// <summary>
        /// Initializes current entry with a value.
        /// </summary>
        /// <param name="value">A valid path to the File.</param>
        /// <returns>Current entry with assigned value.</returns>
        IFileEntry From(string value);
    }
}