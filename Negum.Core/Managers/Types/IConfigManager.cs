using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Negum core configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IConfigurationManager : IManager
{
    IConfigurationOptions Options => GetSection<IConfigurationOptions>("Options");
    IConfigurationRules Rules => GetSection<IConfigurationRules>("Rules");
    IConfigurationConfig Config => GetSection<IConfigurationConfig>("Config");
    IConfigurationDebug Debug => GetSection<IConfigurationDebug>("Debug");
    IConfigurationVideo Video => GetSection<IConfigurationVideo>("Video");
    IConfigurationSound Sound => GetSection<IConfigurationSound>("Sound");
    IConfigurationMisc Misc => GetSection<IConfigurationMisc>("Misc");
    IConfigurationArcade Arcade => GetSection<IConfigurationArcade>("Arcade");
    IConfigurationInput Input => GetSection<IConfigurationInput>("Input");
    IConfigurationKeys P1Keys => GetSection<IConfigurationKeys>("P1 Keys");
    IConfigurationKeys P2Keys => GetSection<IConfigurationKeys>("P2 Keys");
    IConfigurationKeys P1Joystick => GetSection<IConfigurationKeys>("P1 Joystick");
    IConfigurationKeys P2Joystick => GetSection<IConfigurationKeys>("P2 Joystick");
}

public interface IConfigurationOptions : IManagerSection
{
    int? Difficulty => GetValue<int>("Difficulty");
    int? Life => GetValue<int>("Life");
    ITimeEntry? Time => GetValue<ITimeEntry>("Time");
    int? GameSpeed => GetValue<int>("GameSpeed");
    int? Team1Vs2Life => GetValue<int>("Team.1VS2Life");
    bool? TeamLoseOnKo => GetValue<bool>("Team.LoseOnKO");

    /// <summary>
    /// Set the motif to use.
    /// Motifs are themes that define the look and feel of engine.
    /// This is not accessible in options screen.
    /// 
    /// Note: If you install a motif that overwrites system files (not recommended)
    /// you may need to set the motif line to use data/system.def instead.
    /// motif = data/system.def  - Use this line if using a motif that overwrites system files.
    /// </summary>
    string? MotifFile => GetValue<string>("motif");
}

public interface IConfigurationRules : IManagerSection
{
    /// <summary>
    /// This is the amount of power the attacker gets when an attack successfully hits the opponent.
    /// It's a multiplier of the damage done.
    /// For example, for a value of 3, a hit that does 10 damage will give 30 power.
    /// </summary>
    float? DefaultAttackLifeToPowerMul => GetValue<float>("Default.Attack.LifeToPowerMul");

    /// <summary>
    /// This is like the above, but it's for the person getting hit.
    /// These two multipliers can be overridden in the Hitdef controller in the
    /// CNS by using the "getpower" and "givepower" options.
    /// </summary>
    float? DefaultGetHitLifeToPowerMul => GetValue<float>("Default.GetHit.LifeToPowerMul");

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
    float? SuperTargetDefenceMul => GetValue<float>("Super.TargetDefenceMul");
}

public interface IConfigurationConfig : IManagerSection
{
    /// <summary>
    /// Set the game speed here. The default is 60 frames per second.
    /// The larger the number, the faster it goes.
    /// Don't use a value less than 10.
    /// </summary>
    int? GameSpeed => GetValue<int>("GameSpeed");

    /// <summary>
    /// Game native width.
    /// </summary>
    int? GameWidth => GetValue<int>("GameWidth");

    /// <summary>
    /// Game native height.
    /// </summary>
    int? GameHeight => GetValue<int>("GameHeight");

    /// <summary>
    /// Preferred language (ISO 639-1), e.g. en, es, ja, etc.
    /// See http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
    /// Leave blank to automatically detect the system language.
    /// </summary>
    string? Language => GetValue<string>("Language");

    /// <summary>
    /// Set to true to draw shadows (default).
    /// Set to false if you have a slow machine, and want to improve speed by not drawing shadows.
    /// </summary>
    bool? DrawShadows => GetValue<bool>("DrawShadows");

    /// <summary>
    /// Number of simultaneous afterimage effects allowed.
    /// Set to a lower number to save memory (minimum 1).
    /// </summary>
    int? AfterImageMax => GetValue<int>("AfterImageMax");

    /// <summary>
    /// Maximum number of layered sprites that can be drawn.
    /// Set to a lower number to save memory (minimum 32).
    /// </summary>
    int? LayeredSpriteMax => GetValue<int>("LayeredSpriteMax");

    /// <summary>
    /// Size of sprite decompression buffer in KB.
    /// Increasing this number may help if you experience slow performance when there are many sprites and/or large
    /// sprites shown over a short period of time.
    /// Minimum 256 for acceptable performance.
    /// If you set this too large you may also experience performance degredation.
    /// </summary>
    int? SpriteDecompressionBufferSize => GetValue<int>("SpriteDecompressionBufferSize");

    /// <summary>
    /// Maximum number of explods allowed in total.
    /// Note that hitsparks also count as explods.
    /// Set to a lower number to save memory (minimum 8).
    /// </summary>
    int? ExplodMax => GetValue<int>("ExplodMax");

    /// <summary>
    /// Maximum number of system explods allowed.
    /// Set to a lower number to save memory (minimum 8).
    /// </summary>
    int? SysExplodMax => GetValue<int>("SysExplodMax");

    /// <summary>
    /// Maximum number of helpers allowed in total.
    /// Set to a lower number to save memory (minimum 4, maximum 56).
    /// </summary>
    int? HelperMax => GetValue<int>("HelperMax");

    /// <summary>
    /// Maximum number of projectiles allowed per player.
    /// Set to a lower number to save memory (minimum 5).
    /// </summary>
    int? PlayerProjectileMax => GetValue<int>("PlayerProjectileMax");

    /// <summary>
    /// This is true the first time you run engine.
    /// </summary>
    bool? FirstRun => GetValue<bool>("FirstRun");
}

public interface IConfigurationDebug : IManagerSection
{
    /// <summary>
    /// Set to false to disable starting in debug mode by default.
    /// </summary>
    bool? IsDebug => GetValue<bool>("Debug");

    /// <summary>
    /// Set to false to disallow switching to debug mode by pressing Ctrl-D.
    /// If Debug = true, this will be ignored.
    /// </summary>
    bool? AllowDebugMode => GetValue<bool>("AllowDebugMode");

    /// <summary>
    /// Set to true to allow debug keys at all times.
    /// Otherwise debug keys allowed only in debug mode.
    /// </summary>
    bool? AllowDebugKeys => GetValue<bool>("AllowDebugKeys");

    /// <summary>
    /// Set to true to run at maximum speed by default.
    /// </summary>
    bool? SpeedUp => GetValue<bool>("Speedup");

    /// <summary>
    /// Default starting stage for quick versus.
    /// </summary>
    string? StartStageFile => GetValue<string>("StartStage");

    /// <summary>
    /// Set to true to hide the development build banner that shows on startup.
    /// </summary>
    bool? HideDevelopmentBuildBanner => GetValue<bool>("HideDevelopmentBuildBanner");
}

public interface IConfigurationVideo : IManagerSection
{
    /// <summary>
    /// This is the color depth at which to run engine.
    /// </summary>
    int? Depth => GetValue<int>("Depth");

    /// <summary>
    /// Set to true to start in fullscreen mode, 0 for windowed.
    /// This enables exclusive fullscreen, which may give better performance than windowed mode.
    /// </summary>
    bool? FullScreen => GetValue<bool>("FullScreen");

    /// <summary>
    /// Set to true to make the window resizable when in windowed mode.
    /// </summary>
    bool? Resizable => GetValue<bool>("Resizable");

    /// <summary>
    /// Set to false to stretch the video to fit the whole window.
    /// Set to true to keep a fixed aspect ratio.
    /// </summary>
    bool? KeepAspect => GetValue<bool>("KeepAspect");

    /// <summary>
    /// Stage fit mode.
    /// 0 - stage drawn to width of screen (may crop stages with tall aspect)
    /// 1 - stage shrunk to fit into screen
    /// </summary>
    int? StageFit => GetValue<int>("StageFit");

    /// <summary>
    /// System fit mode.
    /// 0 - system drawn to width of screen (may crop motifs with tall aspect)
    /// 1 - system shrunk to fit into screen
    /// </summary>
    int? SystemFit => GetValue<int>("SystemFit");
}

public interface IConfigurationSound : IManagerSection
{
    /// <summary>
    /// Set the following to true to enable sound effects and music.
    /// Set to false to disable.
    /// </summary>
    bool? IsSound => GetValue<bool>("Sound");

    /// <summary>
    /// Set the sample rate of the game audio.
    /// Higher rates produce better quality but require more system resources.
    /// Lower the rate if you are having problems with sound performance.
    /// Recommended values are 22050, 44100, or 48000.
    /// </summary>
    int? SampleRate => GetValue<int>("SampleRate");

    /// <summary>
    /// This is the width of the sound panning field.
    /// If you Increase this number, the stereo effects will sound closer to the middle.
    /// Set to a smaller number to get more stereo separation on sound effects.
    /// Only valid if StereoEffects is set to true.
    /// </summary>
    int? PanningWidth => GetValue<int>("PanningWidth");

    /// <summary>
    /// Number of voice channels to use.
    /// </summary>
    int? WavChannels => GetValue<int>("WavChannels");

    /// <summary>
    /// This is the master volume for all sounds, in percent (0-100).
    /// </summary>
    int? MasterVolume => GetValue<int>("MasterVolume");

    /// <summary>
    /// This is the volume for sound effects and voices, in percent (0-100).
    /// </summary>
    int? WavVolume => GetValue<int>("WavVolume");

    /// <summary>
    /// This is the master volume for music, (0-100).
    /// </summary>
    int? BackgroundMusicVolume => GetValue<int>("BGMVolume");
}

public interface IConfigurationMisc : IManagerSection
{
    /// <summary>
    /// Number of extra players to cache in memory.
    /// Set to a lower number to decrease memory usage, at cost of more frequent loading.
    /// </summary>
    int? PlayerCache => GetValue<int>("PlayerCache");

    /// <summary>
    /// Set to true to pause the game when the window is in the background.
    /// </summary>
    bool? PauseOnDefocus => GetValue<bool>("PauseOnDefocus");

    /// <summary>
    /// Configures the handling of sound effects and voices when the window is in the background (i.e., defocused).
    /// Set to "Mute" to mute sound effects, or "Play" to let sound effects play.
    /// </summary>
    string? SfxBackgroundMode => GetValue<string>("SFXBackgroundMode");

    /// <summary>
    /// Configures the handling of BGM when the window is in the background.
    /// Set to "Pause" to pause the music, "Mute" to mute the music but leave it running at normal speed, or "Play" to continue playing as usual.
    /// If you are running in fullscreen mode, then this setting is always set to "Pause".
    /// </summary>
    string? BackgroundMusicBackgroundMode => GetValue<string>("BGMBackgroundMode");
}

public interface IConfigurationArcade : IManagerSection
{
    /// <summary>
    /// Set to false for computer to choose color 1 if possible.
    /// Set to true for computer to randomly choose a color.
    /// </summary>
    bool? AiRandomColor => GetValue<bool>("AI.RandomColor");

    /// <summary>
    /// This option allows the AI to input commands without having to actually press any keys (in effect, cheating).
    /// Set to true to enable, false to disable.
    /// </summary>
    bool? AiCheat => GetValue<bool>("AI.Cheat");

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
    IVectorEntry? ArcadeAiRampStart => GetValue<IVectorEntry>("arcade.AIramp.start");

    IVectorEntry? ArcadeAiRampEnd => GetValue<IVectorEntry>("arcade.AIramp.end");


    /// <summary>
    /// Team Mode AI ramping.
    /// </summary>
    IVectorEntry? TeamAiRampStart => GetValue<IVectorEntry>("team.AIramp.start");

    IVectorEntry? TeamAiRampEnd => GetValue<IVectorEntry>("team.AIramp.end");

    /// <summary>
    /// Survival Mode AI ramping.
    /// </summary>
    IVectorEntry? SurvivalAiRampStart => GetValue<IVectorEntry>("survival.AIramp.start");

    IVectorEntry? SurvivalAiRampEnd => GetValue<IVectorEntry>("survival.AIramp.end");
}

public interface IConfigurationInput : IManagerSection
{
    bool? P1UseKeyboard => GetValue<bool>("P1.UseKeyboard");
    bool? P2UseKeyboard => GetValue<bool>("P2.UseKeyboard");
    bool? P1UseJoystick => GetValue<bool>("P1.Joystick.type");
    bool? P2UseJoystick => GetValue<bool>("P2.Joystick.type");

    /// <summary>
    /// false - Only pause key will unpause
    /// true - Any key unpauses if there is no menu
    /// null - entry not exists
    /// </summary>
    bool? AnyKeyUnpauses => GetValue<bool>("AnyKeyUnpauses");
}

public interface IConfigurationKeys : IManagerSection
{
    IKeysEntry? Keys => GetValue<IKeysEntry>(string.Empty);
}