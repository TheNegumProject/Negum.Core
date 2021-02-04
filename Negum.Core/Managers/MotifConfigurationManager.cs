using System;
using Negum.Core.Configurations;
using Negum.Core.Containers;
using Negum.Core.Scrappers;
using Negum.Core.Scrappers.Entries;

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
            public static IFileEntry Sprite => Scrapper.GetFile(SectionKey, "spr");

            /// <summary>
            /// Filename of sound data.
            /// </summary>
            public static IFileEntry Sound => Scrapper.GetFile(SectionKey, "snd");

            /// <summary>
            /// Logo storyboard definition (optional).
            /// </summary>
            public static string LogoStoryboardDefinition => Scrapper.GetString(SectionKey, "logo.storyboard");

            /// <summary>
            /// Intro storyboard definition (optional).
            /// </summary>
            public static string IntroStoryboardDefinition => Scrapper.GetString(SectionKey, "intro.storyboard");

            /// <summary>
            /// Character and stage selection list.
            /// </summary>
            public static IFileEntry Selection => Scrapper.GetFile(SectionKey, "select");

            /// <summary>
            /// Fight definition filename.
            /// </summary>
            public static IFileEntry Fight => Scrapper.GetFile(SectionKey, "fight");

            /// <summary>
            /// System fonts.
            /// </summary>
            public static IEntryCollection<IFileEntry> Fonts => Scrapper.GetCollection<IFileEntry>(SectionKey, "font");
        }

        public static class Music
        {
            public const string SectionKey = "Music";

            /// <summary>
            /// Music to play at title screen.
            /// </summary>
            public static IAudioEntry Title => Scrapper.GetAudio(SectionKey, "title.bgm");

            /// <summary>
            /// Music to play at char select screen.
            /// </summary>
            public static IAudioEntry Select => Scrapper.GetAudio(SectionKey, "select.bgm");

            /// <summary>
            /// Music to play at versus screen.
            /// </summary>
            public static IAudioEntry Vs => Scrapper.GetAudio(SectionKey, "vs.bgm");

            /// <summary>
            /// Music to play at victory screen.
            /// </summary>
            public static IAudioEntry Victory => Scrapper.GetAudio(SectionKey, "victory.bgm");
        }

        public static class TitleInfo
        {
            public const string SectionKey = "Title Info";

            public static int FadeInTime => Scrapper.GetInt(SectionKey, "fadein.time");
            public static int FadeOutTime => Scrapper.GetInt(SectionKey, "fadeout.time");
            public static string MenuPos => Scrapper.GetString(SectionKey, "menu.pos");
            public static string MenuItemFont => Scrapper.GetString(SectionKey, "menu.item.font");
            public static string MenuItemActiveFont => Scrapper.GetString(SectionKey, "menu.item.active.font");
            public static string MenuItemSpacing => Scrapper.GetString(SectionKey, "menu.item.spacing");
            public static string MenuItemNameArcade => Scrapper.GetString(SectionKey, "menu.itemname.arcade");
            public static string MenuItemNameVersus => Scrapper.GetString(SectionKey, "menu.itemname.versus");
            public static string MenuItemNameTeamArcade => Scrapper.GetString(SectionKey, "menu.itemname.teamarcade");
            public static string MenuItemNameTeamVersus => Scrapper.GetString(SectionKey, "menu.itemname.teamversus");
            public static string MenuItemNameTeamCoop => Scrapper.GetString(SectionKey, "menu.itemname.teamcoop");
            public static string MenuItemNameSurvival => Scrapper.GetString(SectionKey, "menu.itemname.survival");

            public static string MenuItemNameSurvivalCoop =>
                Scrapper.GetString(SectionKey, "menu.itemname.survivalcoop");

            public static string MenuItemNameTraining => Scrapper.GetString(SectionKey, "menu.itemname.training");
            public static string MenuItemNameWatch => Scrapper.GetString(SectionKey, "menu.itemname.watch");
            public static string MenuItemNameOptions => Scrapper.GetString(SectionKey, "menu.itemname.options");
            public static string MenuItemNameExit => Scrapper.GetString(SectionKey, "menu.itemname.exit");
            public static string MenuWindowMarginsY => Scrapper.GetString(SectionKey, "menu.window.margins.y");
            public static int MenuWindowVisibleItems => Scrapper.GetInt(SectionKey, "menu.window.visibleitems");

            /// <summary>
            /// Set it to true to enable default cursor display.
            /// Set it to false to disable default cursor display.
            /// </summary>
            public static bool IsMenuBoxCursorVisible => Scrapper.GetBoolean(SectionKey, "menu.boxcursor.visible");

            public static string MenuBoxCursorCoords => Scrapper.GetString(SectionKey, "menu.boxcursor.coords");
            public static string CursorMoveSound => Scrapper.GetString(SectionKey, "cursor.move.snd");
            public static string CursorDoneSound => Scrapper.GetString(SectionKey, "cursor.done.snd");
            public static string CancelSound => Scrapper.GetString(SectionKey, "cancel.snd");
        }

        public static class TitleBgDef // TODO: Enumerable inside
        {
            public const string SectionKey = "TitleBGdef";
        }

        public static class Infobox // TODO: What is this ??? Get an example
        {
            public const string SectionKey = "Infobox";
        }

        public static class SelectInfo
        {
            public const string SectionKey = "Select Info";

            public static int FadeInTime => Scrapper.GetInt(SectionKey, "fadein.time");
            public static int FadeOutTime => Scrapper.GetInt(SectionKey, "fadeout.time");
            public static int Rows => Scrapper.GetInt(SectionKey, "rows");
            public static int Columns => Scrapper.GetInt(SectionKey, "columns");

            /// <summary>
            /// Values:
            /// 0 - default
            /// 1 - cursor wraps around
            /// </summary>
            public static int Wrapping => Scrapper.GetInt(SectionKey, "wrapping");

            /// <summary>
            /// Position to draw to.
            /// </summary>
            public static string Pos => Scrapper.GetString(SectionKey, "pos");

            public static bool ShowEmptyBoxes => Scrapper.GetBoolean(SectionKey, "showemptyboxes");
            public static bool CanMoveOverEmptyBoxes => Scrapper.GetBoolean(SectionKey, "moveoveremptyboxes");

            /// <summary>
            /// (x,y) size of each cell in pixels.
            /// </summary>
            public static string CellSize => Scrapper.GetString(SectionKey, "cell.size");

            /// <summary>
            /// Space between each cell.
            /// </summary>
            public static int CellSpacing => Scrapper.GetInt(SectionKey, "cell.spacing");

            public static string CellBgSpr => Scrapper.GetString(SectionKey, "cell.bg.spr");

            /// <summary>
            /// Icon for random select.
            /// </summary>
            public static string CellRandomSpr => Scrapper.GetString(SectionKey, "cell.random.spr");

            /// <summary>
            /// Time to wait before changing to another random portrait.
            /// </summary>
            public static string CellRandomSwitchTime => Scrapper.GetString(SectionKey, "cell.random.switchtime");

            /// <summary>
            /// Player 1 selection.
            /// </summary>
            public static IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection(SectionKey, "p1");

            /// <summary>
            /// Player 2 selection.
            /// </summary>
            public static IPlayerSelectionEntry Player2 => Scrapper.GetPlayerSelection(SectionKey, "p2");

            public static IMovementEntry Random => Scrapper.GetMovement(SectionKey, "random");
            public static IMovementEntry Stage => Scrapper.GetMovement(SectionKey, "stage");
            public static ISpriteSoundEntry Cancel => Scrapper.GetSpriteSound(SectionKey, "cancel");
            public static IImageEntry Portrait => Scrapper.GetImage(SectionKey, "portrait");
            public static ITextEntry Title => Scrapper.GetText(SectionKey, "title");
        }

        public static class SelectBgDef // TODO: Enumerable inside
        {
            public const string SectionKey = "SelectBGdef";
        }

        public static class VsScreen // TODO: Enumerable inside
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

        public static class VictoryScreen // TODO: Enumerable inside
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

        public static class OptionInfo // TODO: Enumerable inside
        {
            public const string SectionKey = "Optio nInfo";
        }
    }
}