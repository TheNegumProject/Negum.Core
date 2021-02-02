namespace Negum.Core.Configurations.Systems
{
    /// <summary>
    /// Files section.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationFilesSection : INegumConfigurationSection
    {
        public const string SpriteKey = "spr";
        public const string SoundKey = "snd";
        public const string LogoStoryboardDefinitionKey = "logo.storyboard";
        public const string IntroStoryboardDefinitionKey = "intro.storyboard";
        public const string SelectionKey = "select";
        public const string FightKey = "fight";
        public const string Font1Key = "font1";
        public const string Font2Key = "font2";
        public const string Font3Key = "font3";

        /// <summary>
        /// Filename of sprite data.
        /// </summary>
        string Sprite
        {
            get => this.GetOrDefault(SpriteKey, "system.sff");
            set => this.SetNewValue(SpriteKey, value);
        }

        /// <summary>
        /// Filename of sound data.
        /// </summary>
        string Sound
        {
            get => this.GetOrDefault(SoundKey, "system.snd");
            set => this.SetNewValue(SoundKey, value);
        }

        /// <summary>
        /// Logo storyboard definition (optional).
        /// </summary>
        string LogoStoryboardDefinition
        {
            get => this.GetOrDefault(LogoStoryboardDefinitionKey, "");
            set => this.SetNewValue(LogoStoryboardDefinitionKey, value);
        }

        /// <summary>
        /// Intro storyboard definition (optional).
        /// </summary>
        string IntroStoryboardDefinition
        {
            get => this.GetOrDefault(IntroStoryboardDefinitionKey, "");
            set => this.SetNewValue(IntroStoryboardDefinitionKey, value);
        }

        /// <summary>
        /// Character and stage selection list.
        /// </summary>
        string Selection
        {
            get => this.GetOrDefault(SelectionKey, "select.def");
            set => this.SetNewValue(SelectionKey, value);
        }

        /// <summary>
        /// Fight definition filename.
        /// </summary>
        string Fight
        {
            get => this.GetOrDefault(FightKey, "fight.def");
            set => this.SetNewValue(FightKey, value);
        }

        /// <summary>
        /// System fonts.
        /// </summary>
        string Font1
        {
            get => this.GetOrDefault(Font1Key, "f-4x6.def");
            set => this.SetNewValue(Font1Key, value);
        }

        /// <summary>
        /// System fonts.
        /// </summary>
        string Font2
        {
            get => this.GetOrDefault(Font2Key, "f-6x9.def");
            set => this.SetNewValue(Font2Key, value);
        }

        /// <summary>
        /// System fonts.
        /// </summary>
        string Font3
        {
            get => this.GetOrDefault(Font3Key, "jg.fnt");
            set => this.SetNewValue(Font3Key, value);
        }
    }
}