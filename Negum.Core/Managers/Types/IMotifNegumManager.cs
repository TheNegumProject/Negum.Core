using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Motif configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMotifNegumManager : INegumManager
    {
        IMotifNegumInfo Info => this.GetSection<IMotifNegumInfo>("Info");
        IMotifNegumFiles Files => this.GetSection<IMotifNegumFiles>("Files");
        IMotifNegumMusic Music => this.GetSection<IMotifNegumMusic>("Music");
        IMotifNegumTitleInfo TitleInfo => this.GetSection<IMotifNegumTitleInfo>("Title Info");
        IMotifNegumScreenBgDef TitleBgDef => this.GetSection<IMotifNegumScreenBgDef>("TitleBGdef");
        IEnumerable<IMotifNegumScreenBg> TitleBgs => this.GetSections<IMotifNegumScreenBg>("TitleBG ");
        IMotifNegumInfobox Infobox => this.GetSection<IMotifNegumInfobox>("Infobox");
        IMotifNegumSelectInfo SelectInfo => this.GetSection<IMotifNegumSelectInfo>("Select Info");
        IMotifNegumScreenBgDef SelectBgDef => this.GetSection<IMotifNegumScreenBgDef>("SelectBGdef");

        IEnumerable<IMotifNegumScreenBg> SelectBgs =>
            this.GetSections<IMotifNegumScreenBg>("SelectBG ");

        IMotifNegumVsScreen VsScreen => this.GetSection<IMotifNegumVsScreen>("VS Screen");
        IMotifNegumScreenBgDef VersusBgDef => this.GetSection<IMotifNegumScreenBgDef>("VersusBGdef");

        IEnumerable<IMotifNegumScreenBg> VersusBgs =>
            this.GetSections<IMotifNegumScreenBg>("VersusBG ");

        IMotifNegumDemoMode DemoMode => this.GetSection<IMotifNegumDemoMode>("Demo Mode");

        IMotifNegumContinueScreen ContinueScreen =>
            this.GetSection<IMotifNegumContinueScreen>("Continue Screen");

        IMotifNegumGameOverScreen GameOverScreen =>
            this.GetSection<IMotifNegumGameOverScreen>("Game Over Screen");

        IMotifNegumVictoryScreen VictoryScreen =>
            this.GetSection<IMotifNegumVictoryScreen>("Victory Screen");

        IMotifNegumScreenBgDef VictoryBgDef => this.GetSection<IMotifNegumScreenBgDef>("VictoryBGdef");

        IEnumerable<IMotifNegumScreenBg> VictoryBgs =>
            this.GetSections<IMotifNegumScreenBg>("VictoryBG ");

        IMotifNegumWinScreen WinScreen => this.GetSection<IMotifNegumWinScreen>("Win Screen");

        IMotifNegumDefaultEnding DefaultEnding =>
            this.GetSection<IMotifNegumDefaultEnding>("Default Ending");

        IMotifNegumEndCredits EndCredits => this.GetSection<IMotifNegumEndCredits>("End Credits");

        IMotifNegumSurvivalResultsScreen SurvivalResultsScreen =>
            this.GetSection<IMotifNegumSurvivalResultsScreen>("Survival Results Screen");

        IMotifNegumScreenBgDef OptionInfo => this.GetSection<IMotifNegumScreenBgDef>("Option Info");

        IEnumerable<IMotifNegumScreenBg> OptionBgs =>
            this.GetSections<IMotifNegumScreenBg>("OptionBG ");
    }

    public interface IMotifNegumScreenBgDef : INegumManagerSection
    {
        IFileEntry SpriteFile => this.GetValue<IFileEntry>("spr");
        IVectorEntry BgClearColor => this.GetValue<IVectorEntry>("bgclearcolor");
    }

    public interface IMotifNegumInfo : INegumManagerSection
    {
        /// <summary>
        /// Name of motif.
        /// </summary>
        string Name => this.GetValue<string>("name");

        /// <summary>
        /// Motif author name.
        /// </summary>
        string Author => this.GetValue<string>("author");

        /// <summary>
        /// Version date of motif.
        /// </summary>
        ITimeEntry VersionDate => this.GetValue<ITimeEntry>("versiondate");

        /// <summary>
        /// Version of motif.
        /// </summary>
        float Version => this.GetValue<float>("mugenversion");
    }

    public interface IMotifNegumFiles : INegumManagerSection
    {
        /// <summary>
        /// Filename of sprite data.
        /// </summary>
        IFileEntry SpriteFile => this.GetValue<IFileEntry>("spr");

        /// <summary>
        /// Filename of sound data.
        /// </summary>
        IFileEntry SoundFile => this.GetValue<IFileEntry>("snd");

        /// <summary>
        /// Logo storyboard definition (optional).
        /// </summary>
        string LogoStoryboardDefinition => this.GetValue<string>("logo.storyboard");

        /// <summary>
        /// Intro storyboard definition (optional).
        /// </summary>
        string IntroStoryboardDefinition => this.GetValue<string>("intro.storyboard");

        /// <summary>
        /// Character and stage selection list.
        /// </summary>
        IFileEntry SelectionFile => this.GetValue<IFileEntry>("select");

        /// <summary>
        /// Fight definition filename.
        /// </summary>
        IFileEntry FightFile => this.GetValue<IFileEntry>("fight");

        /// <summary>
        /// System fonts.
        /// </summary>
        IEntryCollection<IFileEntry> FontFiles => Scrapper.GetCollection<IFileEntry>("font");
    }

    public interface IMotifNegumMusic : INegumManagerSection
    {
        /// <summary>
        /// Music to play at title screen.
        /// </summary>
        IFileEntry TitleMusicFile => this.GetValue<IFileEntry>("title.bgm");

        /// <summary>
        /// Music to play at char select screen.
        /// </summary>
        IAudioEntry Select => this.GetValue<IAudioEntry>("select.bgm");

        /// <summary>
        /// Music to play at versus screen.
        /// </summary>
        IAudioEntry Vs => this.GetValue<IAudioEntry>("vs.bgm");

        /// <summary>
        /// Music to play at victory screen.
        /// </summary>
        IAudioEntry Victory => this.GetValue<IAudioEntry>("victory.bgm");
    }

    public interface IMotifNegumTitleInfo : INegumManagerSection
    {
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        IVectorEntry MenuPosition => this.GetValue<IVectorEntry>("menu.pos");
        ITextEntry MenuItem => this.GetValue<ITextEntry>("menu.item");
        ITextEntry MenuItemActive => this.GetValue<ITextEntry>("menu.item.active");
        string MenuItemNameArcade => this.GetValue<string>("menu.itemname.arcade");
        string MenuItemNameVersus => this.GetValue<string>("menu.itemname.versus");
        string MenuItemNameTeamArcade => this.GetValue<string>("menu.itemname.teamarcade");
        string MenuItemNameTeamVersus => this.GetValue<string>("menu.itemname.teamversus");
        string MenuItemNameTeamCoop => this.GetValue<string>("menu.itemname.teamcoop");
        string MenuItemNameSurvival => this.GetValue<string>("menu.itemname.survival");
        string MenuItemNameSurvivalCoop => this.GetValue<string>("menu.itemname.survivalcoop");
        string MenuItemNameTraining => this.GetValue<string>("menu.itemname.training");
        string MenuItemNameWatch => this.GetValue<string>("menu.itemname.watch");
        string MenuItemNameOptions => this.GetValue<string>("menu.itemname.options");
        string MenuItemNameExit => this.GetValue<string>("menu.itemname.exit");
        IVectorEntry MenuWindowMarginsY => this.GetValue<IVectorEntry>("menu.window.margins.y");
        int MenuWindowVisibleItems => this.GetValue<int>("menu.window.visibleitems");

        /// <summary>
        /// Set it to true to enable default cursor display.
        /// Set it to false to disable default cursor display.
        /// </summary>
        bool IsMenuBoxCursorVisible => this.GetValue<bool>("menu.boxcursor.visible");

        IVectorEntry MenuBoxCursorCoords => this.GetValue<IVectorEntry>("menu.boxcursor.coords");
        IMovementEntry Cursor => this.GetValue<IMovementEntry>("cursor");
        ISpriteSoundEntry Cancel => this.GetValue<ISpriteSoundEntry>("cancel");
    }

    public interface IMotifNegumScreenBg : INegumManagerSection
    {
        string Type => this.GetValue<string>("type");
        IVectorEntry SpriteNumber => this.GetValue<IVectorEntry>("spriteno");
        int LayerNumber => this.GetValue<int>("layerno");
        IVectorEntry Start => this.GetValue<IVectorEntry>("start");
        IVectorEntry Tile => this.GetValue<IVectorEntry>("tile");
        IVectorEntry Velocity => this.GetValue<IVectorEntry>("velocity");
        IVectorEntry Window => this.GetValue<IVectorEntry>("window");
        string Trans => this.GetValue<string>("trans");
        int Mask => this.GetValue<int>("mask");
        IVectorEntry Delta => this.GetValue<IVectorEntry>("delta");
    }

    public interface IMotifNegumInfobox : INegumManagerSection
    {
        // TODO: What is this ??? Get an example
    }

    public interface IMotifNegumSelectInfo : INegumManagerSection
    {
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        int Rows => this.GetValue<int>("rows");
        int Columns => this.GetValue<int>("columns");

        /// <summary>
        /// Values:
        /// 0 - default
        /// 1 - cursor wraps around
        /// </summary>
        int Wrapping => this.GetValue<int>("wrapping");

        /// <summary>
        /// Position to draw to.
        /// </summary>
        IVectorEntry Position => this.GetValue<IVectorEntry>("pos");

        bool ShowEmptyBoxes => this.GetValue<bool>("showemptyboxes");
        bool CanMoveOverEmptyBoxes => this.GetValue<bool>("moveoveremptyboxes");
        ICellSelectionEntry Cell => this.GetValue<ICellSelectionEntry>("cell");

        /// <summary>
        /// Player 1 selection.
        /// </summary>
        IPlayerSelectionEntry Player1 => this.GetValue<IPlayerSelectionEntry>("p1");

        /// <summary>
        /// Player 2 selection.
        /// </summary>
        IPlayerSelectionEntry Player2 => this.GetValue<IPlayerSelectionEntry>("p2");

        IMovementEntry Random => this.GetValue<IMovementEntry>("random");
        ISpriteSoundEntry Cancel => this.GetValue<ISpriteSoundEntry>("cancel");
        IImageEntry Portrait => this.GetValue<IImageEntry>("portrait");
        ITextEntry Title => this.GetValue<ITextEntry>("title");
        IStageSelectionEntry Stage => this.GetValue<IStageSelectionEntry>("stage");
        bool TeamMenuMoveWrapping => this.GetValue<bool>("teammenu.move.wrapping");
    }

    public interface IMotifNegumVsScreen : INegumManagerSection
    {
        ITimeEntry Time => this.GetValue<ITimeEntry>("time");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        ITextEntry Match => this.GetValue<ITextEntry>("match");
        IPlayerSelectionEntry Player1 => this.GetValue<IPlayerSelectionEntry>("p1");
        IPlayerSelectionEntry Player2 => this.GetValue<IPlayerSelectionEntry>("p2");
    }

    public interface IMotifNegumDemoMode : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITimeEntry WaitTime => this.GetValue<ITimeEntry>("title.waittime");
        IDemoModeFightEntry Fight => this.GetValue<IDemoModeFightEntry>("fight");
        int IntroWaitCycles => this.GetValue<int>("intro.waitcycles");
        bool ShowDebugInfo => this.GetValue<bool>("debuginfo");
    }

    public interface IMotifNegumContinueScreen : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IVectorEntry Position => this.GetValue<IVectorEntry>("pos");
        ITextEntry ContinueText => this.GetValue<ITextEntry>("continue");
        ITextEntry YesText => this.GetValue<ITextEntry>("yes");
        ITextEntry YesActiveText => this.GetValue<ITextEntry>("yes.active");
        ITextEntry NoText => this.GetValue<ITextEntry>("no");
        ITextEntry NoActiveText => this.GetValue<ITextEntry>("no.active");
    }

    public interface IMotifNegumGameOverScreen : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IFileEntry StoryboardFile => this.GetValue<IFileEntry>("storyboard");
    }

    public interface IMotifNegumVictoryScreen : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITimeEntry Time => this.GetValue<ITimeEntry>("time");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        IPlayerSelectionEntry Player1 => this.GetValue<IPlayerSelectionEntry>("p1");
        ITextEntry WinQuote => this.GetValue<ITextEntry>("winquote");
    }

    public interface IMotifNegumWinScreen : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITextEntry WinText => this.GetValue<ITextEntry>("wintext");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        ITimeEntry PoseTime => this.GetValue<ITimeEntry>("pos.time");
    }

    public interface IMotifNegumDefaultEnding : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IFileEntry StoryboardFile => this.GetValue<IFileEntry>("storyboard");
    }

    public interface IMotifNegumEndCredits : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IFileEntry StoryboardFile => this.GetValue<IFileEntry>("storyboard");
    }

    public interface IMotifNegumSurvivalResultsScreen : INegumManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITextEntry WinText => this.GetValue<ITextEntry>("wintext");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        ITimeEntry ShowTime => this.GetValue<ITimeEntry>("show.time");

        /// <summary>
        /// Number of rounds to get win pose (lose pose otherwise).
        /// </summary>
        int RoundsToWin => this.GetValue<int>("roundstowin");
    }
}