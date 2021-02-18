using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class NegumConfigurationSection<TEntry> : INegumConfigurationSection<TEntry>
        where TEntry : INegumConfigurationSectionEntry
    {
        public TEntry this[string key] => this.GetEntry(key);

        public string Name { get; internal set; }
        public IEnumerable<string> Attributes { get; internal set; } = new List<string>();

        public ICollection<TEntry> Entries { get; internal set; } = new List<TEntry>();

        public IEnumerator<TEntry> GetEnumerator() =>
            this.Entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
        
        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Valid entry by some key.</returns>
        protected abstract TEntry GetEntry(string key);
    }
}