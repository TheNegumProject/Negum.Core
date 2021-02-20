using System.Collections.Generic;
using Negum.Core.Configurations;
using Negum.Core.Containers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Root manager's section definition.
    /// Sections are what configurations are divided by.
    /// It represent single area of configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumManagerSection
    {
        /// <summary>
        /// Name of the current section.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// </summary>
        /// <param name="fieldKey"></param>
        /// <typeparam name="TValue"></typeparam>
        /// <returns>Value parsed to specified type</returns>
        TValue GetValue<TValue>(string fieldKey);
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class NegumManagerSection : INegumManagerSection
    {
        /// <summary>
        /// Already used fields in current section.
        /// </summary>
        private IDictionary<string, object> Fields { get; } = new Dictionary<string, object>();
        
        private IConfigurationSection Section { get; }
        
        public string Name { get; }

        public NegumManagerSection(string name, IConfigurationSection section)
        {
            this.Name = name;
            this.Section = section;
        }
        
        public TValue GetValue<TValue>(string fieldKey)
        {
            if (this.Fields.ContainsKey(fieldKey))
            {
                return (TValue) this.Fields[fieldKey];
            }
            
            var entry = NegumContainer.Resolve<INegumManagerSectionEntry<TValue>>();
            var sectionEntry = this.Section[fieldKey];
            entry.Initialize(this, fieldKey, sectionEntry);
            this.Fields.Add(fieldKey, entry);
            return entry.Get();
        }
    }
}