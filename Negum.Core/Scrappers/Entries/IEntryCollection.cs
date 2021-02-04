using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a collection of objects taken from configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IEntryCollection<out TEntry> : IEnumerable<TEntry>
    {
        /// <summary>
        /// Initializes the collection from the specified
        /// </summary>
        /// <param name="section">Section from which to scrap the data.</param>
        /// <param name="keyPrefix">Prefix of key which will be used during scrapping.</param>
        /// <returns>Current collection with initialized data.</returns>
        IEntryCollection<TEntry> From(IConfigurationSection section, string keyPrefix);
    }
}