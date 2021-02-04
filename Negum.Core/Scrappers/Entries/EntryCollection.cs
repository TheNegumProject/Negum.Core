using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class EntryCollection<TEntry> : List<TEntry>, IEntryCollection<TEntry>
    {
        private IConfigurationSection Section { get; set; }
        private string KeyPrefix { get; set; }
        
        public IEntryCollection<TEntry> From(IConfigurationSection section, string keyPrefix)
        {
            this.Section = section;
            this.KeyPrefix = keyPrefix;
            return this;
        }
    }
}