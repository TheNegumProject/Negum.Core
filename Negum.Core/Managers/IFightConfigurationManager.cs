using System.Linq;
using Negum.Core.Scrappers.Entries;

namespace Negum.Core.Managers
{
    /// <summary>
    /// Manager which handles Fight configuration.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationManager : IConfigurationManager
    {
        IFightConfigurationFiles Files => this.GetSection<IFightConfigurationFiles>("Files");
        IFightConfigurationFightFx FightFx => this.GetSection<IFightConfigurationFightFx>("FightFx");
        IFightConfigurationLifebar Lifebar => this.GetSection<IFightConfigurationLifebar>("Lifebar");

        IFightConfigurationSimulLifebar SimulLifebar =>
            this.GetSection<IFightConfigurationSimulLifebar>("Simul Lifebar");

        IFightConfigurationTurnsLifebar TurnsLifebar =>
            this.GetSection<IFightConfigurationTurnsLifebar>("Turns Lifebar");

        IFightConfigurationPowerbar Powerbar => this.GetSection<IFightConfigurationPowerbar>("Powerbar");
        IFightConfigurationFace Face => this.GetSection<IFightConfigurationFace>("Face");
        IFightConfigurationSimulFace SimulFace => this.GetSection<IFightConfigurationSimulFace>("Simul Face");
        IFightConfigurationTurnsFace TurnsFace => this.GetSection<IFightConfigurationTurnsFace>("Turns Face");
        IFightConfigurationName Name => this.GetSection<IFightConfigurationName>("Name");
        IFightConfigurationSimulName SimulName => this.GetSection<IFightConfigurationSimulName>("Simul Name");
        IFightConfigurationTurnsName TurnsName => this.GetSection<IFightConfigurationTurnsName>("Turns Name");
        IFightConfigurationTime Time => this.GetSection<IFightConfigurationTime>("Time");
        IFightConfigurationCombo Combo => this.GetSection<IFightConfigurationCombo>("Combo");
        IFightConfigurationRound Round => this.GetSection<IFightConfigurationRound>("Round");
        IFightConfigurationWinIcon WinIcon => this.GetSection<IFightConfigurationWinIcon>("WinIcon");
    }

    public interface IFightConfigurationFiles : IConfigurationManagerSection
    {
        IFileEntry SpriteFile => Scrapper.GetFile("sff");
        IFileEntry SoundFile => Scrapper.GetFile("snd");
        IEntryCollection<IFileEntry> FontFiles => Scrapper.GetCollection<IFileEntry>("font");
        IFileEntry FightFxSffFile => Scrapper.GetFile("fightfx.sff");
        IFileEntry FightFxAirFile => Scrapper.GetFile("fightfx.air");
        IFileEntry CommonSoundFile => Scrapper.GetFile("common.snd");
    }

    public interface IFightConfigurationFightFx : IConfigurationManagerSection
    {
        int Scale => Scrapper.GetInt("scale");
    }

    public interface IFightConfigurationLifebar : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationSimulLifebar : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationTurnsLifebar : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationPowerbar : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
        IEntryCollection<IVectorEntry> LevelSounds => Scrapper.GetCollection<IVectorEntry>("level");
    }

    public interface IFightConfigurationFace : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationSimulFace : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
        IFightConfigurationPlayerEntry Player3 => Scrapper.GetFightConfigurationPlayer("p3");
        IFightConfigurationPlayerEntry Player4 => Scrapper.GetFightConfigurationPlayer("p4");
    }

    public interface IFightConfigurationTurnsFace : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationName : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationSimulName : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
        IFightConfigurationPlayerEntry Player3 => Scrapper.GetFightConfigurationPlayer("p3");
        IFightConfigurationPlayerEntry Player4 => Scrapper.GetFightConfigurationPlayer("p4");
    }

    public interface IFightConfigurationTurnsName : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationTime : IConfigurationManagerSection
    {
        IVectorEntry Position => Scrapper.GetVector("pos");
        ITextEntry Counter => Scrapper.GetText("counter");
        IImageEntry Background => Scrapper.GetImage(".bg");

        /// <summary>
        /// Ticks for each count.
        /// </summary>
        int FramesPerCount => Scrapper.GetInt("framespercount");
    }

    public interface IFightConfigurationCombo : IConfigurationManagerSection
    {
        IFightConfigurationTeamEntry Team1 => Scrapper.GetFightConfigurationTeam("team1");
        IFightConfigurationTeamEntry Team2 => Scrapper.GetFightConfigurationTeam("team2");
    }

    public interface IFightConfigurationRound : IConfigurationManagerSection
    {
        /// <summary>
        /// Rounds needed to win a match.
        /// </summary>
        int MatchWins => Scrapper.GetInt("match.wins");

        /// <summary>
        /// Max number of drawgames allowed (-1 for infinite).
        /// </summary>
        int MatchMaxDrawGames => Scrapper.GetInt("match.maxdrawgames");

        /// <summary>
        /// Time to wait before starting intro.
        /// </summary>
        ITimeEntry StartWaitTime => Scrapper.GetTime("start.waittime");

        /// <summary>
        /// Default position for all components.
        /// </summary>
        IVectorEntry Position => Scrapper.GetVector("pos");

        /// <summary>
        /// Time to show round display.
        /// </summary>
        ITimeEntry RoundTime => Scrapper.GetTime("round.time");

        /// <summary>
        /// Default component to show for each round.
        /// Text can include a %i to the round number.
        /// </summary>
        ITextEntry RoundText => Scrapper.GetText("round.default");

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
        ITimeEntry ControlTime => Scrapper.GetTime("ctrl.time");

        IScreenElementEntry FightElement => Scrapper.GetScreenElement("fight");
        IScreenElementEntry KoElement => Scrapper.GetScreenElement("KO");
        IScreenElementEntry DoubleKoElement => Scrapper.GetScreenElement("DKO");
        IScreenElementEntry TimeOverElement => Scrapper.GetScreenElement("TO");

        /// <summary>
        /// Time for KO slowdown (in ticks).
        /// </summary>
        ITimeEntry SlowTime => Scrapper.GetTime("slow.time");

        /// <summary>
        /// Time to wait after KO before player control is stopped.
        /// </summary>
        ITimeEntry GameOverWaitTime => Scrapper.GetTime("over.waittime");

        /// <summary>
        /// Time after KO that players can still damage each other (for double KO).
        /// </summary>
        ITimeEntry GameOverHitTime => Scrapper.GetTime("over.hittime");

        /// <summary>
        /// Time to wait before players change to win states.
        /// </summary>
        ITimeEntry GameOverWinTime => Scrapper.GetTime("over.wintime");

        /// <summary>
        /// Time to wait before round ends.
        /// </summary>
        ITimeEntry GameOverTime => Scrapper.GetTime("over.time");

        /// <summary>
        /// Time to wait before showing win/draw message.
        /// </summary>
        ITimeEntry WinTime => Scrapper.GetTime("win.time");

        /// <summary>
        /// Win text.
        /// </summary>
        ITextEntry WinText => Scrapper.GetText("win");

        /// <summary>
        /// 2-player win text.
        /// </summary>
        ITextEntry Win2Text => Scrapper.GetText("win2");

        /// <summary>
        /// Draw text.
        /// </summary>
        ITextEntry DrawText => Scrapper.GetText("draw");
    }

    public interface IFightConfigurationWinIcon : IConfigurationManagerSection
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");

        /// <summary>
        /// Use icons up until this number of wins.
        /// </summary>
        int UseIconUpTo => Scrapper.GetInt("useiconupto");
    }
}