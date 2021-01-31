namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Misc section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationMiscSection : INegumConfigurationSection
    {
        public const string PlayerCacheKey = "PlayerCache";
        public const string PrecacheKey = "Precache";
        public const string BufferedReadKey = "BufferedRead";
        public const string UnloadSystemKey = "UnloadSystem";
        public const string PauseOnDefocusKey = "PauseOnDefocus";
        public const string SFXBackgroundModeKey = "SFXBackgroundMode";
        public const string BGMBackgroundModeKey = "BGMBackgroundMode";

        /// <summary>
        /// Number of extra players to cache in memory.
        /// Set to a lower number to decrease memory usage, at cost of more frequent loading.
        /// </summary>
        int PlayerCache
        {
            get => this.GetOrDefault(PlayerCacheKey, 2);
            set => this.SetNewValue(PlayerCacheKey, value);
        }

        /// <summary>
        /// Precaching attempts to start loading player data as early as possible,
        /// to reduce apparent loading times between matches.
        /// 
        /// To get the best performance, set PlayerCache to at least 1.
        /// The optimal number for PlayerCache is 4 when precaching is enabled.
        /// </summary>
        bool Precache
        {
            get => this.GetOrDefault(PrecacheKey, true);
            set => this.SetNewValue(PrecacheKey, value);
        }

        /// <summary>
        /// Set to true to enable large-buffer reads of sprite and sound data.
        /// Set to false to decrease memory usage, at cost of slower loading.
        /// </summary>
        bool BufferedRead
        {
            get => this.GetOrDefault(BufferedReadKey, true);
            set => this.SetNewValue(BufferedReadKey, value);
        }

        /// <summary>
        /// Set to true to free data from memory whenever possible.
        /// This decreases memory usage, in exchange for loading time before system screens.
        /// </summary>
        bool UnloadSystem
        {
            get => this.GetOrDefault(UnloadSystemKey, false);
            set => this.SetNewValue(UnloadSystemKey, value);
        }

        /// <summary>
        /// Set to true to pause the game when the window is in the background.
        /// </summary>
        bool PauseOnDefocus
        {
            get => this.GetOrDefault(PauseOnDefocusKey, false);
            set => this.SetNewValue(PauseOnDefocusKey, value);
        }

        /// <summary>
        /// Configures the handling of sound effects and voices when the window is in the background (i.e., defocused).
        /// Set to "Mute" to mute sound effects, or "Play" to let sound effects play.
        /// </summary>
        string SFXBackgroundMode
        {
            get => this.GetOrDefault(SFXBackgroundModeKey, "Play");
            set => this.SetNewValue(SFXBackgroundModeKey, value);
        }

        /// <summary>
        /// Configures the handling of BGM when the window is in the background.
        /// Set to "Pause" to pause the music, "Mute" to mute the music but leave it running at normal speed, or "Play" to continue playing as usual.
        /// If you are running in fullscreen mode, then this setting is always set to "Pause".
        /// </summary>
        string BGMBackgroundMode
        {
            get => this.GetOrDefault(BGMBackgroundModeKey, "Play");
            set => this.SetNewValue(BGMBackgroundModeKey, value);
        }
    }
}