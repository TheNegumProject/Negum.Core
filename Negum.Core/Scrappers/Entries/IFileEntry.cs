namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent a File.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFileEntry : IScrapperEntry
    {
        /// <summary>
        /// Path to the file. 
        /// </summary>
        string Path => Scrapper.GetString(this.KeyPrefix);
    }
}