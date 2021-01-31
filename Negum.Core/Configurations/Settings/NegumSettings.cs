namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class NegumSettings : INegumSettings
    {
        public INegumConfigurationOptionsSection Options { get; } =
            NegumContainer.Resolve<INegumConfigurationOptionsSection>();

        public INegumConfigurationRulesSection Rules { get; } =
            NegumContainer.Resolve<INegumConfigurationRulesSection>();

        public INegumConfigurationConfigSection Config { get; } =
            NegumContainer.Resolve<INegumConfigurationConfigSection>();

        public INegumConfigurationDebugSection Debug { get; } =
            NegumContainer.Resolve<INegumConfigurationDebugSection>();

        public INegumConfigurationVideoSection Video { get; } =
            NegumContainer.Resolve<INegumConfigurationVideoSection>();

        public INegumConfigurationSoundSection Sound { get; } =
            NegumContainer.Resolve<INegumConfigurationSoundSection>();

        public INegumConfigurationMiscSection Misc { get; } =
            NegumContainer.Resolve<INegumConfigurationMiscSection>();

        public INegumConfigurationArcadeSection Arcade { get; } =
            NegumContainer.Resolve<INegumConfigurationArcadeSection>();

        public INegumConfigurationInputSection Input { get; } =
            NegumContainer.Resolve<INegumConfigurationInputSection>();

        public INegumConfigurationPlayerKeysSection P1Keys { get; } =
            NegumContainer.Resolve<INegumConfigurationPlayerKeysSection>();

        public INegumConfigurationPlayerKeysSection P2Keys { get; } =
            NegumContainer.Resolve<INegumConfigurationPlayerKeysSection>();

        public INegumConfigurationPlayerKeysSection P1Joystick { get; } =
            NegumContainer.Resolve<INegumConfigurationPlayerKeysSection>();

        public INegumConfigurationPlayerKeysSection P2Joystick { get; } =
            NegumContainer.Resolve<INegumConfigurationPlayerKeysSection>();
    }
}