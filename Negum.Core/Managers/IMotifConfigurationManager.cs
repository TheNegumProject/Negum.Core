using System;
using Negum.Core.Containers;
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
    public interface IMotifConfigurationManager : IConfigurationManager<IMotifConfigurationManager>
    {
        public IMotifConfigurationInfo Info =>
            NegumContainer.Resolve<IMotifConfigurationInfo>().Setup(this.Scrapper.ForSection("Info"));

        public IMotifConfigurationFiles Files =>
            NegumContainer.Resolve<IMotifConfigurationFiles>().Setup(this.Scrapper.ForSection("Files"));

        public IMotifConfigurationMusic Music =>
            NegumContainer.Resolve<IMotifConfigurationMusic>().Setup(this.Scrapper.ForSection("Music"));

        public IMotifConfigurationTitleInfo TitleInfo =>
            NegumContainer.Resolve<IMotifConfigurationTitleInfo>().Setup(this.Scrapper.ForSection("Title Info"));

        public IMotifConfigurationTitleBgDef TitleBgDef =>
            NegumContainer.Resolve<IMotifConfigurationTitleBgDef>().Setup(this.Scrapper.ForSection("TitleBGdef"));

        public IMotifConfigurationInfobox Infobox =>
            NegumContainer.Resolve<IMotifConfigurationInfobox>().Setup(this.Scrapper.ForSection("Infobox"));

        public IMotifConfigurationSelectInfo SelectInfo =>
            NegumContainer.Resolve<IMotifConfigurationSelectInfo>().Setup(this.Scrapper.ForSection("Select Info"));

        public IMotifConfigurationSelectBgDef SelectBgDef =>
            NegumContainer.Resolve<IMotifConfigurationSelectBgDef>().Setup(this.Scrapper.ForSection("SelectBGdef"));

        public IMotifConfigurationVsScreen VsScreen =>
            NegumContainer.Resolve<IMotifConfigurationVsScreen>().Setup(this.Scrapper.ForSection("VS Screen"));

        public IMotifConfigurationVsBgDef VsBgDef =>
            NegumContainer.Resolve<IMotifConfigurationVsBgDef>().Setup(this.Scrapper.ForSection("VersusBGdef"));

        public IMotifConfigurationDemoMode DemoMode =>
            NegumContainer.Resolve<IMotifConfigurationDemoMode>().Setup(this.Scrapper.ForSection("Demo Mode"));

        public IMotifConfigurationContinueScreen ContinueScreen =>
            NegumContainer.Resolve<IMotifConfigurationContinueScreen>()
                .Setup(this.Scrapper.ForSection("Continue Screen"));

        public IMotifConfigurationGameOverScreen GameOverScreen =>
            NegumContainer.Resolve<IMotifConfigurationGameOverScreen>()
                .Setup(this.Scrapper.ForSection("Game Over Screen"));

        public IMotifConfigurationVictoryScreen VictoryScreen =>
            NegumContainer.Resolve<IMotifConfigurationVictoryScreen>()
                .Setup(this.Scrapper.ForSection("Victory Screen"));

        public IMotifConfigurationWinScreen WinScreen =>
            NegumContainer.Resolve<IMotifConfigurationWinScreen>().Setup(this.Scrapper.ForSection("Win Screen"));

        public IMotifConfigurationDefaultEnding DefaultEnding =>
            NegumContainer.Resolve<IMotifConfigurationDefaultEnding>()
                .Setup(this.Scrapper.ForSection("Default Ending"));

        public IMotifConfigurationEndCredits EndCredits =>
            NegumContainer.Resolve<IMotifConfigurationEndCredits>().Setup(this.Scrapper.ForSection("End Credits"));

        public IMotifConfigurationSurvivalResultsScreen SurvivalResultsScreen =>
            NegumContainer.Resolve<IMotifConfigurationSurvivalResultsScreen>()
                .Setup(this.Scrapper.ForSection("Survival Results Screen"));

        public IMotifConfigurationOptionInfo OptionInfo =>
            NegumContainer.Resolve<IMotifConfigurationOptionInfo>().Setup(this.Scrapper.ForSection("Option Info"));
    }

    public interface IMotifConfigurationInfo : IConfigurationManagerSection<IMotifConfigurationInfo>
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
        DateTime VersionDate => Scrapper.GetDate("versiondate");

        /// <summary>
        /// Version of motif.
        /// </summary>
        float Version => Scrapper.GetFloat("mugenversion");
    }

    public interface IMotifConfigurationFiles : IConfigurationManagerSection<IMotifConfigurationFiles>
    {
        /// <summary>
        /// Filename of sprite data.
        /// </summary>
        IFileEntry Sprite => Scrapper.GetFile("spr");

        /// <summary>
        /// Filename of sound data.
        /// </summary>
        IFileEntry Sound => Scrapper.GetFile("snd");

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
        IFileEntry Selection => Scrapper.GetFile("select");

        /// <summary>
        /// Fight definition filename.
        /// </summary>
        IFileEntry Fight => Scrapper.GetFile("fight");

        /// <summary>
        /// System fonts.
        /// </summary>
        IEntryCollection<IFileEntry> Fonts => Scrapper.GetCollection<IFileEntry>("font");
    }

    public interface IMotifConfigurationMusic : IConfigurationManagerSection<IMotifConfigurationMusic>
    {
        /// <summary>
        /// Music to play at title screen.
        /// </summary>
        IAudioEntry Title => Scrapper.GetAudio("title.bgm");

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

    public interface IMotifConfigurationTitleInfo : IConfigurationManagerSection<IMotifConfigurationTitleInfo>
    {
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        IPositionEntry MenuPos => Scrapper.GetPosition("menu.pos");
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
        IPositionEntry MenuWindowMarginsY => Scrapper.GetPosition("menu.window.margins.y");
        int MenuWindowVisibleItems => Scrapper.GetInt("menu.window.visibleitems");

        /// <summary>
        /// Set it to true to enable default cursor display.
        /// Set it to false to disable default cursor display.
        /// </summary>
        bool IsMenuBoxCursorVisible => Scrapper.GetBoolean("menu.boxcursor.visible");

        IBoxEntry MenuBoxCursorCoords => Scrapper.GetBox("menu.boxcursor.coords");
        IMovementEntry Cursor => Scrapper.GetMovement("cursor");
        ISpriteSoundEntry Cancel => Scrapper.GetSpriteSound("cancel");
    }

    public interface IMotifConfigurationTitleBgDef : IConfigurationManagerSection<IMotifConfigurationTitleBgDef>
    {
        // TODO: Enumerable inside
    }

    public interface IMotifConfigurationInfobox : IConfigurationManagerSection<IMotifConfigurationInfobox>
    {
        // TODO: What is this ??? Get an example
    }

    public interface IMotifConfigurationSelectInfo : IConfigurationManagerSection<IMotifConfigurationSelectInfo>
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
        IPositionEntry Pos => Scrapper.GetPosition("pos");

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

    public interface IMotifConfigurationSelectBgDef : IConfigurationManagerSection<IMotifConfigurationSelectBgDef>
    {
        // TODO: Enumerable inside
    }

    public interface IMotifConfigurationVsScreen : IConfigurationManagerSection<IMotifConfigurationVsScreen>
    {
        ITimeEntry Time => Scrapper.GetTime("time");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        ITextEntry Match => Scrapper.GetText("match");
        IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection("p1");
        IPlayerSelectionEntry Player2 => Scrapper.GetPlayerSelection("p2");
    }

    public interface IMotifConfigurationVsBgDef : IConfigurationManagerSection<IMotifConfigurationVsBgDef>
    {
        // TODO: Enumerable inside
    }

    public interface IMotifConfigurationDemoMode : IConfigurationManagerSection<IMotifConfigurationDemoMode>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITimeEntry WaitTime => Scrapper.GetTime("title.waittime");
        IDemoModeFightEntry Fight => Scrapper.GetDemoModeFight("fight");
        int IntroWaitCycles => Scrapper.GetInt("intro.waitcycles");
        bool ShowDebugInfo => Scrapper.GetBoolean("debuginfo");
    }

    public interface IMotifConfigurationContinueScreen : IConfigurationManagerSection<IMotifConfigurationContinueScreen>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IPositionEntry Position => Scrapper.GetPosition("pos");
        ITextEntry ContinueText => Scrapper.GetText("continue");
        ITextEntry YesText => Scrapper.GetText("yes");
        ITextEntry YesActiveText => Scrapper.GetText("yes.active");
        ITextEntry NoText => Scrapper.GetText("no");
        ITextEntry NoActiveText => Scrapper.GetText("no.active");
    }

    public interface IMotifConfigurationGameOverScreen : IConfigurationManagerSection<IMotifConfigurationGameOverScreen>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IFileEntry Storyboard => Scrapper.GetFile("storyboard");
    }

    public interface IMotifConfigurationVictoryScreen : IConfigurationManagerSection<IMotifConfigurationVictoryScreen>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITimeEntry Time => Scrapper.GetTime("time");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        IPlayerSelectionEntry Player1 => Scrapper.GetPlayerSelection("p1");
        ITextEntry WinQuote => Scrapper.GetText("winquote");
    }

    public interface IMotifConfigurationWinScreen : IConfigurationManagerSection<IMotifConfigurationWinScreen>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        ITextEntry WinText => Scrapper.GetText("wintext");
        ITimeEntry FadeInTime => Scrapper.GetTime("fadein.time");
        ITimeEntry FadeOutTime => Scrapper.GetTime("fadeout.time");
        ITimeEntry PoseTime => Scrapper.GetTime("pos.time");
    }

    public interface IMotifConfigurationDefaultEnding : IConfigurationManagerSection<IMotifConfigurationDefaultEnding>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IFileEntry Storyboard => Scrapper.GetFile("storyboard");
    }

    public interface IMotifConfigurationEndCredits : IConfigurationManagerSection<IMotifConfigurationEndCredits>
    {
        bool IsEnabled => Scrapper.GetBoolean("enabled");
        IFileEntry Storyboard => Scrapper.GetFile("storyboard");
    }

    public interface
        IMotifConfigurationSurvivalResultsScreen : IConfigurationManagerSection<IMotifConfigurationSurvivalResultsScreen
        >
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

    public interface IMotifConfigurationOptionInfo : IConfigurationManagerSection<IMotifConfigurationOptionInfo>
    {
        // TODO: Enumerable inside
    }
}