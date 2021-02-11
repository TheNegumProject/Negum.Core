using System.Collections.Generic;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Motif configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMotifConfigurationManager : IConfigurationManager
    {
        IMotifConfigurationInfo Info => this.GetSection<IMotifConfigurationInfo>("Info");
        IMotifConfigurationFiles Files => this.GetSection<IMotifConfigurationFiles>("Files");
        IMotifConfigurationMusic Music => this.GetSection<IMotifConfigurationMusic>("Music");
        IMotifConfigurationTitleInfo TitleInfo => this.GetSection<IMotifConfigurationTitleInfo>("Title Info");
        IMotifConfigurationScreenBgDef TitleBgDef => this.GetSection<IMotifConfigurationScreenBgDef>("TitleBGdef");
        IEnumerable<IMotifConfigurationScreenBg> TitleBgs => this.GetSections<IMotifConfigurationScreenBg>("TitleBG ");
        IMotifConfigurationInfobox Infobox => this.GetSection<IMotifConfigurationInfobox>("Infobox");
        IMotifConfigurationSelectInfo SelectInfo => this.GetSection<IMotifConfigurationSelectInfo>("Select Info");
        IMotifConfigurationScreenBgDef SelectBgDef => this.GetSection<IMotifConfigurationScreenBgDef>("SelectBGdef");

        IEnumerable<IMotifConfigurationScreenBg> SelectBgs =>
            this.GetSections<IMotifConfigurationScreenBg>("SelectBG ");

        IMotifConfigurationVsScreen VsScreen => this.GetSection<IMotifConfigurationVsScreen>("VS Screen");
        IMotifConfigurationScreenBgDef VersusBgDef => this.GetSection<IMotifConfigurationScreenBgDef>("VersusBGdef");

        IEnumerable<IMotifConfigurationScreenBg> VersusBgs =>
            this.GetSections<IMotifConfigurationScreenBg>("VersusBG ");

        IMotifConfigurationDemoMode DemoMode => this.GetSection<IMotifConfigurationDemoMode>("Demo Mode");

        IMotifConfigurationContinueScreen ContinueScreen =>
            this.GetSection<IMotifConfigurationContinueScreen>("Continue Screen");

        IMotifConfigurationGameOverScreen GameOverScreen =>
            this.GetSection<IMotifConfigurationGameOverScreen>("Game Over Screen");

        IMotifConfigurationVictoryScreen VictoryScreen =>
            this.GetSection<IMotifConfigurationVictoryScreen>("Victory Screen");

        IMotifConfigurationScreenBgDef VictoryBgDef => this.GetSection<IMotifConfigurationScreenBgDef>("VictoryBGdef");

        IEnumerable<IMotifConfigurationScreenBg> VictoryBgs =>
            this.GetSections<IMotifConfigurationScreenBg>("VictoryBG ");

        IMotifConfigurationWinScreen WinScreen => this.GetSection<IMotifConfigurationWinScreen>("Win Screen");

        IMotifConfigurationDefaultEnding DefaultEnding =>
            this.GetSection<IMotifConfigurationDefaultEnding>("Default Ending");

        IMotifConfigurationEndCredits EndCredits => this.GetSection<IMotifConfigurationEndCredits>("End Credits");

        IMotifConfigurationSurvivalResultsScreen SurvivalResultsScreen =>
            this.GetSection<IMotifConfigurationSurvivalResultsScreen>("Survival Results Screen");

        IMotifConfigurationScreenBgDef OptionInfo => this.GetSection<IMotifConfigurationScreenBgDef>("Option Info");

        IEnumerable<IMotifConfigurationScreenBg> OptionBgs =>
            this.GetSections<IMotifConfigurationScreenBg>("OptionBG ");
    }

    public interface IMotifConfigurationScreenBgDef : IConfigurationManagerSection
    {
        IFileEntry SpriteFile => Scrapper.GetFile("spr");
        IVectorEntry BgClearColor => Scrapper.GetVector("bgclearcolor");
    }

    public interface IMotifConfigurationInfo : IConfigurationManagerSection
    {
        /// <summary>
        /// Name of motif.
        /// </summary>
        string Name => Scrapper.GetString("name");

        /// <summary>
        /// Motif author name.
        /// </summary>
        string Author => Scrapper.GetString("author");

        /// <summary>
        /// Version date of motif.
        /// </summary>
        ITimeEntry VersionDate => Scrapper.GetTime("versiondate");

        /// <summary>
        /// Version of motif.
        /// </summary>
        float Version => Scrapper.GetFloat("mugenversion");
    }

    public interface IMotifConfigurationFiles : IConfigurationManagerSection
    {
        /// <summary>
        /// Filename of sprite data.
        /// </summary>
        IFileEntry SpriteFile => Scrapper.GetFile("spr");

        /// <summary>
        /// Filename of sound data.
        /// </summary>
        IFileEntry SoundFile => Scrapper.GetFile("snd");

        /// <summary>
        /// Logo storyboard definition (optional).
        /// </summary>
        string LogoStoryboardDefinition => Scrapper.GetString("logo.storyboard");

        /// <summary>
        /// Intro storyboard definition (optional).
        /// </summary>
        string IntroStoryboardDefinition => Scrapper.GetString("intro.storyboard");

        /// <summary>
        /// Character and stage selection list.
        /// </summary>
        IFileEntry SelectionFile => Scrapper.GetFile("select");

        /// <summary>
        /// Fight definition filename.
        /// </summary>
        IFileEntry FightFile => Scrapper.GetFile("fight");

        /// <summary>
        /// System fonts.
        /// </summary>
        IEntryCollection<IFileEntry> FontFiles => Scrapper.GetCollection<IFileEntry>("font");
    }

    public interface IMotifConfigurationMusic : IConfigurationManagerSection
    {
        /// <summary>
        /// Music to play at title screen.
        /// </summary>
        IFileEntry TitleMusicFile => Scrapper.GetFile("title.bgm");

        /// <summary>
        /// Music to play at char select screen.
        /// </summary>
        IAudioEntry Select => Scrapper.GetAudio("select.bgm");

        /// <summary>
        /// Music to play at versus screen.
        /// </summary>
        IAudioEntry Vs => Scrapper.GetAudio("vs.bgm");

        /// <summary>
        /// Music to play at victory screen.
        /// </summary>
        IAudioEntry Victory => Scrapper.GetAudio("victory.bgm");
    }

    public interface IMotifConfigurationTitleInfo : IConfigurationManagerSection
    {
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        IVectorEntry MenuPosition => Scrapper.GetVector("menu.pos");
        ITextEntry MenuItem => Scrapper.GetText("menu.item");
        ITextEntry MenuItemActive => Scrapper.GetText("menu.item.active");
        string MenuItemNameArcade => Scrapper.GetString("menu.itemname.arcade");
        string MenuItemNameVersus => Scrapper.GetString("menu.itemname.versus");
        string MenuItemNameTeamArcade => Scrapper.GetString("menu.itemname.teamarcade");
        string MenuItemNameTeamVersus => Scrapper.GetString("menu.itemname.teamversus");
        string MenuItemNameTeamCoop => Scrapper.GetString("menu.itemname.teamcoop");
        string MenuItemNameSurvival => Scrapper.GetString("menu.itemname.survival");

        string MenuItemNameSurvivalCoop =>
            Scrapper.GetString("menu.itemname.survivalcoop");

        string MenuItemNameTraining => Scrapper.GetString("menu.itemname.training");
        string MenuItemNameWatch => Scrapper.GetString("menu.itemname.watch");
        string MenuItemNameOptions => Scrapper.GetString("menu.itemname.options");
        string MenuItemNameExit => Scrapper.GetString("menu.itemname.exit");
        IVectorEntry MenuWindowMarginsY => Scrapper.GetVector("menu.window.margins.y");
        int MenuWindowVisibleItems => Scrapper.GetInt("menu.window.visibleitems");

        /// <summary>
        /// Set it to true to enable default cursor display.
        /// Set it to false to disable default cursor display.
        /// </summary>
        bool IsMenuBoxCursorVisible => Scrapper.GetBoolean("menu.boxcursor.visible");

        IVectorEntry MenuBoxCursorCoords => Scrapper.GetVector("menu.boxcursor.coords");
        IMovementEntry Cursor => Scrapper.GetMovement("cursor");
        ISpriteSoundEntry Cancel => Scrapper.GetSpriteSound("cancel");
    }

    public interface IMotifConfigurationScreenBg : IConfigurationManagerSection
    {
        string Type => Scrapper.GetString("type");
        IVectorEntry SpriteNumber => Scrapper.GetVector("spriteno");
        int LayerNumber => Scrapper.GetInt("layerno");
        IVectorEntry Start => Scrapper.GetVector("start");
        IVectorEntry Tile => Scrapper.GetVector("tile");
        IVectorEntry Velocity => Scrapper.GetVector("velocity");
        IVectorEntry Window => Scrapper.GetVector("window");
        string Trans => Scrapper.GetString("trans");
        int Mask => Scrapper.GetInt("mask");
        IVectorEntry Delta => Scrapper.GetVector("delta");
    }

    public interface IMotifConfigurationInfobox : IConfigurationManagerSection
    {
        // TODO: What is this ??? Get an example
    }

    public interface IMotifConfigurationSelectInfo : IConfigurationManagerSection
    {
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        int Rows => Scrapper.GetInt("rows");
        int Columns => Scrapper.GetInt("columns");

        /// <summary>
        /// Values:
        /// 0 - default
        /// 1 - cursor wraps around
        /// </summary>
        int Wrapping => Scrapper.GetInt("wrapping");

        /// <summary>
        /// Position to draw to.
        /// </summary>
        IVectorEntry Position => Scrapper.GetVector("pos");

        bool ShowEmptyBoxes => Scrapper.GetBoolean("showemptyboxes");
        bool CanMoveOverEmptyBoxes => Scrapper.GetBoolean("moveoveremptyboxes");

        ICellSelectionEntry Cell => Scrapper.GetCell("cell");

        /// <summary>
        /// Player 1 selection.
        /// </summary>
        IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection("p1");

        /// <summary>
        /// Player 2 selection.
        /// </summary>
        IPlayerSelectionEntry Player2 => Scrapper.GetPlayerSelection("p2");

        IMovementEntry Random => Scrapper.GetMovement("random");
        ISpriteSoundEntry Cancel => Scrapper.GetSpriteSound("cancel");
        IImageEntry Portrait => Scrapper.GetImage("portrait");
        ITextEntry Title => Scrapper.GetText("title");
        IStageSelectionEntry Stage => Scrapper.GetStage("stage");
        bool TeamMenuMoveWrapping => Scrapper.GetBoolean("teammenu.move.wrapping");
    }

    public interface IMotifConfigurationVsScreen : IConfigurationManagerSection
    {
        ITimeEntry Time => Scrapper.GetTime("time");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        ITextEntry Match => Scrapper.GetText("match");
        IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection("p1");
        IPlayerSelectionEntry Player2 => Scrapper.GetPlayerSelection("p2");
    }

    public interface IMotifConfigurationDemoMode : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITimeEntry WaitTime => Scrapper.GetTime("title.waittime");
        IDemoModeFightEntry Fight => Scrapper.GetDemoModeFight("fight");
        int IntroWaitCycles => Scrapper.GetInt("intro.waitcycles");
        bool ShowDebugInfo => Scrapper.GetBoolean("debuginfo");
    }

    public interface IMotifConfigurationContinueScreen : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IVectorEntry Position => Scrapper.GetVector("pos");
        ITextEntry ContinueText => Scrapper.GetText("continue");
        ITextEntry YesText => Scrapper.GetText("yes");
        ITextEntry YesActiveText => Scrapper.GetText("yes.active");
        ITextEntry NoText => Scrapper.GetText("no");
        ITextEntry NoActiveText => Scrapper.GetText("no.active");
    }

    public interface IMotifConfigurationGameOverScreen : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IFileEntry StoryboardFile => Scrapper.GetFile("storyboard");
    }

    public interface IMotifConfigurationVictoryScreen : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITimeEntry Time => Scrapper.GetTime("time");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection("p1");
        ITextEntry WinQuote => Scrapper.GetText("winquote");
    }

    public interface IMotifConfigurationWinScreen : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITextEntry WinText => Scrapper.GetText("wintext");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        ITimeEntry PoseTime => Scrapper.GetTime("pos.time");
    }

    public interface IMotifConfigurationDefaultEnding : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IFileEntry StoryboardFile => Scrapper.GetFile("storyboard");
    }

    public interface IMotifConfigurationEndCredits : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IFileEntry StoryboardFile => Scrapper.GetFile("storyboard");
    }

    public interface IMotifConfigurationSurvivalResultsScreen : IConfigurationManagerSection
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITextEntry WinText => Scrapper.GetText("wintext");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        ITimeEntry ShowTime => Scrapper.GetTime("show.time");

        /// <summary>
        /// Number of rounds to get win pose (lose pose otherwise).
        /// </summary>
        int RoundsToWin => Scrapper.GetInt("roundstowin");
    }
}