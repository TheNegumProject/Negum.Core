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
    public abstract class NegumConfiguration<TSection, TEntry> : INegumConfiguration<TSection, TEntry>
        where TSection : INegumConfigurationSection<TEntry>
        where TEntry : INegumConfigurationSectionEntry
    {
        public TSection this[string sectionName] => this.Sections[sectionName];

        public IDictionary<string, TSection> Sections { get; } = new Dictionary<string, TSection>();

        public IEnumerator<TSection> GetEnumerator() =>
            this.Sections.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}