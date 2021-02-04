using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Scrappers;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for INegumConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public static class NegumConfigurationManager
    {
        /// <summary>
        /// Scrapper which is used to gather appropriate parsed data from given configuration.
        /// </summary>
        private static IConfigurationScrapper Scrapper { get; } =
            NegumContainer.Resolve<IConfigurationScrapper>().Use<INegumConfiguration>();

        public static class Options
        {
            public const string SectionKey = "Options";

            public static int Difficulty => Scrapper.GetInt(SectionKey, "Difficulty");
            public static int Life => Scrapper.GetInt(SectionKey, "Life");
            public static int Time => Scrapper.GetInt(SectionKey, "Time");
            public static int GameSpeed => Scrapper.GetInt(SectionKey, "GameSpeed");
            public static int Team1VS2Life => Scrapper.GetInt(SectionKey, "Team.1VS2Life");
            public static bool TeamLoseOnKO => Scrapper.GetBoolean(SectionKey, "Team.LoseOnKO");

            /// <summary>
            /// Set the motif to use.
            /// Motifs are themes that define the look and feel of engine.
            /// This is not accessible in options screen.
            /// 
            /// Note: If you install a motif that overwrites system files (not recommended)
            /// you may need to set the motif line to use data/system.def instead.
            /// motif = data/system.def  - Use this line if using a motif that overwrites system files.
            /// </summary>
            public static IFileEntry Motif => Scrapper.GetFile(SectionKey, "motif");
        }

        public static class Rules
        {
            public const string SectionKey = "Rules";

            /// <summary>
            /// This is the amount of power the attacker gets when an attack successfully hits the opponent.
            /// It's a multiplier of the damage done.
            /// For example, for a value of 3, a hit that does 10 damage will give 30 power.
            /// </summary>
            public static float DefaultAttackLifeToPowerMul =>
                Scrapper.GetFloat(SectionKey, "Default.Attack.LifeToPowerMul");

            /// <summary>
            /// This is like the above, but it's for the person getting hit.
            /// These two multipliers can be overridden in the Hitdef controller in the
            /// CNS by using the "getpower" and "givepower" options.
            /// </summary>
            public static float DefaultGetHitLifeToPowerMul =>
                Scrapper.GetFloat(SectionKey, "Default.GetHit.LifeToPowerMul");

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
            public static float SuperTargetDefenceMul => Scrapper.GetFloat(SectionKey, "Super.TargetDefenceMul");
        }

        public static class Config
        {
            public const string SectionKey = "Config";

            /// <summary>
            /// Set the game speed here. The default is 60 frames per second.
            /// The larger the number, the faster it goes.
            /// Don't use a value less than 10.
            /// </summary>
            public static int GameSpeed => Scrapper.GetInt(SectionKey, "GameSpeed");

            /// <summary>
            /// Game native width.
            /// </summary>
            public static int GameWidth => Scrapper.GetInt(SectionKey, "GameWidth");

            /// <summary>
            /// Game native height.
            /// </summary>
            public static int GameHeight => Scrapper.GetInt(SectionKey, "GameHeight");

            /// <summary>
            /// Preferred language (ISO 639-1), e.g. en, es, ja, etc.
            /// See http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
            /// Leave blank to automatically detect the system language.
            /// </summary>
            public static string Language => Scrapper.GetString(SectionKey, "Language");

            /// <summary>
            /// Set to true to draw shadows (default).
            /// Set to false if you have a slow machine, and want to improve speed by not drawing shadows.
            /// </summary>
            public static bool DrawShadows => Scrapper.GetBoolean(SectionKey, "DrawShadows");

            /// <summary>
            /// Number of simultaneous afterimage effects allowed.
            /// Set to a lower number to save memory (minimum 1).
            /// </summary>
            public static int AfterImageMax => Scrapper.GetInt(SectionKey, "AfterImageMax");

            /// <summary>
            /// Maximum number of layered sprites that can be drawn.
            /// Set to a lower number to save memory (minimum 32).
            /// </summary>
            public static int LayeredSpriteMax => Scrapper.GetInt(SectionKey, "LayeredSpriteMax");

            /// <summary>
            /// Size of sprite decompression buffer in KB.
            /// Increasing this number may help if you experience slow performance when there are many sprites and/or large
            /// sprites shown over a short period of time.
            /// Minimum 256 for acceptable performance.
            /// If you set this too large you may also experience performance degredation.
            /// </summary>
            public static int SpriteDecompressionBufferSize =>
                Scrapper.GetInt(SectionKey, "SpriteDecompressionBufferSize");

            /// <summary>
            /// Maximum number of explods allowed in total.
            /// Note that hitsparks also count as explods.
            /// Set to a lower number to save memory (minimum 8).
            /// </summary>
            public static int ExplodMax => Scrapper.GetInt(SectionKey, "ExplodMax");

            /// <summary>
            /// Maximum number of system explods allowed.
            /// Set to a lower number to save memory (minimum 8).
            /// </summary>
            public static int SysExplodMax => Scrapper.GetInt(SectionKey, "SysExplodMax");

            /// <summary>
            /// Maximum number of helpers allowed in total.
            /// Set to a lower number to save memory (minimum 4, maximum 56).
            /// </summary>
            public static int HelperMax => Scrapper.GetInt(SectionKey, "HelperMax");

            /// <summary>
            /// Maximum number of projectiles allowed per player.
            /// Set to a lower number to save memory (minimum 5).
            /// </summary>
            public static int PlayerProjectileMax => Scrapper.GetInt(SectionKey, "PlayerProjectileMax");

            /// <summary>
            /// This is true the first time you run engine.
            /// </summary>
            public static bool FirstRun => Scrapper.GetBoolean(SectionKey, "FirstRun");
        }

        public static class Debug
        {
            public const string SectionKey = "Debug";

            /// <summary>
            /// Set to false to disable starting in debug mode by default.
            /// </summary>
            public static bool IsDebug => Scrapper.GetBoolean(SectionKey, "Debug");

            /// <summary>
            /// Set to false to disallow switching to debug mode by pressing Ctrl-D.
            /// If Debug = true, this will be ignored.
            /// </summary>
            public static bool AllowDebugMode => Scrapper.GetBoolean(SectionKey, "AllowDebugMode");

            /// <summary>
            /// Set to true to allow debug keys at all times.
            /// Otherwise debug keys allowed only in debug mode.
            /// </summary>
            public static bool AllowDebugKeys => Scrapper.GetBoolean(SectionKey, "AllowDebugKeys");

            /// <summary>
            /// Set to true to run at maximum speed by default.
            /// </summary>
            public static bool SpeedUp => Scrapper.GetBoolean(SectionKey, "Speedup");

            /// <summary>
            /// Default starting stage for quick versus.
            /// </summary>
            public static string StartStage => Scrapper.GetString(SectionKey, "StartStage");

            /// <summary>
            /// Set to true to hide the development build banner that shows on startup.
            /// </summary>
            public static bool HideDevelopmentBuildBanner =>
                Scrapper.GetBoolean(SectionKey, "HideDevelopmentBuildBanner");
        }

        public static class Video
        {
            public const string SectionKey = "Video";

            /// <summary>
            /// This is the color depth at which to run engine.
            /// </summary>
            public static int Depth => Scrapper.GetInt(SectionKey, "Depth");

            /// <summary>
            /// Set to true to start in fullscreen mode, 0 for windowed.
            /// This enables exclusive fullscreen, which may give better performance than windowed mode.
            /// </summary>
            public static bool FullScreen => Scrapper.GetBoolean(SectionKey, "FullScreen");

            /// <summary>
            /// Set to true to make the window resizable when in windowed mode.
            /// </summary>
            public static bool Resizable => Scrapper.GetBoolean(SectionKey, "Resizable");

            /// <summary>
            /// Set to false to stretch the video to fit the whole window.
            /// Set to true to keep a fixed aspect ratio.
            /// </summary>
            public static bool KeepAspect => Scrapper.GetBoolean(SectionKey, "KeepAspect");

            /// <summary>
            /// Stage fit mode.
            /// 0 - stage drawn to width of screen (may crop stages with tall aspect)
            /// 1 - stage shrunk to fit into screen
            /// </summary>
            public static int StageFit => Scrapper.GetInt(SectionKey, "StageFit");

            /// <summary>
            /// System fit mode.
            /// 0 - system drawn to width of screen (may crop motifs with tall aspect)
            /// 1 - system shrunk to fit into screen
            /// </summary>
            public static int SystemFit => Scrapper.GetInt(SectionKey, "SystemFit");
        }

        public static class Sound
        {
            public const string SectionKey = "Sound";

            /// <summary>
            /// Set the following to true to enable sound effects and music.
            /// Set to false to disable.
            /// </summary>
            public static bool IsSound => Scrapper.GetBoolean(SectionKey, "Sound");

            /// <summary>
            /// Set the sample rate of the game audio.
            /// Higher rates produce better quality but require more system resources.
            /// Lower the rate if you are having problems with sound performance.
            /// Recommended values are 22050, 44100, or 48000.
            /// </summary>
            public static int SampleRate => Scrapper.GetInt(SectionKey, "SampleRate");

            /// <summary>
            /// This is the width of the sound panning field.
            /// If you Increase this number, the stereo effects will sound closer to the middle.
            /// Set to a smaller number to get more stereo separation on sound effects.
            /// Only valid if StereoEffects is set to true.
            /// </summary>
            public static int PanningWidth => Scrapper.GetInt(SectionKey, "PanningWidth");

            /// <summary>
            /// Number of voice channels to use.
            /// </summary>
            public static int WavChannels => Scrapper.GetInt(SectionKey, "WavChannels");

            /// <summary>
            /// This is the master volume for all sounds, in percent (0-100).
            /// </summary>
            public static int MasterVolume => Scrapper.GetInt(SectionKey, "MasterVolume");

            /// <summary>
            /// This is the volume for sound effects and voices, in percent (0-100).
            /// </summary>
            public static int WavVolume => Scrapper.GetInt(SectionKey, "WavVolume");

            /// <summary>
            /// This is the master volume for music, (0-100).
            /// </summary>
            public static int BgmVolume => Scrapper.GetInt(SectionKey, "BGMVolume");
        }

        public static class Misc
        {
            public const string SectionKey = "Misc";

            /// <summary>
            /// Number of extra players to cache in memory.
            /// Set to a lower number to decrease memory usage, at cost of more frequent loading.
            /// </summary>
            public static int PlayerCache => Scrapper.GetInt(SectionKey, "PlayerCache");

            /// <summary>
            /// Set to true to pause the game when the window is in the background.
            /// </summary>
            public static bool PauseOnDefocus => Scrapper.GetBoolean(SectionKey, "PauseOnDefocus");

            /// <summary>
            /// Configures the handling of sound effects and voices when the window is in the background (i.e., defocused).
            /// Set to "Mute" to mute sound effects, or "Play" to let sound effects play.
            /// </summary>
            public static string SfxBackgroundMode => Scrapper.GetString(SectionKey, "SFXBackgroundMode");

            /// <summary>
            /// Configures the handling of BGM when the window is in the background.
            /// Set to "Pause" to pause the music, "Mute" to mute the music but leave it running at normal speed, or "Play" to continue playing as usual.
            /// If you are running in fullscreen mode, then this setting is always set to "Pause".
            /// </summary>
            public static string BgmBackgroundMode => Scrapper.GetString(SectionKey, "BGMBackgroundMode");
        }

        public static class Arcade
        {
            public const string SectionKey = "Arcade";

            /// <summary>
            /// Set to false for computer to choose color 1 if possible.
            /// Set to true for computer to randomly choose a color.
            /// </summary>
            public static bool AiRandomColor => Scrapper.GetBoolean(SectionKey, "AI.RandomColor");

            /// <summary>
            /// This option allows the AI to input commands without having to actually press any keys (in effect, cheating).
            /// Set to true to enable, false to disable.
            /// </summary>
            public static bool AiCheat => Scrapper.GetBoolean(SectionKey, "AI.Cheat");

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
            public static string ArcadeAiRampStart => Scrapper.GetString(SectionKey, "arcade.AIramp.start");

            public static string ArcadeAiRampEnd => Scrapper.GetString(SectionKey, "arcade.AIramp.end");


            /// <summary>
            /// Team Mode AI ramping.
            /// </summary>
            public static string TeamAiRampStart => Scrapper.GetString(SectionKey, "team.AIramp.start");

            public static string TeamAiRampEnd => Scrapper.GetString(SectionKey, "team.AIramp.end");

            /// <summary>
            /// Survival Mode AI ramping.
            /// </summary>
            public static string SurvivalAiRampStart => Scrapper.GetString(SectionKey, "survival.AIramp.start");

            public static string SurvivalAiRampEnd => Scrapper.GetString(SectionKey, "survival.AIramp.end");
        }

        public static class Input
        {
            public const string SectionKey = "Input";

            public static bool P1UseKeyboard => Scrapper.GetBoolean(SectionKey, "P1.UseKeyboard");
            public static bool P2UseKeyboard => Scrapper.GetBoolean(SectionKey, "P2.UseKeyboard");
            public static bool P1UseJoystick => Scrapper.GetBoolean(SectionKey, "P1.Joystick.type");
            public static bool P2UseJoystick => Scrapper.GetBoolean(SectionKey, "P2.Joystick.type");

            /// <summary>
            /// false - Only pause key will unpause
            /// true - Any key unpauses if there is no menu
            /// </summary>
            public static bool AnyKeyUnpauses => Scrapper.GetBoolean(SectionKey, "AnyKeyUnpauses");
        }

        public static class P1Keys
        {
            public const string SectionKey = "P1 Keys";

            public static Keys Keys { get; } = new Keys(SectionKey);
        }

        public static class P2Keys
        {
            public const string SectionKey = "P2 Keys";

            public static Keys Keys { get; } = new Keys(SectionKey);
        }

        public static class P1Joystick
        {
            public const string SectionKey = "P1 Joystick";

            public static Keys Keys { get; } = new Keys(SectionKey);
        }

        public static class P2Joystick
        {
            public const string SectionKey = "P2 Joystick";

            public static Keys Keys { get; } = new Keys(SectionKey);
        }

        public class Keys
        {
            private string SectionName { get; }

            public int Jump => Scrapper.GetInt(SectionName, "Jump");
            public int Crouch => Scrapper.GetInt(SectionName, "Crouch");
            public int Left => Scrapper.GetInt(SectionName, "Left");
            public int Right => Scrapper.GetInt(SectionName, "Right");
            public int A => Scrapper.GetInt(SectionName, "A");
            public int B => Scrapper.GetInt(SectionName, "B");
            public int C => Scrapper.GetInt(SectionName, "C");
            public int X => Scrapper.GetInt(SectionName, "X");
            public int Y => Scrapper.GetInt(SectionName, "Y");
            public int Z => Scrapper.GetInt(SectionName, "Z");
            public int Start => Scrapper.GetInt(SectionName, "Start");

            public Keys(string sectionName)
            {
                this.SectionName = sectionName;
            }
        }
    }
}