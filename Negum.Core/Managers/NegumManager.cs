using System.Collections.Generic;
using Negum.Core.Configurations;

namespace Negum.Core.Managers
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class NegumManager<TConfig, TSection, TEntry> : INegumManager
        where TConfig : INegumConfiguration<TSection, TEntry>
        where TSection : INegumConfigurationSection<TEntry>
        where TEntry : INegumConfigurationSectionEntry
    {
        /// <summary>
        /// Contains sections already used.
        /// Mainly used to increase performance.
        /// </summary>
        private IDictionary<string, object> Sections { get; } = new Dictionary<string, object>();
        
        protected TConfig Config { get; }
        
        public NegumManager(TConfig config)
        {
            this.Config = config;
        }
        
        public TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : INegumManagerSection
        {
            var section = this.Config[sectionName];

            if (!this.Sections.ContainsKey(sectionName))
            {
                var managerSection = this.GetNewManagerSection(sectionName, section);
                this.Sections.Add(sectionName, managerSection);
            }
            
            return (TManagerSection) this.Sections[sectionName];
        }

        /// <summary>
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="configSection"></param>
        /// <returns>Returns related Manager's Section.</returns>
        protected abstract INegumManagerSection GetNewManagerSection(string sectionName, TSection configSection);
    }
}