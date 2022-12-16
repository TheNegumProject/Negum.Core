using Negum.Core.Configurations;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which provides helper methods for INegumConfiguration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class ConfigurationManager : Manager, IConfigurationManager
{
    protected override IManagerSection GetNewManagerSection(string sectionName,
        IConfigurationSection configSection) =>
        new ConfigurationManagerSection(sectionName, configSection);
}

public class ConfigurationManagerSection :
    ManagerSection,
    IConfigurationOptions,
    IConfigurationRules,
    IConfigurationConfig,
    IConfigurationDebug,
    IConfigurationVideo,
    IConfigurationSound,
    IConfigurationMisc,
    IConfigurationArcade,
    IConfigurationInput,
    IConfigurationKeys
{
    public ConfigurationManagerSection(string name, IConfigurationSection section) :
        base(name, section)
    {
    }
}