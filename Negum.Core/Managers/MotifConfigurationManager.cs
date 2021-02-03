using System;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Scrappers;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which provides helper methods for IMotifConfiguration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public static class MotifConfigurationManager
    {
        /// <summary>
        /// Scrapper which is used to gather appropriate parsed data from given configuration.
        /// </summary>
        private static IConfigurationScrapper Scrapper { get; } =
            NegumContainer.Resolve<IConfigurationScrapper>().Use<IMotifConfiguration>();

        public static class Info
        {
            public const string SectionKey = "Info";

            /// <summary>
            /// Name of motif.
            /// </summary>
            public static string Name => Scrapper.GetString(SectionKey, "name");

            /// <summary>
            /// Motif author name.
            /// </summary>
            public static string Author => Scrapper.GetString(SectionKey, "author");

            /// <summary>
            /// Version date of motif.
            /// </summary>
            public static DateTime VersionDate => Scrapper.GetDate(SectionKey, "versiondate");

            /// <summary>
            /// Version of motif.
            /// </summary>
            public static float Version => Scrapper.GetFloat(SectionKey, "mugenversion");
        }

        public static class Files
        {
            public const string SectionKey = "Files";

            /// <summary>
            /// Filename of sprite data.
            /// </summary>
            public static IFileEntry Sprite => Scrapper.GetFile(SectionKey, "");

            /// <summary>
            /// Filename of sound data.
            /// </summary>
            public static IFileEntry Sound => Scrapper.GetFile(SectionKey, "");

            /// <summary>
            /// Logo storyboard definition (optional).
            /// </summary>
            public static string LogoStoryboardDefinition => Scrapper.GetString(SectionKey, "");

            /// <summary>
            /// Intro storyboard definition (optional).
            /// </summary>
            public static string IntroStoryboardDefinition => Scrapper.GetString(SectionKey, "");

            /// <summary>
            /// Character and stage selection list.
            /// </summary>
            public static IFileEntry Selection => Scrapper.GetFile(SectionKey, "");

            /// <summary>
            /// Fight definition filename.
            /// </summary>
            public static IFileEntry Fight => Scrapper.GetFile(SectionKey, "");

            /// <summary>
            /// System fonts.
            /// </summary>
            public static IEntryCollection<IFileEntry> Fonts => Scrapper.GetCollection<IFileEntry>(SectionKey, "font");
        }

        public static class Music
        {
            public const string SectionKey = "Music";
        }

        public static class TitleInfo
        {
            public const string SectionKey = "Title Info";
        }

        public static class TitleBgDef // Enumerable inside
        {
            public const string SectionKey = "TitleBGdef";
        }

        public static class Infobox
        {
            public const string SectionKey = "Infobox";
        }

        public static class SelectInfo
        {
            public const string SectionKey = "Select Info";
        }

        public static class SelectBgDef // Enumerable inside
        {
            public const string SectionKey = "SelectBGdef";
        }

        public static class VsScreen // Enumerable inside
        {
            public const string SectionKey = "VS Screen";
        }

        public static class VsBgDef
        {
            public const string SectionKey = "VersusBGdef";
        }

        public static class DemoMode
        {
            public const string SectionKey = "Demo Mode";
        }

        public static class ContinueScreen
        {
            public const string SectionKey = "Continue Screen";
        }

        public static class GameOverScreen
        {
            public const string SectionKey = "Game Over Screen";
        }

        public static class VictoryScreen // Enumerable inside
        {
            public const string SectionKey = "Victory Screen";
        }

        public static class WinScreen
        {
            public const string SectionKey = "Win Screen";
        }

        public static class DefaultEnding
        {
            public const string SectionKey = "Default Ending";
        }

        public static class EndCredits
        {
            public const string SectionKey = "End Credits";
        }

        public static class SurvivalResultsScreen
        {
            public const string SectionKey = "Survival Results Screen";
        }

        public static class OptionInfo // Enumerable inside
        {
            public const string SectionKey = "Optio nInfo";
        }
    }
}