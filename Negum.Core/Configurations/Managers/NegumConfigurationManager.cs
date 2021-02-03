using Negum.Core.Containers;

namespace Negum.Core.Configurations.Managers
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
        /// Configuration used be Manager.
        /// By default it will use what is registered in NegumContainer.
        /// </summary>
        public static INegumConfiguration Configuration { get; set; } = NegumContainer.Resolve<INegumConfiguration>();

        public static int GetInt(string sectionName, string fieldKey) =>
            int.Parse(GetString(sectionName, fieldKey));

        public static float GetFloat(string sectionName, string fieldKey) =>
            float.Parse(GetString(sectionName, fieldKey));

        public static bool GetBoolean(string sectionName, string fieldKey) =>
            bool.Parse(GetString(sectionName, fieldKey));

        public static string GetString(string sectionName, string fieldKey) =>
            Configuration.Sections[sectionName][fieldKey];

        public static class Options
        {
            public const string SectionKey = "Options";

            public static int Difficulty => GetInt(SectionKey, "Difficulty");
            public static int Life => GetInt(SectionKey, "Life");
            public static int Time => GetInt(SectionKey, "Time");
            public static int GameSpeed => GetInt(SectionKey, "GameSpeed");
            public static int Team1VS2Life => GetInt(SectionKey, "Team.1VS2Life");
            public static bool TeamLoseOnKO => GetBoolean(SectionKey, "Team.LoseOnKO");

            /// <summary>
            /// Set the motif to use.
            /// Motifs are themes that define the look and feel of engine.
            /// This is not accessible in options screen.
            /// 
            /// Note: If you install a motif that overwrites system files (not recommended)
            /// you may need to set the motif line to use data/system.def instead.
            /// motif = data/system.def  - Use this line if using a motif that overwrites system files.
            /// </summary>
            public static string Motif => GetString(SectionKey, "motif");
        }

        public static class Rules
        {
            public const string SectionKey = "Rules";

            /// <summary>
            /// Keep this set at VS. It's the only option supported for now...
            /// </summary>
            public static string GameType => GetString(SectionKey, "GameType");

            /// <summary>
            /// This is the amount of power the attacker gets when an attack successfully hits the opponent.
            /// It's a multiplier of the damage done.
            /// For example, for a value of 3, a hit that does 10 damage will give 30 power.
            /// </summary>
            public static float DefaultAttackLifeToPowerMul => GetFloat(SectionKey, "Default.Attack.LifeToPowerMul");

            /// <summary>
            /// This is like the above, but it's for the person getting hit.
            /// These two multipliers can be overridden in the Hitdef controller in the
            /// CNS by using the "getpower" and "givepower" options.
            /// </summary>
            public static float DefaultGetHitLifeToPowerMul => GetFloat(SectionKey, "Default.GetHit.LifeToPowerMul");

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
            public static float SuperTargetDefenceMul => GetFloat(SectionKey, "Super.TargetDefenceMul");
        }

        public static class Config
        {
            public const string SectionKey = "Config";

            /// <summary>
            /// Set the game speed here. The default is 60 frames per second.
            /// The larger the number, the faster it goes.
            /// Don't use a value less than 10.
            /// </summary>
            public static int GameSpeed => GetInt(SectionKey, "GameSpeed");

            /// <summary>
            /// Game native width.
            /// </summary>
            public static int GameWidth => GetInt(SectionKey, "GameWidth");

            /// <summary>
            /// Game native height.
            /// </summary>
            public static int GameHeight => GetInt(SectionKey, "GameHeight");

            /// <summary>
            /// Preferred language (ISO 639-1), e.g. en, es, ja, etc.
            /// See http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes
            /// Leave blank to automatically detect the system language.
            /// </summary>
            public static string Language => GetString(SectionKey, "Language");

            /// <summary>
            /// Set to true to draw shadows (default).
            /// Set to false if you have a slow machine, and want to improve speed by not drawing shadows.
            /// </summary>
            public static bool DrawShadows => GetBoolean(SectionKey, "DrawShadows");

            /// <summary>
            /// Number of simultaneous afterimage effects allowed.
            /// Set to a lower number to save memory (minimum 1).
            /// </summary>
            public static int AfterImageMax => GetInt(SectionKey, "AfterImageMax");

            /// <summary>
            /// Maximum number of layered sprites that can be drawn.
            /// Set to a lower number to save memory (minimum 32).
            /// </summary>
            public static int LayeredSpriteMax => GetInt(SectionKey, "LayeredSpriteMax");

            /// <summary>
            /// Size of sprite decompression buffer in KB.
            /// Increasing this number may help if you experience slow performance when there are many sprites and/or large
            /// sprites shown over a short period of time.
            /// Minimum 256 for acceptable performance.
            /// If you set this too large you may also experience performance degredation.
            /// </summary>
            public static int SpriteDecompressionBufferSize => GetInt(SectionKey, "SpriteDecompressionBufferSize");

            /// <summary>
            /// Maximum number of explods allowed in total.
            /// Note that hitsparks also count as explods.
            /// Set to a lower number to save memory (minimum 8).
            /// </summary>
            public static int ExplodMax => GetInt(SectionKey, "ExplodMax");

            /// <summary>
            /// Maximum number of system explods allowed.
            /// Set to a lower number to save memory (minimum 8).
            /// </summary>
            public static int SysExplodMax => GetInt(SectionKey, "SysExplodMax");

            /// <summary>
            /// Maximum number of helpers allowed in total.
            /// Set to a lower number to save memory (minimum 4, maximum 56).
            /// </summary>
            public static int HelperMax => GetInt(SectionKey, "HelperMax");

            /// <summary>
            /// Maximum number of projectiles allowed per player.
            /// Set to a lower number to save memory (minimum 5).
            /// </summary>
            public static int PlayerProjectileMax => GetInt(SectionKey, "PlayerProjectileMax");

            /// <summary>
            /// This is true the first time you run engine.
            /// </summary>
            public static bool FirstRun => GetBoolean(SectionKey, "FirstRun");
        }

        public static class Debug
        {
            public const string SectionKey = "Debug";

            /// <summary>
            /// Set to false to disable starting in debug mode by default.
            /// </summary>
            public static bool IsDebug => GetBoolean(SectionKey, "Debug");

            /// <summary>
            /// Set to false to disallow switching to debug mode by pressing Ctrl-D.
            /// If Debug = true, this will be ignored.
            /// </summary>
            public static bool AllowDebugMode => GetBoolean(SectionKey, "AllowDebugMode");

            /// <summary>
            /// Set to true to allow debug keys at all times.
            /// Otherwise debug keys allowed only in debug mode.
            /// </summary>
            public static bool AllowDebugKeys => GetBoolean(SectionKey, "AllowDebugKeys");

            /// <summary>
            /// Set to true to run at maximum speed by default.
            /// </summary>
            public static bool SpeedUp => GetBoolean(SectionKey, "Speedup");

            /// <summary>
            /// Default starting stage for quick versus.
            /// </summary>
            public static string StartStage => GetString(SectionKey, "StartStage");

            /// <summary>
            /// Set to true to hide the development build banner that shows on startup.
            /// </summary>
            public static bool HideDevelopmentBuildBanner => GetBoolean(SectionKey, "HideDevelopmentBuildBanner");
        }

        public static class Video
        {
            public const string SectionKey = "Video";

            /// <summary>
            /// This is the color depth at which to run engine.
            /// </summary>
            public static int Depth => GetInt(SectionKey, "Depth");

            /// <summary>
            /// Set to true to start in fullscreen mode, 0 for windowed.
            /// This enables exclusive fullscreen, which may give better performance than windowed mode.
            /// </summary>
            public static bool FullScreen => GetBoolean(SectionKey, "FullScreen");

            /// <summary>
            /// Set to true to make the window resizable when in windowed mode.
            /// </summary>
            public static bool Resizable => GetBoolean(SectionKey, "Resizable");

            /// <summary>
            /// Set to false to stretch the video to fit the whole window.
            /// Set to true to keep a fixed aspect ratio.
            /// </summary>
            public static bool KeepAspect => GetBoolean(SectionKey, "KeepAspect");

            /// <summary>
            /// Stage fit mode.
            /// 0 - stage drawn to width of screen (may crop stages with tall aspect)
            /// 1 - stage shrunk to fit into screen
            /// </summary>
            public static int StageFit => GetInt(SectionKey, "StageFit");

            /// <summary>
            /// System fit mode.
            /// 0 - system drawn to width of screen (may crop motifs with tall aspect)
            /// 1 - system shrunk to fit into screen
            /// </summary>
            public static int SystemFit => GetInt(SectionKey, "SystemFit");
        }

        public static class Sound
        {
            public const string SectionKey = "Sound";

            /// <summary>
            /// Set the following to true to enable sound effects and music.
            /// Set to false to disable.
            /// </summary>
            public static bool IsSound => GetBoolean(SectionKey, "Sound");

            /// <summary>
            /// Set the sample rate of the game audio.
            /// Higher rates produce better quality but require more system resources.
            /// Lower the rate if you are having problems with sound performance.
            /// Recommended values are 22050, 44100, or 48000.
            /// </summary>
            public static int SampleRate => GetInt(SectionKey, "SampleRate");

            /// <summary>
            /// This is the width of the sound panning field.
            /// If you Increase this number, the stereo effects will sound closer to the middle.
            /// Set to a smaller number to get more stereo separation on sound effects.
            /// Only valid if StereoEffects is set to true.
            /// </summary>
            public static int PanningWidth => GetInt(SectionKey, "PanningWidth");

            /// <summary>
            /// Number of voice channels to use.
            /// </summary>
            public static int WavChannels => GetInt(SectionKey, "WavChannels");

            /// <summary>
            /// This is the master volume for all sounds, in percent (0-100).
            /// </summary>
            public static int MasterVolume => GetInt(SectionKey, "MasterVolume");

            /// <summary>
            /// This is the volume for sound effects and voices, in percent (0-100).
            /// </summary>
            public static int WavVolume => GetInt(SectionKey, "WavVolume");

            /// <summary>
            /// This is the master volume for music, (0-100).
            /// </summary>
            public static int BgmVolume => GetInt(SectionKey, "BGMVolume");
        }

        public static class Misc
        {
            public const string SectionKey = "Misc";

            /// <summary>
            /// Number of extra players to cache in memory.
            /// Set to a lower number to decrease memory usage, at cost of more frequent loading.
            /// </summary>
            public static int PlayerCache => GetInt(SectionKey, "PlayerCache");

            /// <summary>
            /// Set to true to pause the game when the window is in the background.
            /// </summary>
            public static bool PauseOnDefocus => GetBoolean(SectionKey, "PauseOnDefocus");

            /// <summary>
            /// Configures the handling of sound effects and voices when the window is in the background (i.e., defocused).
            /// Set to "Mute" to mute sound effects, or "Play" to let sound effects play.
            /// </summary>
            public static string SfxBackgroundMode => GetString(SectionKey, "SFXBackgroundMode");

            /// <summary>
            /// Configures the handling of BGM when the window is in the background.
            /// Set to "Pause" to pause the music, "Mute" to mute the music but leave it running at normal speed, or "Play" to continue playing as usual.
            /// If you are running in fullscreen mode, then this setting is always set to "Pause".
            /// </summary>
            public static string BgmBackgroundMode => GetString(SectionKey, "BGMBackgroundMode");
        }

        public static class Arcade
        {
            public const string SectionKey = "Arcade";

            /// <summary>
            /// Set to false for computer to choose color 1 if possible.
            /// Set to true for computer to randomly choose a color.
            /// </summary>
            public static bool AiRandomColor => GetBoolean(SectionKey, "AI.RandomColor");

            /// <summary>
            /// This option allows the AI to input commands without having to actually press any keys (in effect, cheating).
            /// Set to true to enable, false to disable.
            /// </summary>
            public static bool AiCheat => GetBoolean(SectionKey, "AI.Cheat");

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
            public static string ArcadeAiRampStart => GetString(SectionKey, "arcade.AIramp.start");

            public static string ArcadeAiRampEnd => GetString(SectionKey, "arcade.AIramp.end");


            /// <summary>
            /// Team Mode AI ramping.
            /// </summary>
            public static string TeamAiRampStart => GetString(SectionKey, "team.AIramp.start");

            public static string TeamAiRampEnd => GetString(SectionKey, "team.AIramp.end");

            /// <summary>
            /// Survival Mode AI ramping.
            /// </summary>
            public static string SurvivalAiRampStart => GetString(SectionKey, "survival.AIramp.start");

            public static string SurvivalAiRampEnd => GetString(SectionKey, "survival.AIramp.end");
        }

        public static class Input
        {
            public const string SectionKey = "Input";

            public static bool P1UseKeyboard => GetBoolean(SectionKey, "P1.UseKeyboard");
            public static bool P2UseKeyboard => GetBoolean(SectionKey, "P2.UseKeyboard");
            public static bool P1UseJoystick => GetBoolean(SectionKey, "P1.Joystick.type");
            public static bool P2UseJoystick => GetBoolean(SectionKey, "P2.Joystick.type");

            /// <summary>
            /// false - Only pause key will unpause
            /// true - Any key unpauses if there is no menu
            /// </summary>
            public static bool AnyKeyUnpauses => GetBoolean(SectionKey, "AnyKeyUnpauses");
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
            
            public int Jump => GetInt(SectionName, "Jump");
            public int Crouch => GetInt(SectionName, "Crouch");
            public int Left => GetInt(SectionName, "Left");
            public int Right => GetInt(SectionName, "Right");
            public int A => GetInt(SectionName, "A");
            public int B => GetInt(SectionName, "B");
            public int C => GetInt(SectionName, "C");
            public int X => GetInt(SectionName, "X");
            public int Y => GetInt(SectionName, "Y");
            public int Z => GetInt(SectionName, "Z");
            public int Start => GetInt(SectionName, "Start");
            
            public Keys(string sectionName)
            {
                this.SectionName = sectionName;
            }
        }
    }
}