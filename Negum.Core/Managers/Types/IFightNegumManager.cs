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
    public interface IFightNegumManager : INegumManager
    {
        IFightNegumFiles Files => this.GetSection<IFightNegumFiles>("Files");
        IFightNegumFightFx FightFx => this.GetSection<IFightNegumFightFx>("FightFx");
        IFightNegumLifebar Lifebar => this.GetSection<IFightNegumLifebar>("Lifebar");

        IFightNegumSimulLifebar SimulLifebar =>
            this.GetSection<IFightNegumSimulLifebar>("Simul Lifebar");

        IFightNegumTurnsLifebar TurnsLifebar =>
            this.GetSection<IFightNegumTurnsLifebar>("Turns Lifebar");

        IFightNegumPowerbar Powerbar => this.GetSection<IFightNegumPowerbar>("Powerbar");
        IFightNegumFace Face => this.GetSection<IFightNegumFace>("Face");
        IFightNegumSimulFace SimulFace => this.GetSection<IFightNegumSimulFace>("Simul Face");
        IFightNegumTurnsFace TurnsFace => this.GetSection<IFightNegumTurnsFace>("Turns Face");
        IFightNegumName Name => this.GetSection<IFightNegumName>("Name");
        IFightNegumSimulName SimulName => this.GetSection<IFightNegumSimulName>("Simul Name");
        IFightNegumTurnsName TurnsName => this.GetSection<IFightNegumTurnsName>("Turns Name");
        IFightNegumTime Time => this.GetSection<IFightNegumTime>("Time");
        IFightNegumCombo Combo => this.GetSection<IFightNegumCombo>("Combo");
        IFightNegumRound Round => this.GetSection<IFightNegumRound>("Round");
        IFightNegumWinIcon WinIcon => this.GetSection<IFightNegumWinIcon>("WinIcon");
    }

    public interface IFightNegumFiles : INegumManagerSection
    {
        IFileEntry SpriteFile => this.GetValue<IFileEntry>("sff");
        IFileEntry SoundFile => this.GetValue<IFileEntry>("snd");
        IEntryCollection<IFileEntry> FontFiles => Scrapper.GetCollection<IFileEntry>("font");
        IFileEntry FightFxSffFile => this.GetValue<IFileEntry>("fightfx.sff");
        IFileEntry FightFxAirFile => this.GetValue<IFileEntry>("fightfx.air");
        IFileEntry CommonSoundFile => this.GetValue<IFileEntry>("common.snd");
    }

    public interface IFightNegumFightFx : INegumManagerSection
    {
        int Scale => this.GetValue<int>("scale");
    }

    public interface IFightNegumLifebar : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumSimulLifebar : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumTurnsLifebar : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumPowerbar : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
        IEntryCollection<IVectorEntry> LevelSounds => Scrapper.GetCollection<IVectorEntry>("level");
    }

    public interface IFightNegumFace : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumSimulFace : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
        IFightConfigurationPlayerEntry Player3 => this.GetValue<IFightConfigurationPlayerEntry>("p3");
        IFightConfigurationPlayerEntry Player4 => this.GetValue<IFightConfigurationPlayerEntry>("p4");
    }

    public interface IFightNegumTurnsFace : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumName : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumSimulName : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
        IFightConfigurationPlayerEntry Player3 => this.GetValue<IFightConfigurationPlayerEntry>("p3");
        IFightConfigurationPlayerEntry Player4 => this.GetValue<IFightConfigurationPlayerEntry>("p4");
    }

    public interface IFightNegumTurnsName : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");
    }

    public interface IFightNegumTime : INegumManagerSection
    {
        IVectorEntry Position => this.GetValue<IVectorEntry>("pos");
        ITextEntry Counter => this.GetValue<ITextEntry>("counter");
        IImageEntry Background => this.GetValue<IImageEntry>(".bg");

        /// <summary>
        /// Ticks for each count.
        /// </summary>
        int FramesPerCount => this.GetValue<int>("framespercount");
    }

    public interface IFightNegumCombo : INegumManagerSection
    {
        IFightConfigurationTeamEntry Team1 => this.GetValue<IFightConfigurationTeamEntry>("team1");
        IFightConfigurationTeamEntry Team2 => this.GetValue<IFightConfigurationTeamEntry>("team2");
    }

    public interface IFightNegumRound : INegumManagerSection
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
        IEntryCollection<IVectorEntry> RoundSounds => Scrapper.GetCollection<IVectorEntry>(
            Scrapper
                .Where(entry => entry.Key.StartsWith("round") && !entry.Key.StartsWith("round."))
                .Select(entry => entry.Key)
                .ToList());

        /// <summary>
        /// Components to show for each round.
        /// </summary>
        IEntryCollection<IImageEntry> RoundAnimations => Scrapper.GetCollection<IImageEntry>(
            Scrapper
                .Where(entry => entry.Key.StartsWith("round") && !entry.Key.StartsWith("round."))
                .Select(entry => entry.Key)
                .ToList());

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

    public interface IFightNegumWinIcon : INegumManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => this.GetValue<IFightConfigurationPlayerEntry>("p1");
        IFightConfigurationPlayerEntry Player2 => this.GetValue<IFightConfigurationPlayerEntry>("p2");

        /// <summary>
        /// Use icons up until this number of wins.
        /// </summary>
        int UseIconUpTo => this.GetValue<int>("useiconupto");
    }
}