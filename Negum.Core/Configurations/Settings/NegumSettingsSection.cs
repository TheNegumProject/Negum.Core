using System.Collections.Generic;

namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumSettingsSection :
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
        private IDictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public TValue GetOrDefault<TValue>(string key, TValue defaultValue)
        {
            if (!Values.ContainsKey(key))
            {
                this.SetNewValue(key, defaultValue);
            }

            return (TValue) Values[key];
        }

        public void SetNewValue<TValue>(string key, TValue newValue) =>
            Values[key] = newValue;
    }
}