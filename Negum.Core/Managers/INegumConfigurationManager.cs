using Negum.Core.Containers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Negum core configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface INegumConfigurationManager : IConfigurationManager<INegumConfigurationManager>
    {
        INegumConfigurationOptions Options =>
            NegumContainer.Resolve<INegumConfigurationOptions>().Setup(this.Scrapper, "Options");

        INegumConfigurationRules Rules =>
            NegumContainer.Resolve<INegumConfigurationRules>().Setup(this.Scrapper, "Rules");

        INegumConfigurationConfig Config =>
            NegumContainer.Resolve<INegumConfigurationConfig>().Setup(this.Scrapper, "Config");

        INegumConfigurationDebug Debug =>
            NegumContainer.Resolve<INegumConfigurationDebug>().Setup(this.Scrapper, "Debug");

        INegumConfigurationVideo Video =>
            NegumContainer.Resolve<INegumConfigurationVideo>().Setup(this.Scrapper, "Video");

        INegumConfigurationSound Sound =>
            NegumContainer.Resolve<INegumConfigurationSound>().Setup(this.Scrapper, "Sound");

        INegumConfigurationMisc Misc => 
            NegumContainer.Resolve<INegumConfigurationMisc>().Setup(this.Scrapper, "Misc");

        INegumConfigurationArcade Arcade =>
            NegumContainer.Resolve<INegumConfigurationArcade>().Setup(this.Scrapper, "Arcade");

        INegumConfigurationInput Input =>
            NegumContainer.Resolve<INegumConfigurationInput>().Setup(this.Scrapper, "Input");

        INegumConfigurationKeys P1Keys =>
            NegumContainer.Resolve<INegumConfigurationKeys>().Setup(this.Scrapper, "P1 Keys");

        INegumConfigurationKeys P2Keys =>
            NegumContainer.Resolve<INegumConfigurationKeys>().Setup(this.Scrapper, "P2 Keys");

        INegumConfigurationKeys P1Joystick =>
            NegumContainer.Resolve<INegumConfigurationKeys>().Setup(this.Scrapper, "P1 Joystick");

        INegumConfigurationKeys P2Joystick =>
            NegumContainer.Resolve<INegumConfigurationKeys>().Setup(this.Scrapper, "P2 Joystick");
    }

    public interface INegumConfigurationOptions : IConfigurationManagerSection<INegumConfigurationOptions>
    {
        int Difficulty => Scrapper.GetInt(SectionName, "Difficulty");
        int Life => Scrapper.GetInt(SectionName, "Life");
        int Time => Scrapper.GetInt(SectionName, "Time");
        int GameSpeed => Scrapper.GetInt(SectionName, "GameSpeed");
        int Team1VS2Life => Scrapper.GetInt(SectionName, "Team.1VS2Life");
        bool TeamLoseOnKO => Scrapper.GetBoolean(SectionName, "Team.LoseOnKO");

        /// <summary>
        /// Set the motif to use.
        /// Motifs are themes that define the look and feel of engine.
        /// This is not accessible in options screen.
        /// 
        /// Note: If you install a motif that overwrites system files (not recommended)
        /// you may need to set the motif line to use data/system.def instead.
        /// motif = data/system.def  - Use this line if using a motif that overwrites system files.
        /// </summary>
        IFileEntry Motif => Scrapper.GetFile(SectionName, "motif");
    }

    public interface INegumConfigurationRules : IConfigurationManagerSection<INegumConfigurationRules>
    {
        /// <summary>
        /// This is the amount of power the attacker gets when an attack successfully hits the opponent.
        /// It's a multiplier of the damage done.
        /// For example, for a value of 3, a hit that does 10 damage will give 30 power.
        /// </summary>
        float DefaultAttackLifeToPowerMul =>
            Scrapper.GetFloat(SectionName, "Default.Attack.LifeToPowerMul");

        /// <summary>
        /// This is like the above, but it's for the person getting hit.
        /// These two multipliers can be overridden in the Hitdef controller in the
        /// CNS by using the "getpower" and "givepower" options.
        /// </summary>
        float DefaultGetHitLifeToPowerMul =>
            Scrapper.GetFloat(SectionName, "Default.GetHit.LifeToPowerMul");

        /// <summary>
        /// This controls how much damage a super does when you combo into it.
        /// It's actually a multiplier for the defensive power of the opponent.
        /// A large number means the opponent takes less damage.
        /// Leave it at 1 if you want supers to do the normal amount of damage when comboed into.
        /// 
        /// Note 1: this increase in defence stays effective until the opponent gets up from the ground.
        /// Note 2: the program knows you've done a super when the "superpause" controller is executed.
        ///         That's the instance when this change becomes effective.
        /// </summary>
        float SuperTargetDefenceMul => Scrapper.GetFloat(SectionName, "Super.TargetDefenceMul");
    }

    public interface INegumConfigurationConfig : IConfigurationManagerSection<INegumConfigurationConfig>
    {
        /// <summary>
        /// Set the game speed here. The default is 60 frames per second.
        /// The larger the number, the faster it goes.
        /// Don't use a value less than 10.
        /// </summary>
        int GameSpeed => Scrapper.GetInt(SectionName, "GameSpeed");

        /// <summary>
        /// Game native width.
        /// </summary>
        int GameWidth => Scrapper.GetInt(SectionName, "GameWidth");

        /// <summary>
        /// Game native height.
        /// </summary>
        int GameHeight => Scrapper.GetInt(SectionName, "GameHeight");

        /// <summary>
        /// Preferred language (ISO 639-1), e.g. en, es, ja, etc.
        /// See http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
        /// Leave blank to automatically detect the system language.
        /// </summary>
        string Language => Scrapper.GetString(SectionName, "Language");

        /// <summary>
        /// Set to true to draw shadows (default).
        /// Set to false if you have a slow machine, and want to improve speed by not drawing shadows.
        /// </summary>
        bool DrawShadows => Scrapper.GetBoolean(SectionName, "DrawShadows");

        /// <summary>
        /// Number of simultaneous afterimage effects allowed.
        /// Set to a lower number to save memory (minimum 1).
        /// </summary>
        int AfterImageMax => Scrapper.GetInt(SectionName, "AfterImageMax");

        /// <summary>
        /// Maximum number of layered sprites that can be drawn.
        /// Set to a lower number to save memory (minimum 32).
        /// </summary>
        int LayeredSpriteMax => Scrapper.GetInt(SectionName, "LayeredSpriteMax");

        /// <summary>
        /// Size of sprite decompression buffer in KB.
        /// Increasing this number may help if you experience slow performance when there are many sprites and/or large
        /// sprites shown over a short period of time.
        /// Minimum 256 for acceptable performance.
        /// If you set this too large you may also experience performance degredation.
        /// </summary>
        int SpriteDecompressionBufferSize =>
            Scrapper.GetInt(SectionName, "SpriteDecompressionBufferSize");

        /// <summary>
        /// Maximum number of explods allowed in total.
        /// Note that hitsparks also count as explods.
        /// Set to a lower number to save memory (minimum 8).
        /// </summary>
        int ExplodMax => Scrapper.GetInt(SectionName, "ExplodMax");

        /// <summary>
        /// Maximum number of system explods allowed.
        /// Set to a lower number to save memory (minimum 8).
        /// </summary>
        int SysExplodMax => Scrapper.GetInt(SectionName, "SysExplodMax");

        /// <summary>
        /// Maximum number of helpers allowed in total.
        /// Set to a lower number to save memory (minimum 4, maximum 56).
        /// </summary>
        int HelperMax => Scrapper.GetInt(SectionName, "HelperMax");

        /// <summary>
        /// Maximum number of projectiles allowed per player.
        /// Set to a lower number to save memory (minimum 5).
        /// </summary>
        int PlayerProjectileMax => Scrapper.GetInt(SectionName, "PlayerProjectileMax");

        /// <summary>
        /// This is true the first time you run engine.
        /// </summary>
        bool FirstRun => Scrapper.GetBoolean(SectionName, "FirstRun");
    }

    public interface INegumConfigurationDebug : IConfigurationManagerSection<INegumConfigurationDebug>
    {
        /// <summary>
        /// Set to false to disable starting in debug mode by default.
        /// </summary>
        bool IsDebug => Scrapper.GetBoolean(SectionName, "Debug");

        /// <summary>
        /// Set to false to disallow switching to debug mode by pressing Ctrl-D.
        /// If Debug = true, this will be ignored.
        /// </summary>
        bool AllowDebugMode => Scrapper.GetBoolean(SectionName, "AllowDebugMode");

        /// <summary>
        /// Set to true to allow debug keys at all times.
        /// Otherwise debug keys allowed only in debug mode.
        /// </summary>
        bool AllowDebugKeys => Scrapper.GetBoolean(SectionName, "AllowDebugKeys");

        /// <summary>
        /// Set to true to run at maximum speed by default.
        /// </summary>
        bool SpeedUp => Scrapper.GetBoolean(SectionName, "Speedup");

        /// <summary>
        /// Default starting stage for quick versus.
        /// </summary>
        IFileEntry StartStage => Scrapper.GetFile(SectionName, "StartStage");

        /// <summary>
        /// Set to true to hide the development build banner that shows on startup.
        /// </summary>
        bool HideDevelopmentBuildBanner =>
            Scrapper.GetBoolean(SectionName, "HideDevelopmentBuildBanner");
    }

    public interface INegumConfigurationVideo : IConfigurationManagerSection<INegumConfigurationVideo>
    {
        /// <summary>
        /// This is the color depth at which to run engine.
        /// </summary>
        int Depth => Scrapper.GetInt(SectionName, "Depth");

        /// <summary>
        /// Set to true to start in fullscreen mode, 0 for windowed.
        /// This enables exclusive fullscreen, which may give better performance than windowed mode.
        /// </summary>
        bool FullScreen => Scrapper.GetBoolean(SectionName, "FullScreen");

        /// <summary>
        /// Set to true to make the window resizable when in windowed mode.
        /// </summary>
        bool Resizable => Scrapper.GetBoolean(SectionName, "Resizable");

        /// <summary>
        /// Set to false to stretch the video to fit the whole window.
        /// Set to true to keep a fixed aspect ratio.
        /// </summary>
        bool KeepAspect => Scrapper.GetBoolean(SectionName, "KeepAspect");

        /// <summary>
        /// Stage fit mode.
        /// 0 - stage drawn to width of screen (may crop stages with tall aspect)
        /// 1 - stage shrunk to fit into screen
        /// </summary>
        int StageFit => Scrapper.GetInt(SectionName, "StageFit");

        /// <summary>
        /// System fit mode.
        /// 0 - system drawn to width of screen (may crop motifs with tall aspect)
        /// 1 - system shrunk to fit into screen
        /// </summary>
        int SystemFit => Scrapper.GetInt(SectionName, "SystemFit");
    }

    public interface INegumConfigurationSound : IConfigurationManagerSection<INegumConfigurationSound>
    {
        /// <summary>
        /// Set the following to true to enable sound effects and music.
        /// Set to false to disable.
        /// </summary>
        bool IsSound => Scrapper.GetBoolean(SectionName, "Sound");

        /// <summary>
        /// Set the sample rate of the game audio.
        /// Higher rates produce better quality but require more system resources.
        /// Lower the rate if you are having problems with sound performance.
        /// Recommended values are 22050, 44100, or 48000.
        /// </summary>
        int SampleRate => Scrapper.GetInt(SectionName, "SampleRate");

        /// <summary>
        /// This is the width of the sound panning field.
        /// If you Increase this number, the stereo effects will sound closer to the middle.
        /// Set to a smaller number to get more stereo separation on sound effects.
        /// Only valid if StereoEffects is set to true.
        /// </summary>
        int PanningWidth => Scrapper.GetInt(SectionName, "PanningWidth");

        /// <summary>
        /// Number of voice channels to use.
        /// </summary>
        int WavChannels => Scrapper.GetInt(SectionName, "WavChannels");

        /// <summary>
        /// This is the master volume for all sounds, in percent (0-100).
        /// </summary>
        int MasterVolume => Scrapper.GetInt(SectionName, "MasterVolume");

        /// <summary>
        /// This is the volume for sound effects and voices, in percent (0-100).
        /// </summary>
        int WavVolume => Scrapper.GetInt(SectionName, "WavVolume");

        /// <summary>
        /// This is the master volume for music, (0-100).
        /// </summary>
        int BgmVolume => Scrapper.GetInt(SectionName, "BGMVolume");
    }

    public interface INegumConfigurationMisc : IConfigurationManagerSection<INegumConfigurationMisc>
    {
        /// <summary>
        /// Number of extra players to cache in memory.
        /// Set to a lower number to decrease memory usage, at cost of more frequent loading.
        /// </summary>
        int PlayerCache => Scrapper.GetInt(SectionName, "PlayerCache");

        /// <summary>
        /// Set to true to pause the game when the window is in the background.
        /// </summary>
        bool PauseOnDefocus => Scrapper.GetBoolean(SectionName, "PauseOnDefocus");

        /// <summary>
        /// Configures the handling of sound effects and voices when the window is in the background (i.e., defocused).
        /// Set to "Mute" to mute sound effects, or "Play" to let sound effects play.
        /// </summary>
        string SfxBackgroundMode => Scrapper.GetString(SectionName, "SFXBackgroundMode");

        /// <summary>
        /// Configures the handling of BGM when the window is in the background.
        /// Set to "Pause" to pause the music, "Mute" to mute the music but leave it running at normal speed, or "Play" to continue playing as usual.
        /// If you are running in fullscreen mode, then this setting is always set to "Pause".
        /// </summary>
        string BgmBackgroundMode => Scrapper.GetString(SectionName, "BGMBackgroundMode");
    }

    public interface INegumConfigurationArcade : IConfigurationManagerSection<INegumConfigurationArcade>
    {
        /// <summary>
        /// Set to false for computer to choose color 1 if possible.
        /// Set to true for computer to randomly choose a color.
        /// </summary>
        bool AiRandomColor => Scrapper.GetBoolean(SectionName, "AI.RandomColor");

        /// <summary>
        /// This option allows the AI to input commands without having to actually press any keys (in effect, cheating).
        /// Set to true to enable, false to disable.
        /// </summary>
        bool AiCheat => Scrapper.GetBoolean(SectionName, "AI.Cheat");

        /// <summary>
        /// Arcade Mode AI ramping.
        /// For both parameters below,
        /// the first number corresponds to the number of matches won,
        /// and the second number to the AI difficulty offset.
        /// The actual difficulty is the sum of the AI difficulty level
        /// (set in the options menu) and the value of the offset at a particular match.
        ///     AIramp.start = start_match, start_diff
        ///     AIramp.end   = end_match, end_diff
        /// The difficulty offset function is a constant value of start_diff from
        /// the first match until start_match matches have been won. From then the
        /// offset value increases linearly from start_diff to end_diff. After
        /// end_diff matches have been won, the offset value is end_diff.
        ///  e_d            /----------
        ///               /
        ///  s_d _______/
        ///     ^      ^     ^        ^
        ///   1st_m   s_m   e_m     last_m
        /// For example, if you have:
        ///     AIramp.start = 2,0
        ///     AIramp.end   = 4,2
        /// For 6 matches at level 4, the difficulty will be (by match):
        ///     4,4,4,5,6,6
        /// </summary>
        IPositionEntry ArcadeAiRampStart => Scrapper.GetPosition(SectionName, "arcade.AIramp.start");

        IPositionEntry ArcadeAiRampEnd => Scrapper.GetPosition(SectionName, "arcade.AIramp.end");


        /// <summary>
        /// Team Mode AI ramping.
        /// </summary>
        IPositionEntry TeamAiRampStart => Scrapper.GetPosition(SectionName, "team.AIramp.start");

        IPositionEntry TeamAiRampEnd => Scrapper.GetPosition(SectionName, "team.AIramp.end");

        /// <summary>
        /// Survival Mode AI ramping.
        /// </summary>
        IPositionEntry SurvivalAiRampStart => Scrapper.GetPosition(SectionName, "survival.AIramp.start");

        IPositionEntry SurvivalAiRampEnd => Scrapper.GetPosition(SectionName, "survival.AIramp.end");
    }

    public interface INegumConfigurationInput : IConfigurationManagerSection<INegumConfigurationInput>
    {
        bool P1UseKeyboard => Scrapper.GetBoolean(SectionName, "P1.UseKeyboard");
        bool P2UseKeyboard => Scrapper.GetBoolean(SectionName, "P2.UseKeyboard");
        bool P1UseJoystick => Scrapper.GetBoolean(SectionName, "P1.Joystick.type");
        bool P2UseJoystick => Scrapper.GetBoolean(SectionName, "P2.Joystick.type");

        /// <summary>
        /// false - Only pause key will unpause
        /// true - Any key unpauses if there is no menu
        /// </summary>
        bool AnyKeyUnpauses => Scrapper.GetBoolean(SectionName, "AnyKeyUnpauses");
    }

    public interface INegumConfigurationKeys : IConfigurationManagerSection<INegumConfigurationKeys>
    {
        IKeysEntry Keys => Scrapper.GetKeys(SectionName, string.Empty);
    }
}