using System.Collections.Generic;
using Negum.Core.Managers.Entries;

namespace Negum.Core.Managers.Types
{
    /// <summary>
    /// Manager which handles Fight configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightManager : IManager
    {
        IFightFiles Files => this.GetSection<IFightFiles>("Files");
        IFightFightFx FightFx => this.GetSection<IFightFightFx>("FightFx");
        IFightLifebar Lifebar => this.GetSection<IFightLifebar>("Lifebar");
        IFightSimulLifebar SimulLifebar => this.GetSection<IFightSimulLifebar>("Simul Lifebar");
        IFightTurnsLifebar TurnsLifebar => this.GetSection<IFightTurnsLifebar>("Turns Lifebar");
        IFightPowerbar Powerbar => this.GetSection<IFightPowerbar>("Powerbar");
        IFightFace Face => this.GetSection<IFightFace>("Face");
        IFightSimulFace SimulFace => this.GetSection<IFightSimulFace>("Simul Face");
        IFightTurnsFace TurnsFace => this.GetSection<IFightTurnsFace>("Turns Face");
        IFightName Name => this.GetSection<IFightName>("Name");
        IFightSimulName SimulName => this.GetSection<IFightSimulName>("Simul Name");
        IFightTurnsName TurnsName => this.GetSection<IFightTurnsName>("Turns Name");
        IFightTime Time => this.GetSection<IFightTime>("Time");
        IFightCombo Combo => this.GetSection<IFightCombo>("Combo");
        IFightRound Round => this.GetSection<IFightRound>("Round");
        IFightWinIcon WinIcon => this.GetSection<IFightWinIcon>("WinIcon");
    }

    public interface IFightFiles : IManagerSection
    {
        IFileEntry SpriteFile => this.GetValue<IFileEntry>("sff");
        IFileEntry SoundFile => this.GetValue<IFileEntry>("snd");
        IEnumerable<IFileEntry> FontFiles => this.GetValues<IFileEntry>("font");
        IFileEntry FightFxSffFile => this.GetValue<IFileEntry>("fightfx.sff");
        IFileEntry FightFxAirFile => this.GetValue<IFileEntry>("fightfx.air");
        IFileEntry CommonSoundFile => this.GetValue<IFileEntry>("common.snd");
    }

    public interface IFightFightFx : IManagerSection
    {
        int Scale => this.GetValue<int>("scale");
    }

    public interface IFightLifebar : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightSimulLifebar : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightTurnsLifebar : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightPowerbar : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
        IEnumerable<IVectorEntry> LevelSounds => this.GetValues<IVectorEntry>("level");
    }

    public interface IFightFace : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightSimulFace : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
        IFightConfigurationPlayerEntry Player3 => this.GetValue<IFightConfigurationPlayerEntry>("p3");
        IFightConfigurationPlayerEntry Player4 => this.GetValue<IFightConfigurationPlayerEntry>("p4");
    }

    public interface IFightTurnsFace : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightName : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightSimulName : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
        IFightConfigurationPlayerEntry Player3 => this.GetValue<IFightConfigurationPlayerEntry>("p3");
        IFightConfigurationPlayerEntry Player4 => this.GetValue<IFightConfigurationPlayerEntry>("p4");
    }

    public interface IFightTurnsName : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightTime : IManagerSection
    {
        IVectorEntry Position => this.GetValue<IVectorEntry>("pos");
        ITextEntry Counter => this.GetValue<ITextEntry>("counter");
        IImageEntry Background => this.GetValue<IImageEntry>(".bg");

        /// <summary>
        /// Ticks for each count.
        /// </summary>
        int FramesPerCount => this.GetValue<int>("framespercount");
    }

    public interface IFightCombo : IManagerSection
    {
        IFightConfigurationTeamEntry Team1 => this.GetValue<IFightConfigurationTeamEntry>("team1");
        IFightConfigurationTeamEntry Team2 => this.GetValue<IFightConfigurationTeamEntry>("team2");
    }

    public interface IFightRound : IManagerSection
    {
        /// <summary>
        /// Rounds needed to win a match.
        /// </summary>
        int MatchWins => this.GetValue<int>("match.wins");

        /// <summary>
        /// Max number of drawgames allowed (-1 for infinite).
        /// </summary>
        int MatchMaxDrawGames => this.GetValue<int>("match.maxdrawgames");

        /// <summary>
        /// Time to wait before starting intro.
        /// </summary>
        ITimeEntry StartWaitTime => this.GetValue<ITimeEntry>("start.waittime");

        /// <summary>
        /// Default position for all components.
        /// </summary>
        IVectorEntry Position => this.GetValue<IVectorEntry>("pos");

        /// <summary>
        /// Time to show round display.
        /// </summary>
        ITimeEntry RoundTime => this.GetValue<ITimeEntry>("round.time");

        /// <summary>
        /// Default component to show for each round.
        /// Text can include a %i to the round number.
        /// </summary>
        ITextEntry RoundText => this.GetValue<ITextEntry>("round.default");

        /// <summary>
        /// Sounds to play for each round (optional).
        /// </summary>
        IEnumerable<IVectorEntry> RoundSounds => this.GetValues<IVectorEntry>("round");

        /// <summary>
        /// Components to show for each round.
        /// </summary>
        IEnumerable<IImageEntry> RoundAnimations => this.GetValues<IImageEntry>("round");

        /// <summary>
        /// Time players get control after "Fight".
        /// </summary>
        ITimeEntry ControlTime => this.GetValue<ITimeEntry>("ctrl.time");

        IScreenElementEntry FightElement => this.GetValue<IScreenElementEntry>("fight");
        IScreenElementEntry KoElement => this.GetValue<IScreenElementEntry>("KO");
        IScreenElementEntry DoubleKoElement => this.GetValue<IScreenElementEntry>("DKO");
        IScreenElementEntry TimeOverElement => this.GetValue<IScreenElementEntry>("TO");

        /// <summary>
        /// Time for KO slowdown (in ticks).
        /// </summary>
        ITimeEntry SlowTime => this.GetValue<ITimeEntry>("slow.time");

        /// <summary>
        /// Time to wait after KO before player control is stopped.
        /// </summary>
        ITimeEntry GameOverWaitTime => this.GetValue<ITimeEntry>("over.waittime");

        /// <summary>
        /// Time after KO that players can still damage each other (for double KO).
        /// </summary>
        ITimeEntry GameOverHitTime => this.GetValue<ITimeEntry>("over.hittime");

        /// <summary>
        /// Time to wait before players change to win states.
        /// </summary>
        ITimeEntry GameOverWinTime => this.GetValue<ITimeEntry>("over.wintime");

        /// <summary>
        /// Time to wait before round ends.
        /// </summary>
        ITimeEntry GameOverTime => this.GetValue<ITimeEntry>("over.time");

        /// <summary>
        /// Time to wait before showing win/draw message.
        /// </summary>
        ITimeEntry WinTime => this.GetValue<ITimeEntry>("win.time");

        /// <summary>
        /// Win text.
        /// </summary>
        ITextEntry WinText => this.GetValue<ITextEntry>("win");

        /// <summary>
        /// 2-player win text.
        /// </summary>
        ITextEntry Win2Text => this.GetValue<ITextEntry>("win2");

        /// <summary>
        /// Draw text.
        /// </summary>
        ITextEntry DrawText => this.GetValue<ITextEntry>("draw");
    }

    public interface IFightWinIcon : IManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");

        /// <summary>
        /// Use icons up until this number of wins.
        /// </summary>
        int UseIconUpTo => this.GetValue<int>("useiconupto");
    }
}