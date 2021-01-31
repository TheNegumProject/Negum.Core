namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Debug section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationDebugSection : INegumConfigurationSection
    {
        public const string DebugKey = "Debug";
        public const string AllowDebugModeKey = "AllowDebugMode";
        public const string AllowDebugKeysKey = "AllowDebugKeys";
        public const string SpeedUpKey = "Speedup";
        public const string StartStageKey = "StartStage";
        public const string HideDevelopmentBuildBannerKey = "HideDevelopmentBuildBanner";

        /// <summary>
        /// Set to false to disable starting in debug mode by default.
        /// </summary>
        bool Debug
        {
            get => this.GetOrDefault(DebugKey, false);
            set => this.SetNewValue(DebugKey, value);
        }

        /// <summary>
        /// Set to false to disallow switching to debug mode by pressing Ctrl-D.
        /// If Debug = true, this will be ignored.
        /// </summary>
        bool AllowDebugMode
        {
            get => this.GetOrDefault(AllowDebugModeKey, true);
            set => this.SetNewValue(AllowDebugModeKey, value);
        }

        /// <summary>
        /// Set to true to allow debug keys at all times.
        /// Otherwise debug keys allowed only in debug mode.
        /// </summary>
        bool AllowDebugKeys
        {
            get => this.GetOrDefault(AllowDebugKeysKey, true);
            set => this.SetNewValue(AllowDebugKeysKey, value);
        }

        /// <summary>
        /// Set to true to run at maximum speed by default.
        /// </summary>
        bool SpeedUp
        {
            get => this.GetOrDefault(SpeedUpKey, false);
            set => this.SetNewValue(SpeedUpKey, value);
        }

        /// <summary>
        /// Default starting stage for quick versus.
        /// </summary>
        string StartStage
        {
            get => this.GetOrDefault(StartStageKey, "stages/default.def");
            set => this.SetNewValue(StartStageKey, value);
        }

        /// <summary>
        /// Set to true to hide the development build banner that shows on startup.
        /// </summary>
        bool HideDevelopmentBuildBanner
        {
            get => this.GetOrDefault(HideDevelopmentBuildBannerKey, false);
            set => this.SetNewValue(HideDevelopmentBuildBannerKey, value);
        }
    }
}