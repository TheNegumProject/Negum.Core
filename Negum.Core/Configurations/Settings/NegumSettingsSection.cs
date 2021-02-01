namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumSettingsSection :
        NegumConfigurationSection,
        INegumConfigurationOptionsSection,
        INegumConfigurationRulesSection,
        INegumConfigurationConfigSection,
        INegumConfigurationDebugSection,
        INegumConfigurationVideoSection,
        INegumConfigurationSoundSection,
        INegumConfigurationMiscSection,
        INegumConfigurationArcadeSection,
        INegumConfigurationInputSection,
        INegumConfigurationPlayerKeysSection
    {
    }
}