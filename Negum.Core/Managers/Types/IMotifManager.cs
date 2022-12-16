using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Motif configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IMotifManager : IManager
{
    IMotifInfo Info => GetSection<IMotifInfo>("Info");
    IMotifFiles Files => GetSection<IMotifFiles>("Files");
    IMotifMusic Music => GetSection<IMotifMusic>("Music");
    IMotifTitleInfo TitleInfo => GetSection<IMotifTitleInfo>("Title Info");
    IMotifScreenBgDef TitleBgDef => GetSection<IMotifScreenBgDef>("TitleBGdef");
    IEnumerable<IMotifScreenBg> TitleBgs => GetSubsections<IMotifScreenBg>("TitleBGdef");
    IMotifInfobox Infobox => GetSection<IMotifInfobox>("Infobox");
    IMotifSelectInfo SelectInfo => GetSection<IMotifSelectInfo>("Select Info");
    IMotifScreenBgDef SelectBgDef => GetSection<IMotifScreenBgDef>("SelectBGdef");
    IEnumerable<IMotifScreenBg> SelectBgs => GetSubsections<IMotifScreenBg>("SelectBGdef");
    IMotifVsScreen VsScreen => GetSection<IMotifVsScreen>("VS Screen");
    IMotifScreenBgDef VersusBgDef => GetSection<IMotifScreenBgDef>("VersusBGdef");
    IEnumerable<IMotifScreenBg> VersusBgs => GetSubsections<IMotifScreenBg>("VersusBGdef");
    IMotifDemoMode DemoMode => GetSection<IMotifDemoMode>("Demo Mode");
    IMotifContinueScreen ContinueScreen => GetSection<IMotifContinueScreen>("Continue Screen");
    IMotifGameOverScreen GameOverScreen => GetSection<IMotifGameOverScreen>("Game Over Screen");
    IMotifVictoryScreen VictoryScreen => GetSection<IMotifVictoryScreen>("Victory Screen");
    IMotifScreenBgDef VictoryBgDef => GetSection<IMotifScreenBgDef>("VictoryBGdef");
    IEnumerable<IMotifScreenBg> VictoryBgs => GetSubsections<IMotifScreenBg>("VictoryBGdef");
    IMotifWinScreen WinScreen => GetSection<IMotifWinScreen>("Win Screen");
    IMotifDefaultEnding DefaultEnding => GetSection<IMotifDefaultEnding>("Default Ending");
    IMotifEndCredits EndCredits => GetSection<IMotifEndCredits>("End Credits");
    IMotifSurvivalResultsScreen SurvivalResultsScreen => GetSection<IMotifSurvivalResultsScreen>("Survival Results Screen");
    IMotifScreenBgDef OptionInfo => GetSection<IMotifScreenBgDef>("Option Info");
    IMotifScreenBgDef OptionBgDef => GetSection<IMotifScreenBgDef>("OptionBGdef");
    IEnumerable<IMotifScreenBg> OptionBgs => GetSubsections<IMotifScreenBg>("OptionBGdef");
}

public interface IMotifScreenBgDef : IManagerSection
{
    string? SpriteFile => GetValue<string>("spr");
    IVectorEntry? BgClearColor => GetValue<IVectorEntry>("bgclearcolor");
}

public interface IMotifInfo : IManagerSection
{
    /// <summary>
    /// Name of motif.
    /// </summary>
    string? MotifName => GetValue<string>("name");

    /// <summary>
    /// Motif author name.
    /// </summary>
    string? Author => GetValue<string>("author");

    /// <summary>
    /// Version date of motif.
    /// </summary>
    ITimeEntry? VersionDate => GetValue<ITimeEntry>("versiondate");

    /// <summary>
    /// Version of motif.
    /// </summary>
    float? Version => GetValue<float>("mugenversion");
}

public interface IMotifFiles : IManagerSection
{
    /// <summary>
    /// Filename of sprite data.
    /// </summary>
    string? SpriteFile => GetValue<string>("spr");

    /// <summary>
    /// Filename of sound data.
    /// </summary>
    string? SoundFile => GetValue<string>("snd");

    /// <summary>
    /// Logo storyboard definition (optional).
    /// </summary>
    string? LogoStoryboardDefinition => GetValue<string>("logo.storyboard");

    /// <summary>
    /// Intro storyboard definition (optional).
    /// </summary>
    string? IntroStoryboardDefinition => GetValue<string>("intro.storyboard");

    /// <summary>
    /// Character and stage selection list.
    /// </summary>
    string? SelectionFile => GetValue<string>("select");

    /// <summary>
    /// Fight definition filename.
    /// </summary>
    string? FightFile => GetValue<string>("fight");

    /// <summary>
    /// System fonts.
    /// </summary>
    IEnumerable<string> FontFiles => GetValues<string>("font");
}

public interface IMotifMusic : IManagerSection
{
    /// <summary>
    /// Music to play at title screen.
    /// </summary>
    IAudioEntry? Title => GetValue<IAudioEntry>("title.bgm");

    /// <summary>
    /// Music to play at char select screen.
    /// </summary>
    IAudioEntry? Select => GetValue<IAudioEntry>("select.bgm");

    /// <summary>
    /// Music to play at versus screen.
    /// </summary>
    IAudioEntry? Vs => GetValue<IAudioEntry>("vs.bgm");

    /// <summary>
    /// Music to play at victory screen.
    /// </summary>
    IAudioEntry? Victory => GetValue<IAudioEntry>("victory.bgm");
}

public interface IMotifTitleInfo : IManagerSection
{
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    IVectorEntry? MenuPosition => GetValue<IVectorEntry>("menu.pos");
    ITextEntry? MenuItem => GetValue<ITextEntry>("menu.item");
    ITextEntry? MenuItemActive => GetValue<ITextEntry>("menu.item.active");
    string? MenuItemNameArcade => GetValue<string>("menu.itemname.arcade");
    string? MenuItemNameVersus => GetValue<string>("menu.itemname.versus");
    string? MenuItemNameTeamArcade => GetValue<string>("menu.itemname.teamarcade");
    string? MenuItemNameTeamVersus => GetValue<string>("menu.itemname.teamversus");
    string? MenuItemNameTeamCoop => GetValue<string>("menu.itemname.teamcoop");
    string? MenuItemNameSurvival => GetValue<string>("menu.itemname.survival");
    string? MenuItemNameSurvivalCoop => GetValue<string>("menu.itemname.survivalcoop");
    string? MenuItemNameTraining => GetValue<string>("menu.itemname.training");
    string? MenuItemNameWatch => GetValue<string>("menu.itemname.watch");
    string? MenuItemNameOptions => GetValue<string>("menu.itemname.options");
    string? MenuItemNameExit => GetValue<string>("menu.itemname.exit");
    IVectorEntry? MenuWindowMarginsY => GetValue<IVectorEntry>("menu.window.margins.y");
    int? MenuWindowVisibleItems => GetValue<int>("menu.window.visibleitems");

    /// <summary>
    /// Set it to true to enable default cursor display.
    /// Set it to false to disable default cursor display.
    /// </summary>
    bool? IsMenuBoxCursorVisible => GetValue<bool>("menu.boxcursor.visible");

    IVectorEntry? MenuBoxCursorCoords => GetValue<IVectorEntry>("menu.boxcursor.coords");
    IMovementStateEntry? Cursor => GetValue<IMovementStateEntry>("cursor");
    ISpriteSoundEntry? Cancel => GetValue<ISpriteSoundEntry>("cancel");
}

public interface IMotifScreenBg : IManagerSection
{
    string? Type => GetValue<string>("type");
    IVectorEntry? SpriteNumber => GetValue<IVectorEntry>("spriteno");
    int? LayerNumber => GetValue<int>("layerno");
    IVectorEntry? Start => GetValue<IVectorEntry>("start");
    IVectorEntry? Tile => GetValue<IVectorEntry>("tile");
    IVectorEntry? Velocity => GetValue<IVectorEntry>("velocity");
    IVectorEntry? Window => GetValue<IVectorEntry>("window");
    string? Trans => GetValue<string>("trans");
    int? Mask => GetValue<int>("mask");
    IVectorEntry? Delta => GetValue<IVectorEntry>("delta");
}

public interface IMotifInfobox : IManagerSection
{
    // TODO: What is this ??? Get an example
}

public interface IMotifSelectInfo : IManagerSection
{
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    int? Rows => GetValue<int>("rows");
    int? Columns => GetValue<int>("columns");

    /// <summary>
    /// Values:
    /// 0 - default
    /// 1 - cursor wraps around
    /// </summary>
    int? Wrapping => GetValue<int>("wrapping");

    /// <summary>
    /// Position to draw to.
    /// </summary>
    IVectorEntry? Position => GetValue<IVectorEntry>("pos");

    bool? ShowEmptyBoxes => GetValue<bool>("showemptyboxes");
    bool? CanMoveOverEmptyBoxes => GetValue<bool>("moveoveremptyboxes");
    ICellSelectionEntry? Cell => GetValue<ICellSelectionEntry>("cell");

    /// <summary>
    /// Player 1 selection.
    /// </summary>
    IPlayerSelectionEntry? Player1 => GetValue<IPlayerSelectionEntry>("p1");

    /// <summary>
    /// Player 2 selection.
    /// </summary>
    IPlayerSelectionEntry? Player2 => GetValue<IPlayerSelectionEntry>("p2");

    IMovementStateEntry? Random => GetValue<IMovementStateEntry>("random");
    ISpriteSoundEntry? Cancel => GetValue<ISpriteSoundEntry>("cancel");
    IImageEntry? Portrait => GetValue<IImageEntry>("portrait");
    ITextEntry? Title => GetValue<ITextEntry>("title");
    IStageSelectionEntry? Stage => GetValue<IStageSelectionEntry>("stage");
    bool? TeamMenuMoveWrapping => GetValue<bool>("teammenu.move.wrapping");
}

public interface IMotifVsScreen : IManagerSection
{
    ITimeEntry? Time => GetValue<ITimeEntry>("time");
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    ITextEntry? Match => GetValue<ITextEntry>("match");
    IPlayerSelectionEntry? Player1 => GetValue<IPlayerSelectionEntry>("p1");
    IPlayerSelectionEntry? Player2 => GetValue<IPlayerSelectionEntry>("p2");
}

public interface IMotifDemoMode : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    ITimeEntry? WaitTime => GetValue<ITimeEntry>("title.waittime");
    IDemoModeFightEntry? Fight => GetValue<IDemoModeFightEntry>("fight");
    int? IntroWaitCycles => GetValue<int>("intro.waitcycles");
    bool? ShowDebugInfo => GetValue<bool>("debuginfo");
}

public interface IMotifContinueScreen : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    IVectorEntry? Position => GetValue<IVectorEntry>("pos");
    ITextEntry? ContinueText => GetValue<ITextEntry>("continue");
    ITextEntry? YesText => GetValue<ITextEntry>("yes");
    ITextEntry? YesActiveText => GetValue<ITextEntry>("yes.active");
    ITextEntry? NoText => GetValue<ITextEntry>("no");
    ITextEntry? NoActiveText => GetValue<ITextEntry>("no.active");
}

public interface IMotifGameOverScreen : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    string? StoryboardFile => GetValue<string>("storyboard");
}

public interface IMotifVictoryScreen : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    ITimeEntry? Time => GetValue<ITimeEntry>("time");
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    IPlayerSelectionEntry? Player1 => GetValue<IPlayerSelectionEntry>("p1");
    ITextEntry? WinQuote => GetValue<ITextEntry>("winquote");
}

public interface IMotifWinScreen : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    ITextEntry? WinText => GetValue<ITextEntry>("wintext");
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    ITimeEntry? PoseTime => GetValue<ITimeEntry>("pos.time");
}

public interface IMotifDefaultEnding : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    string? StoryboardFile => GetValue<string>("storyboard");
}

public interface IMotifEndCredits : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    string? StoryboardFile => GetValue<string>("storyboard");
}

public interface IMotifSurvivalResultsScreen : IManagerSection
{
    bool? IsEnabled => GetValue<bool>("enabled");
    ITextEntry? WinText => GetValue<ITextEntry>("wintext");
    ITimeEntry? FadeInTime => GetValue<ITimeEntry>("fadein.time");
    ITimeEntry? FadeOutTime => GetValue<ITimeEntry>("fadeout.time");
    ITimeEntry? ShowTime => GetValue<ITimeEntry>("show.time");

    /// <summary>
    /// Number of rounds to get win pose (lose pose otherwise).
    /// </summary>
    int? RoundsToWin => GetValue<int>("roundstowin");
}