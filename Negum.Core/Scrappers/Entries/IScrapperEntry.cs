namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents an entry scrapped from configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IScrapperEntry<out TEntry>
        where TEntry : IScrapperEntry<TEntry>
    {
        /// <summary>
        /// Scrapper used by the current entry.
        /// </summary>
        IConfigurationSectionScrapper Scrapper { get; }

        /// <summary>
        /// Key prefix of the current entry.
        /// </summary>
        string KeyPrefix { get; }

        /// <summary>
        /// Initializes current entry with a value.
        /// </summary>
        /// <param name="scrapper">Scrapper used to get the entry.</param>
        /// <param name="keyPrefix">Prefix for the entry details.</param>
        /// <returns>Current entry with assigned value.</returns>
        TEntry Setup(IConfigurationSectionScrapper scrapper, string keyPrefix);
    }
}