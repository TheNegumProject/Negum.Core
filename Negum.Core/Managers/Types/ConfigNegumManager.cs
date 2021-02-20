namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which provides helper methods for INegumConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigNegumManager :
        NegumManager<ICfgConfiguration, ICfgConfigurationSection, ICfgConfigurationSectionEntry>,
        IConfigNegumManager
    {
        public ConfigNegumManager(ICfgConfiguration config) : base(config)
        {
        }

        protected override INegumManagerSection GetNewManagerSection(string sectionName,
            ICfgConfigurationSection configSection) =>
            new ConfigNegumManagerSection(sectionName, configSection);
    }

    public class ConfigNegumManagerSection :
        NegumManagerSection,
        IConfigNegumOptions,
        IConfigNegumRules,
        IConfigNegumConfig,
        IConfigNegumDebug,
        IConfigNegumVideo,
        IConfigNegumSound,
        IConfigNegumMisc,
        IConfigNegumArcade,
        IConfigNegumInput,
        IConfigNegumKeys
    {
        public ConfigNegumManagerSection(string name, ICfgConfigurationSection section) : base(name, section)
        {
        }
    }
}