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
    public interface IMotifManager : IManager
    {
        IMotifInfo Info => this.GetSection<IMotifInfo>("Info");
        IMotifFiles Files => this.GetSection<IMotifFiles>("Files");
        IMotifMusic Music => this.GetSection<IMotifMusic>("Music");
        IMotifTitleInfo TitleInfo => this.GetSection<IMotifTitleInfo>("Title Info");
        IMotifScreenBgDef TitleBgDef => this.GetSection<IMotifScreenBgDef>("TitleBGdef");
        IEnumerable<IMotifScreenBg> TitleBgs => this.GetSubsections<IMotifScreenBg>("TitleBGdef");
        IMotifInfobox Infobox => this.GetSection<IMotifInfobox>("Infobox");
        IMotifSelectInfo SelectInfo => this.GetSection<IMotifSelectInfo>("Select Info");
        IMotifScreenBgDef SelectBgDef => this.GetSection<IMotifScreenBgDef>("SelectBGdef");
        IEnumerable<IMotifScreenBg> SelectBgs => this.GetSubsections<IMotifScreenBg>("SelectBGdef");
        IMotifVsScreen VsScreen => this.GetSection<IMotifVsScreen>("VS Screen");
        IMotifScreenBgDef VersusBgDef => this.GetSection<IMotifScreenBgDef>("VersusBGdef");
        IEnumerable<IMotifScreenBg> VersusBgs => this.GetSubsections<IMotifScreenBg>("VersusBGdef");
        IMotifDemoMode DemoMode => this.GetSection<IMotifDemoMode>("Demo Mode");
        IMotifContinueScreen ContinueScreen => this.GetSection<IMotifContinueScreen>("Continue Screen");
        IMotifGameOverScreen GameOverScreen => this.GetSection<IMotifGameOverScreen>("Game Over Screen");
        IMotifVictoryScreen VictoryScreen => this.GetSection<IMotifVictoryScreen>("Victory Screen");
        IMotifScreenBgDef VictoryBgDef => this.GetSection<IMotifScreenBgDef>("VictoryBGdef");
        IEnumerable<IMotifScreenBg> VictoryBgs => this.GetSubsections<IMotifScreenBg>("VictoryBGdef");
        IMotifWinScreen WinScreen => this.GetSection<IMotifWinScreen>("Win Screen");
        IMotifDefaultEnding DefaultEnding => this.GetSection<IMotifDefaultEnding>("Default Ending");
        IMotifEndCredits EndCredits => this.GetSection<IMotifEndCredits>("End Credits");

        IMotifSurvivalResultsScreen SurvivalResultsScreen =>
            this.GetSection<IMotifSurvivalResultsScreen>("Survival Results Screen");

        IMotifScreenBgDef OptionInfo => this.GetSection<IMotifScreenBgDef>("Option Info");
        IMotifScreenBgDef OptionBgDef => this.GetSection<IMotifScreenBgDef>("OptionBGdef");
        IEnumerable<IMotifScreenBg> OptionBgs => this.GetSubsections<IMotifScreenBg>("OptionBGdef");
    }

    public interface IMotifScreenBgDef : IManagerSection
    {
        IFileEntry SpriteFile => this.GetValue<IFileEntry>("spr");
        IVectorEntry BgClearColor => this.GetValue<IVectorEntry>("bgclearcolor");
    }

    public interface IMotifInfo : IManagerSection
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

    public interface IMotifFiles : IManagerSection
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
        IEnumerable<IFileEntry> FontFiles => this.GetValues<IFileEntry>("font");
    }

    public interface IMotifMusic : IManagerSection
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

    public interface IMotifTitleInfo : IManagerSection
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

    public interface IMotifScreenBg : IManagerSection
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

    public interface IMotifInfobox : IManagerSection
    {
        // TODO: What is this ??? Get an example
    }

    public interface IMotifSelectInfo : IManagerSection
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

    public interface IMotifVsScreen : IManagerSection
    {
        ITimeEntry Time => this.GetValue<ITimeEntry>("time");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        ITextEntry Match => this.GetValue<ITextEntry>("match");
        IPlayerSelectionEntry Player1 => this.GetValue<IPlayerSelectionEntry>("p1");
        IPlayerSelectionEntry Player2 => this.GetValue<IPlayerSelectionEntry>("p2");
    }

    public interface IMotifDemoMode : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITimeEntry WaitTime => this.GetValue<ITimeEntry>("title.waittime");
        IDemoModeFightEntry Fight => this.GetValue<IDemoModeFightEntry>("fight");
        int IntroWaitCycles => this.GetValue<int>("intro.waitcycles");
        bool ShowDebugInfo => this.GetValue<bool>("debuginfo");
    }

    public interface IMotifContinueScreen : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IVectorEntry Position => this.GetValue<IVectorEntry>("pos");
        ITextEntry ContinueText => this.GetValue<ITextEntry>("continue");
        ITextEntry YesText => this.GetValue<ITextEntry>("yes");
        ITextEntry YesActiveText => this.GetValue<ITextEntry>("yes.active");
        ITextEntry NoText => this.GetValue<ITextEntry>("no");
        ITextEntry NoActiveText => this.GetValue<ITextEntry>("no.active");
    }

    public interface IMotifGameOverScreen : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IFileEntry StoryboardFile => this.GetValue<IFileEntry>("storyboard");
    }

    public interface IMotifVictoryScreen : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITimeEntry Time => this.GetValue<ITimeEntry>("time");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        IPlayerSelectionEntry Player1 => this.GetValue<IPlayerSelectionEntry>("p1");
        ITextEntry WinQuote => this.GetValue<ITextEntry>("winquote");
    }

    public interface IMotifWinScreen : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        ITextEntry WinText => this.GetValue<ITextEntry>("wintext");
        ITimeEntry FadeInTime => this.GetValue<ITimeEntry>("fadein.time");
        ITimeEntry FadeOutTime => this.GetValue<ITimeEntry>("fadeout.time");
        ITimeEntry PoseTime => this.GetValue<ITimeEntry>("pos.time");
    }

    public interface IMotifDefaultEnding : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IFileEntry StoryboardFile => this.GetValue<IFileEntry>("storyboard");
    }

    public interface IMotifEndCredits : IManagerSection
    {
        bool IsEnabled => this.GetValue<bool>("enabled");
        IFileEntry StoryboardFile => this.GetValue<IFileEntry>("storyboard");
    }

    public interface IMotifSurvivalResultsScreen : IManagerSection
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