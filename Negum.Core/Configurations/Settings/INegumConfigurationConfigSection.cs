namespace Negum.Core.Configurations.Settings
{
    /// <summary>
    /// Config section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationConfigSection : INegumConfigurationSection
    {
        public const string GameSpeedKey = "GameSpeed";
        public const string GameWidthKey = "GameWidth";
        public const string GameHeightKey = "GameHeight";
        public const string LanguageKey = "Language";
        public const string DrawShadowsKey = "DrawShadows";
        public const string AfterImageMaxKey = "AfterImageMax";
        public const string LayeredSpriteMaxKey = "LayeredSpriteMax";
        public const string SpriteDecompressionBufferSizeKey = "SpriteDecompressionBufferSize";
        public const string ExplodMaxKey = "ExplodMax";
        public const string SysExplodMaxKey = "SysExplodMax";
        public const string HelperMaxKey = "HelperMax";
        public const string PlayerProjectileMaxKey = "PlayerProjectileMax";
        public const string FirstRunKey = "FirstRun";

        /// <summary>
        /// Set the game speed here. The default is 60 frames per second.
        /// The larger the number, the faster it goes.
        /// Don't use a value less than 10.
        /// </summary>
        int GameSpeed
        {
            get => this.GetOrDefault(GameSpeedKey, 60);
            set => this.SetNewValue(GameSpeedKey, value);
        }

        /// <summary>
        /// Game native width.
        /// </summary>
        int GameWidth
        {
            get => this.GetOrDefault(GameWidthKey, 1280);
            set => this.SetNewValue(GameWidthKey, value);
        }

        /// <summary>
        /// Game native height.
        /// </summary>
        int GameHeight
        {
            get => this.GetOrDefault(GameHeightKey, 720);
            set => this.SetNewValue(GameHeightKey, value);
        }

        /// <summary>
        /// Preferred language (ISO 639-1), e.g. en, es, ja, etc.
        /// See http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
        /// Leave blank to automatically detect the system language.
        /// </summary>
        string Language
        {
            get => this.GetOrDefault(LanguageKey, "en");
            set => this.SetNewValue(LanguageKey, value);
        }

        /// <summary>
        /// Set to true to draw shadows (default).
        /// Set to false if you have a slow machine, and want to improve speed by not drawing shadows.
        /// </summary>
        bool DrawShadows
        {
            get => this.GetOrDefault(DrawShadowsKey, true);
            set => this.SetNewValue(DrawShadowsKey, value);
        }

        /// <summary>
        /// Number of simultaneous afterimage effects allowed.
        /// Set to a lower number to save memory (minimum 1).
        /// </summary>
        int AfterImageMax
        {
            get => this.GetOrDefault(AfterImageMaxKey, 16);
            set => this.SetNewValue(AfterImageMaxKey, value);
        }

        /// <summary>
        /// Maximum number of layered sprites that can be drawn.
        /// Set to a lower number to save memory (minimum 32).
        /// </summary>
        int LayeredSpriteMax
        {
            get => this.GetOrDefault(LayeredSpriteMaxKey, 256);
            set => this.SetNewValue(LayeredSpriteMaxKey, value);
        }

        /// <summary>
        /// Size of sprite decompression buffer in KB.
        /// Increasing this number may help if you experience slow performance when there are many sprites and/or large
        /// sprites shown over a short period of time.
        /// Minimum 256 for acceptable performance.
        /// If you set this too large you may also experience performance degredation.
        /// </summary>
        int SpriteDecompressionBufferSize
        {
            get => this.GetOrDefault(SpriteDecompressionBufferSizeKey, 16384);
            set => this.SetNewValue(SpriteDecompressionBufferSizeKey, value);
        }

        /// <summary>
        /// Maximum number of explods allowed in total.
        /// Note that hitsparks also count as explods.
        /// Set to a lower number to save memory (minimum 8).
        /// </summary>
        int ExplodMax
        {
            get => this.GetOrDefault(ExplodMaxKey, 256);
            set => this.SetNewValue(ExplodMaxKey, value);
        }

        /// <summary>
        /// Maximum number of system explods allowed.
        /// Set to a lower number to save memory (minimum 8).
        /// </summary>
        int SysExplodMax
        {
            get => this.GetOrDefault(SysExplodMaxKey, 128);
            set => this.SetNewValue(SysExplodMaxKey, value);
        }

        /// <summary>
        /// Maximum number of helpers allowed in total.
        /// Set to a lower number to save memory (minimum 4, maximum 56).
        /// </summary>
        int HelperMax
        {
            get => this.GetOrDefault(HelperMaxKey, 56);
            set => this.SetNewValue(HelperMaxKey, value);
        }

        /// <summary>
        /// Maximum number of projectiles allowed per player.
        /// Set to a lower number to save memory (minimum 5).
        /// </summary>
        int PlayerProjectileMax
        {
            get => this.GetOrDefault(PlayerProjectileMaxKey, 32);
            set => this.SetNewValue(PlayerProjectileMaxKey, value);
        }

        /// <summary>
        /// This is true the first time you run engine.
        /// </summary>
        bool FirstRun
        {
            get => this.GetOrDefault(FirstRunKey, true);
            set => this.SetNewValue(FirstRunKey, value);
        }
    }
}