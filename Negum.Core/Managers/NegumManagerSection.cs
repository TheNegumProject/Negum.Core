using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class NegumManagerSection<TSection, TEntry> : INegumManagerSection
        where TSection : INegumConfigurationSection<TEntry>
        where TEntry : INegumConfigurationSectionEntry
    {
        private TSection Section { get; }
        
        public string Name { get; }

        public NegumManagerSection(string name, TSection section)
        {
            this.Name = name;
            this.Section = section;
        }
        
        public TValue GetValue<TValue>(string fieldKey)
        {
            var entry = NegumContainer.Resolve<INegumManagerSectionEntry<TValue>>();
            var sectionEntry = this.Section[fieldKey];
            entry.Initialize(this, fieldKey, sectionEntry.Content);
            return entry.Get();
        }
    }
}