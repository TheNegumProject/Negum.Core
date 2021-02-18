using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Negum core configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IConfigNegumManager : INegumManager
    {
        IConfigNegumOptions Options => this.GetSection<IConfigNegumOptions>("Options");
        IConfigNegumRules Rules => this.GetSection<IConfigNegumRules>("Rules");
        IConfigNegumConfig Config => this.GetSection<IConfigNegumConfig>("Config");
        IConfigNegumDebug Debug => this.GetSection<IConfigNegumDebug>("Debug");
        IConfigNegumVideo Video => this.GetSection<IConfigNegumVideo>("Video");
        IConfigNegumSound Sound => this.GetSection<IConfigNegumSound>("Sound");
        IConfigNegumMisc Misc => this.GetSection<IConfigNegumMisc>("Misc");
        IConfigNegumArcade Arcade => this.GetSection<IConfigNegumArcade>("Arcade");
        IConfigNegumInput Input => this.GetSection<IConfigNegumInput>("Input");
        IConfigNegumKeys P1Keys => this.GetSection<IConfigNegumKeys>("P1 Keys");
        IConfigNegumKeys P2Keys => this.GetSection<IConfigNegumKeys>("P2 Keys");
        IConfigNegumKeys P1Joystick => this.GetSection<IConfigNegumKeys>("P1 Joystick");
        IConfigNegumKeys P2Joystick => this.GetSection<IConfigNegumKeys>("P2 Joystick");
    }

    public interface IConfigNegumOptions : INegumManagerSection
    {
        int Difficulty => this.GetValue<int>("Difficulty");
        int Life => this.GetValue<int>("Life");
        ITimeEntry Time => this.GetValue<ITimeEntry>("Time");
        int GameSpeed => this.GetValue<int>("GameSpeed");
        int Team1VS2Life => this.GetValue<int>("Team.1VS2Life");
        bool TeamLoseOnKO => this.GetValue<bool>("Team.LoseOnKO");

        /// <summary>
        /// Set the motif to use.
        /// Motifs are themes that define the look and feel of engine.
        /// This is not accessible in options screen.
        /// 
        /// Note: If you install a motif that overwrites system files (not recommended)
        /// you may need to set the motif line to use data/system.def instead.
        /// motif = data/system.def  - Use this line if using a motif that overwrites system files.
        /// </summary>
        IFileEntry MotifFile => this.GetValue<IFileEntry>("motif");
    }

    public interface IConfigNegumRules : INegumManagerSection
    {
        /// <summary>
        /// This is the amount of power the attacker gets when an attack successfully hits the opponent.
        /// It's a multiplier of the damage done.
        /// For example, for a value of 3, a hit that does 10 damage will give 30 power.
        /// </summary>
        float DefaultAttackLifeToPowerMul => this.GetValue<float>("Default.Attack.LifeToPowerMul");

        /// <summary>
        /// This is like the above, but it's for the person getting hit.
        /// These two multipliers can be overridden in the Hitdef controller in the
        /// CNS by using the "getpower" and "givepower" options.
        /// </summary>
        float DefaultGetHitLifeToPowerMul => this.GetValue<float>("Default.GetHit.LifeToPowerMul");

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
        float SuperTargetDefenceMul => this.GetValue<float>("Super.TargetDefenceMul");
    }

    public interface IConfigNegumConfig : INegumManagerSection
    {
        /// <summary>
        /// Set the game speed here. The default is 60 frames per second.
        /// The larger the number, the faster it goes.
        /// Don't use a value less than 10.
        /// </summary>
        int GameSpeed => this.GetValue<int>("GameSpeed");

        /// <summary>
        /// Game native width.
        /// </summary>
        int GameWidth => this.GetValue<int>("GameWidth");

        /// <summary>
        /// Game native height.
        /// </summary>
        int GameHeight => this.GetValue<int>("GameHeight");

        /// <summary>
        /// Preferred language (ISO 639-1), e.g. en, es, ja, etc.
        /// See http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
        /// Leave blank to automatically detect the system language.
        /// </summary>
        string Language => this.GetValue<string>("Language");

        /// <summary>
        /// Set to true to draw shadows (default).
        /// Set to false if you have a slow machine, and want to improve speed by not drawing shadows.
        /// </summary>
        bool DrawShadows => this.GetValue<bool>("DrawShadows");

        /// <summary>
        /// Number of simultaneous afterimage effects allowed.
        /// Set to a lower number to save memory (minimum 1).
        /// </summary>
        int AfterImageMax => this.GetValue<int>("AfterImageMax");

        /// <summary>
        /// Maximum number of layered sprites that can be drawn.
        /// Set to a lower number to save memory (minimum 32).
        /// </summary>
        int LayeredSpriteMax => this.GetValue<int>("LayeredSpriteMax");

        /// <summary>
        /// Size of sprite decompression buffer in KB.
        /// Increasing this number may help if you experience slow performance when there are many sprites and/or large
        /// sprites shown over a short period of time.
        /// Minimum 256 for acceptable performance.
        /// If you set this too large you may also experience performance degredation.
        /// </summary>
        int SpriteDecompressionBufferSize => this.GetValue<int>("SpriteDecompressionBufferSize");

        /// <summary>
        /// Maximum number of explods allowed in total.
        /// Note that hitsparks also count as explods.
        /// Set to a lower number to save memory (minimum 8).
        /// </summary>
        int ExplodMax => this.GetValue<int>("ExplodMax");

        /// <summary>
        /// Maximum number of system explods allowed.
        /// Set to a lower number to save memory (minimum 8).
        /// </summary>
        int SysExplodMax => this.GetValue<int>("SysExplodMax");

        /// <summary>
        /// Maximum number of helpers allowed in total.
        /// Set to a lower number to save memory (minimum 4, maximum 56).
        /// </summary>
        int HelperMax => this.GetValue<int>("HelperMax");

        /// <summary>
        /// Maximum number of projectiles allowed per player.
        /// Set to a lower number to save memory (minimum 5).
        /// </summary>
        int PlayerProjectileMax => this.GetValue<int>("PlayerProjectileMax");

        /// <summary>
        /// This is true the first time you run engine.
        /// </summary>
        bool FirstRun => this.GetValue<bool>("FirstRun");
    }

    public interface IConfigNegumDebug : INegumManagerSection
    {
        /// <summary>
        /// Set to false to disable starting in debug mode by default.
        /// </summary>
        bool IsDebug => this.GetValue<bool>("Debug");

        /// <summary>
        /// Set to false to disallow switching to debug mode by pressing Ctrl-D.
        /// If Debug = true, this will be ignored.
        /// </summary>
        bool AllowDebugMode => this.GetValue<bool>("AllowDebugMode");

        /// <summary>
        /// Set to true to allow debug keys at all times.
        /// Otherwise debug keys allowed only in debug mode.
        /// </summary>
        bool AllowDebugKeys => this.GetValue<bool>("AllowDebugKeys");

        /// <summary>
        /// Set to true to run at maximum speed by default.
        /// </summary>
        bool SpeedUp => this.GetValue<bool>("Speedup");

        /// <summary>
        /// Default starting stage for quick versus.
        /// </summary>
        IFileEntry StartStageFile => this.GetValue<IFileEntry>("StartStage");

        /// <summary>
        /// Set to true to hide the development build banner that shows on startup.
        /// </summary>
        bool HideDevelopmentBuildBanner => this.GetValue<bool>("HideDevelopmentBuildBanner");
    }

    public interface IConfigNegumVideo : INegumManagerSection
    {
        /// <summary>
        /// This is the color depth at which to run engine.
        /// </summary>
        int Depth => this.GetValue<int>("Depth");

        /// <summary>
        /// Set to true to start in fullscreen mode, 0 for windowed.
        /// This enables exclusive fullscreen, which may give better performance than windowed mode.
        /// </summary>
        bool FullScreen => this.GetValue<bool>("FullScreen");

        /// <summary>
        /// Set to true to make the window resizable when in windowed mode.
        /// </summary>
        bool Resizable => this.GetValue<bool>("Resizable");

        /// <summary>
        /// Set to false to stretch the video to fit the whole window.
        /// Set to true to keep a fixed aspect ratio.
        /// </summary>
        bool KeepAspect => this.GetValue<bool>("KeepAspect");

        /// <summary>
        /// Stage fit mode.
        /// 0 - stage drawn to width of screen (may crop stages with tall aspect)
        /// 1 - stage shrunk to fit into screen
        /// </summary>
        int StageFit => this.GetValue<int>("StageFit");

        /// <summary>
        /// System fit mode.
        /// 0 - system drawn to width of screen (may crop motifs with tall aspect)
        /// 1 - system shrunk to fit into screen
        /// </summary>
        int SystemFit => this.GetValue<int>("SystemFit");
    }

    public interface IConfigNegumSound : INegumManagerSection
    {
        /// <summary>
        /// Set the following to true to enable sound effects and music.
        /// Set to false to disable.
        /// </summary>
        bool IsSound => this.GetValue<bool>("Sound");

        /// <summary>
        /// Set the sample rate of the game audio.
        /// Higher rates produce better quality but require more system resources.
        /// Lower the rate if you are having problems with sound performance.
        /// Recommended values are 22050, 44100, or 48000.
        /// </summary>
        int SampleRate => this.GetValue<int>("SampleRate");

        /// <summary>
        /// This is the width of the sound panning field.
        /// If you Increase this number, the stereo effects will sound closer to the middle.
        /// Set to a smaller number to get more stereo separation on sound effects.
        /// Only valid if StereoEffects is set to true.
        /// </summary>
        int PanningWidth => this.GetValue<int>("PanningWidth");

        /// <summary>
        /// Number of voice channels to use.
        /// </summary>
        int WavChannels => this.GetValue<int>("WavChannels");

        /// <summary>
        /// This is the master volume for all sounds, in percent (0-100).
        /// </summary>
        int MasterVolume => this.GetValue<int>("MasterVolume");

        /// <summary>
        /// This is the volume for sound effects and voices, in percent (0-100).
        /// </summary>
        int WavVolume => this.GetValue<int>("WavVolume");

        /// <summary>
        /// This is the master volume for music, (0-100).
        /// </summary>
        int BackgroundMusicVolume => this.GetValue<int>("BGMVolume");
    }

    public interface IConfigNegumMisc : INegumManagerSection
    {
        /// <summary>
        /// Number of extra players to cache in memory.
        /// Set to a lower number to decrease memory usage, at cost of more frequent loading.
        /// </summary>
        int PlayerCache => this.GetValue<int>("PlayerCache");

        /// <summary>
        /// Set to true to pause the game when the window is in the background.
        /// </summary>
        bool PauseOnDefocus => this.GetValue<bool>("PauseOnDefocus");

        /// <summary>
        /// Configures the handling of sound effects and voices when the window is in the background (i.e., defocused).
        /// Set to "Mute" to mute sound effects, or "Play" to let sound effects play.
        /// </summary>
        string SfxBackgroundMode => this.GetValue<string>("SFXBackgroundMode");

        /// <summary>
        /// Configures the handling of BGM when the window is in the background.
        /// Set to "Pause" to pause the music, "Mute" to mute the music but leave it running at normal speed, or "Play" to continue playing as usual.
        /// If you are running in fullscreen mode, then this setting is always set to "Pause".
        /// </summary>
        string BackgroundMusicBackgroundMode => this.GetValue<string>("BGMBackgroundMode");
    }

    public interface IConfigNegumArcade : INegumManagerSection
    {
        /// <summary>
        /// Set to false for computer to choose color 1 if possible.
        /// Set to true for computer to randomly choose a color.
        /// </summary>
        bool AiRandomColor => this.GetValue<bool>("AI.RandomColor");

        /// <summary>
        /// This option allows the AI to input commands without having to actually press any keys (in effect, cheating).
        /// Set to true to enable, false to disable.
        /// </summary>
        bool AiCheat => this.GetValue<bool>("AI.Cheat");

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
        IVectorEntry ArcadeAiRampStart => this.GetValue<IVectorEntry>("arcade.AIramp.start");

        IVectorEntry ArcadeAiRampEnd => this.GetValue<IVectorEntry>("arcade.AIramp.end");


        /// <summary>
        /// Team Mode AI ramping.
        /// </summary>
        IVectorEntry TeamAiRampStart => this.GetValue<IVectorEntry>("team.AIramp.start");

        IVectorEntry TeamAiRampEnd => this.GetValue<IVectorEntry>("team.AIramp.end");

        /// <summary>
        /// Survival Mode AI ramping.
        /// </summary>
        IVectorEntry SurvivalAiRampStart => this.GetValue<IVectorEntry>("survival.AIramp.start");

        IVectorEntry SurvivalAiRampEnd => this.GetValue<IVectorEntry>("survival.AIramp.end");
    }

    public interface IConfigNegumInput : INegumManagerSection
    {
        bool P1UseKeyboard => this.GetValue<bool>("P1.UseKeyboard");
        bool P2UseKeyboard => this.GetValue<bool>("P2.UseKeyboard");
        bool P1UseJoystick => this.GetValue<bool>("P1.Joystick.type");
        bool P2UseJoystick => this.GetValue<bool>("P2.Joystick.type");

        /// <summary>
        /// false - Only pause key will unpause
        /// true - Any key unpauses if there is no menu
        /// </summary>
        bool AnyKeyUnpauses => this.GetValue<bool>("AnyKeyUnpauses");
    }

    public interface IConfigNegumKeys : INegumManagerSection
    {
        IKeysEntry Keys => this.GetValue<IKeysEntry>(string.Empty);
    }
}