using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types;

/// <summary>
/// Manager which handles Fight configuration.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFightManager : IManager
{
    IFightFiles Files => GetSection<IFightFiles>("Files");
    IFightFightFx FightFx => GetSection<IFightFightFx>("FightFx");
    IFightLifebar Lifebar => GetSection<IFightLifebar>("Lifebar");
    IFightSimulLifebar SimulLifebar => GetSection<IFightSimulLifebar>("Simul Lifebar");
    IFightTurnsLifebar TurnsLifebar => GetSection<IFightTurnsLifebar>("Turns Lifebar");
    IFightPowerbar Powerbar => GetSection<IFightPowerbar>("Powerbar");
    IFightFace Face => GetSection<IFightFace>("Face");
    IFightSimulFace SimulFace => GetSection<IFightSimulFace>("Simul Face");
    IFightTurnsFace TurnsFace => GetSection<IFightTurnsFace>("Turns Face");
    IFightName Name => GetSection<IFightName>("Name");
    IFightSimulName SimulName => GetSection<IFightSimulName>("Simul Name");
    IFightTurnsName TurnsName => GetSection<IFightTurnsName>("Turns Name");
    IFightTime Time => GetSection<IFightTime>("Time");
    IFightCombo Combo => GetSection<IFightCombo>("Combo");
    IFightRound Round => GetSection<IFightRound>("Round");
    IFightWinIcon WinIcon => GetSection<IFightWinIcon>("WinIcon");
}

public interface IFightFiles : IManagerSection
{
    string? SpriteFile => GetValue<string>("sff");
    string? SoundFile => GetValue<string>("snd");
    IEnumerable<string> FontFiles => GetValues<string>("font");
    string? FightFxSffFile => GetValue<string>("fightfx.sff");
    string? FightFxAirFile => GetValue<string>("fightfx.air");
    string? CommonSoundFile => GetValue<string>("common.snd");
}

public interface IFightFightFx : IManagerSection
{
    int? Scale => GetValue<int>("scale");
}

public interface IFightLifebar : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightSimulLifebar : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightTurnsLifebar : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightPowerbar : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
    IEnumerable<IVectorEntry> LevelSounds => GetValues<IVectorEntry>("level");
}

public interface IFightFace : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightSimulFace : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
    IFightConfigurationPlayerEntry? Player3 => GetValue<IFightConfigurationPlayerEntry>("p3");
    IFightConfigurationPlayerEntry? Player4 => GetValue<IFightConfigurationPlayerEntry>("p4");
}

public interface IFightTurnsFace : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightName : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightSimulName : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
    IFightConfigurationPlayerEntry? Player3 => GetValue<IFightConfigurationPlayerEntry>("p3");
    IFightConfigurationPlayerEntry? Player4 => GetValue<IFightConfigurationPlayerEntry>("p4");
}

public interface IFightTurnsName : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");
}

public interface IFightTime : IManagerSection
{
    IVectorEntry? Position => GetValue<IVectorEntry>("pos");
    ITextEntry? Counter => GetValue<ITextEntry>("counter");
    IImageEntry? Background => GetValue<IImageEntry>("bg");

    /// <summary>
    /// Ticks for each count.
    /// </summary>
    int? FramesPerCount => GetValue<int>("framespercount");
}

public interface IFightCombo : IManagerSection
{
    IFightConfigurationTeamEntry? Team1 => GetValue<IFightConfigurationTeamEntry>("team1");
    IFightConfigurationTeamEntry? Team2 => GetValue<IFightConfigurationTeamEntry>("team2");
}

public interface IFightRound : IManagerSection
{
    /// <summary>
    /// Rounds needed to win a match.
    /// </summary>
    int? MatchWins => GetValue<int>("match.wins");

    /// <summary>
    /// Max number of drawgames allowed (-1 for infinite).
    /// </summary>
    int? MatchMaxDrawGames => GetValue<int>("match.maxdrawgames");

    /// <summary>
    /// Time to wait before starting intro.
    /// </summary>
    ITimeEntry? StartWaitTime => GetValue<ITimeEntry>("start.waittime");

    /// <summary>
    /// Default position for all components.
    /// </summary>
    IVectorEntry? Position => GetValue<IVectorEntry>("pos");

    /// <summary>
    /// Time to show round display.
    /// </summary>
    ITimeEntry? RoundTime => GetValue<ITimeEntry>("round.time");

    /// <summary>
    /// Default component to show for each round.
    /// Text can include a %i to the round number.
    /// </summary>
    ITextEntry? RoundText => GetValue<ITextEntry>("round.default");

    /// <summary>
    /// Sounds to play for each round (optional).
    /// </summary>
    IEnumerable<IVectorEntry> RoundSounds => GetValues<IVectorEntry>("round");

    /// <summary>
    /// Components to show for each round.
    /// </summary>
    IEnumerable<IImageEntry> RoundAnimations => GetValues<IImageEntry>("round");

    /// <summary>
    /// Time players get control after "Fight".
    /// </summary>
    ITimeEntry? ControlTime => GetValue<ITimeEntry>("ctrl.time");

    IScreenElementEntry? FightElement => GetValue<IScreenElementEntry>("fight");
    IScreenElementEntry? KoElement => GetValue<IScreenElementEntry>("KO");
    IScreenElementEntry? DoubleKoElement => GetValue<IScreenElementEntry>("DKO");
    IScreenElementEntry? TimeOverElement => GetValue<IScreenElementEntry>("TO");

    /// <summary>
    /// Time for KO slowdown (in ticks).
    /// </summary>
    ITimeEntry? SlowTime => GetValue<ITimeEntry>("slow.time");

    /// <summary>
    /// Time to wait after KO before player control is stopped.
    /// </summary>
    ITimeEntry? GameOverWaitTime => GetValue<ITimeEntry>("over.waittime");

    /// <summary>
    /// Time after KO that players can still damage each other (for double KO).
    /// </summary>
    ITimeEntry? GameOverHitTime => GetValue<ITimeEntry>("over.hittime");

    /// <summary>
    /// Time to wait before players change to win states.
    /// </summary>
    ITimeEntry? GameOverWinTime => GetValue<ITimeEntry>("over.wintime");

    /// <summary>
    /// Time to wait before round ends.
    /// </summary>
    ITimeEntry? GameOverTime => GetValue<ITimeEntry>("over.time");

    /// <summary>
    /// Time to wait before showing win/draw message.
    /// </summary>
    ITimeEntry? WinTime => GetValue<ITimeEntry>("win.time");

    /// <summary>
    /// Win text.
    /// </summary>
    ITextEntry? WinText => GetValue<ITextEntry>("win");

    /// <summary>
    /// 2-player win text.
    /// </summary>
    ITextEntry? Win2Text => GetValue<ITextEntry>("win2");

    /// <summary>
    /// Draw text.
    /// </summary>
    ITextEntry? DrawText => GetValue<ITextEntry>("draw");
}

public interface IFightWinIcon : IManagerSection
{
    IFightConfigurationPlayerEntry? Player1 => GetValue<IFightConfigurationPlayerEntry>("p1");
    IFightConfigurationPlayerEntry? Player2 => GetValue<IFightConfigurationPlayerEntry>("p2");

    /// <summary>
    /// Use icons up until this number of wins.
    /// </summary>
    int? UseIconUpTo => GetValue<int>("useiconupto");
}