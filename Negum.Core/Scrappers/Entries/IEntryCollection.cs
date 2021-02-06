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
    public interface IEntryCollection<out TEntry> : IScrapperEntry<IEntryCollection<TEntry>>, IEnumerable<TEntry>
    {
        // TODO: Set values
    }
}