using System.Collections.Generic;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a collection of objects taken from configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IEntryCollection<out TEntry> : IScrapperEntry, IEnumerable<TEntry>
    {
        /// <summary>
        /// Setups current collection with values correspondent to the given keys.
        /// </summary>
        /// <param name="scrapper"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        IEntryCollection<TEntry> Setup(IConfigurationSectionScrapper scrapper, IEnumerable<string> keys);
    }
}