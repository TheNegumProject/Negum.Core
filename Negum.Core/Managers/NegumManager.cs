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
        protected TConfig Config { get; }
        
        public NegumManager(TConfig config)
        {
            this.Config = config;
        }
        
        public TManagerSection GetSection<TManagerSection>(string sectionName)
            where TManagerSection : INegumManagerSection
        {
            var section = this.Config[sectionName];
            var managerSection = this.GetNewManagerSection<TManagerSection>(sectionName, section);
            return managerSection;
        }

        protected abstract TManagerSection GetNewManagerSection<TManagerSection>(string sectionName, TSection configSection)
            where TManagerSection : INegumManagerSection;
    }
}