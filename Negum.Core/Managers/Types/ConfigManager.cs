using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which provides helper methods for INegumConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class ConfigManager : Manager, IConfigManager
    {
        protected override IManagerSection GetNewManagerSection(string sectionName,
            IConfigurationSection configSection) =>
            new ConfigManagerSection(sectionName, configSection);
    }

    public class ConfigManagerSection :
        ManagerSection,
        IConfigOptions,
        IConfigRules,
        IConfigConfig,
        IConfigDebug,
        IConfigVideo,
        IConfigSound,
        IConfigMisc,
        IConfigArcade,
        IConfigInput,
        IConfigKeys
    {
        public ConfigManagerSection(string name, IConfigurationSection section) :
            base(name, section)
        {
        }
    }
}