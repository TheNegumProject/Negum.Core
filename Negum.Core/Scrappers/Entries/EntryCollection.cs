using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Negum.Core.Containers;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class EntryCollection<TEntry> : ScrappedEntry<IEntryCollection<TEntry>>, IEntryCollection<TEntry>
        where TEntry : IScrapperEntry<TEntry>
    {
        private IEnumerable<TEntry> Entries { get; set; }

        public IEnumerator<TEntry> GetEnumerator() => this.Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public override IEntryCollection<TEntry> Setup(IConfigurationSectionScrapper scrapper, string keyPrefix)
        {
            base.Setup(scrapper, keyPrefix);

            this.Entries = this.Scrapper
                .Where(entry => entry.Key.StartsWith(keyPrefix))
                .Select(entry => NegumContainer.Resolve<TEntry>().Setup(this.Scrapper, entry.Key))
                .ToList();

            return this;
        }
        
        public virtual IEntryCollection<TEntry> Setup(IConfigurationSectionScrapper scrapper, IEnumerable<string> keys)
        {
            var keysList = keys?.ToList() ?? new List<string>();
            
            base.Setup(scrapper, keysList.ElementAt(0));
            
            this.Entries = keysList
                .Select(key => NegumContainer.Resolve<TEntry>().Setup(this.Scrapper, key))
                .ToList();

            return this;
        }
    }
}