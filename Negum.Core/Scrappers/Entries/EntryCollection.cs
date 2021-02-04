using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class EntryCollection<TEntry> : ScrappedEntry<IEntryCollection<TEntry>>, IEntryCollection<TEntry>
    {
        private ICollection<TEntry> Entries { get; } = new List<TEntry>();

        public IEnumerator<TEntry> GetEnumerator() => this.Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}