namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for INegumConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumConfigurationManager : ConfigurationManager, INegumConfigurationManager
    {
    }

    public class NegumConfigurationManagerSection :
        ConfigurationManagerSection,
        INegumConfigurationOptions,
        INegumConfigurationRules,
        INegumConfigurationConfig,
        INegumConfigurationDebug,
        INegumConfigurationVideo,
        INegumConfigurationSound,
        INegumConfigurationMisc,
        INegumConfigurationArcade,
        INegumConfigurationInput,
        INegumConfigurationKeys
    {
    }
}