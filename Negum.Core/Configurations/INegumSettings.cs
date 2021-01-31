using Negum.Core.Configurations.Settings;

namespace Negum.Core.Configurations
{
    /// <summary>
    /// Settings element.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumSettings : INegumConfigurationElement
    {
        /// <summary>
        /// Options section.
        /// </summary>
        INegumConfigurationOptionsSection Options { get; }

        /// <summary>
        /// Rules section.
        /// </summary>
        INegumConfigurationRulesSection Rules { get; }

        /// <summary>
        /// Config section.
        /// </summary>
        INegumConfigurationConfigSection Config { get; }

        /// <summary>
        /// Debug section.
        /// </summary>
        INegumConfigurationDebugSection Debug { get; }

        /// <summary>
        /// Video section.
        /// </summary>
        INegumConfigurationVideoSection Video { get; }

        /// <summary>
        /// Sound section.
        /// </summary>
        INegumConfigurationSoundSection Sound { get; }

        /// <summary>
        /// Misc section.
        /// </summary>
        INegumConfigurationMiscSection Misc { get; }

        /// <summary>
        /// Arcade section.
        /// </summary>
        INegumConfigurationArcadeSection Arcade { get; }

        /// <summary>
        /// Input section.
        /// </summary>
        INegumConfigurationInputSection Input { get; }

        /// <summary>
        /// P1 Keys section.
        /// </summary>
        INegumConfigurationPlayerKeysSection P1Keys { get; }

        /// <summary>
        /// P2 Keys section.
        /// </summary>
        INegumConfigurationPlayerKeysSection P2Keys { get; }

        /// <summary>
        /// P1 Joystick section.
        /// </summary>
        INegumConfigurationPlayerKeysSection P1Joystick { get; }

        /// <summary>
        /// P2 Joystick section.
        /// </summary>
        INegumConfigurationPlayerKeysSection P2Joystick { get; }
    }
}