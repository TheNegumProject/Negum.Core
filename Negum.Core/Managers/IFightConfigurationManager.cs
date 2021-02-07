using System.Linq;
using Negum.Core.Containers;
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
    public interface IFightConfigurationManager : IConfigurationManager<IFightConfigurationManager>
    {
        public IFightConfigurationFiles Files =>
            NegumContainer.Resolve<IFightConfigurationFiles>().Setup(this.Scrapper.GetSection("Files"));

        public IFightConfigurationFightFx FightFx =>
            NegumContainer.Resolve<IFightConfigurationFightFx>().Setup(this.Scrapper.GetSection("FightFx"));

        public IFightConfigurationLifebar Lifebar =>
            NegumContainer.Resolve<IFightConfigurationLifebar>().Setup(this.Scrapper.GetSection("Lifebar"));

        public IFightConfigurationSimulLifebar SimulLifebar =>
            NegumContainer.Resolve<IFightConfigurationSimulLifebar>().Setup(this.Scrapper.GetSection("Simul Lifebar"));

        public IFightConfigurationTurnsLifebar TurnsLifebar =>
            NegumContainer.Resolve<IFightConfigurationTurnsLifebar>().Setup(this.Scrapper.GetSection("Turns Lifebar"));

        public IFightConfigurationPowerbar Powerbar =>
            NegumContainer.Resolve<IFightConfigurationPowerbar>().Setup(this.Scrapper.GetSection("Powerbar"));

        public IFightConfigurationFace Face =>
            NegumContainer.Resolve<IFightConfigurationFace>().Setup(this.Scrapper.GetSection("Face"));

        public IFightConfigurationSimulFace SimulFace =>
            NegumContainer.Resolve<IFightConfigurationSimulFace>().Setup(this.Scrapper.GetSection("Simul Face"));

        public IFightConfigurationTurnsFace TurnsFace =>
            NegumContainer.Resolve<IFightConfigurationTurnsFace>().Setup(this.Scrapper.GetSection("Turns Face"));

        public IFightConfigurationName Name =>
            NegumContainer.Resolve<IFightConfigurationName>().Setup(this.Scrapper.GetSection("Name"));

        public IFightConfigurationSimulName SimulName =>
            NegumContainer.Resolve<IFightConfigurationSimulName>().Setup(this.Scrapper.GetSection("Simul Name"));

        public IFightConfigurationTurnsName TurnsName =>
            NegumContainer.Resolve<IFightConfigurationTurnsName>().Setup(this.Scrapper.GetSection("Turns Name"));

        public IFightConfigurationTime Time =>
            NegumContainer.Resolve<IFightConfigurationTime>().Setup(this.Scrapper.GetSection("Time"));

        public IFightConfigurationCombo Combo =>
            NegumContainer.Resolve<IFightConfigurationCombo>().Setup(this.Scrapper.GetSection("Combo"));

        public IFightConfigurationRound Round =>
            NegumContainer.Resolve<IFightConfigurationRound>().Setup(this.Scrapper.GetSection("Round"));

        public IFightConfigurationWinIcon WinIcon =>
            NegumContainer.Resolve<IFightConfigurationWinIcon>().Setup(this.Scrapper.GetSection("WinIcon"));
    }

    public interface IFightConfigurationFiles : IConfigurationManagerSection<IFightConfigurationFiles>
    {
        IFileEntry Sprite => Scrapper.GetFile("sff");
        IFileEntry Sound => Scrapper.GetFile("snd");
        IEntryCollection<IFileEntry> Fonts => Scrapper.GetCollection<IFileEntry>("font");
        IFileEntry FightFxSff => Scrapper.GetFile("fightfx.sff");
        IFileEntry FightFxAir => Scrapper.GetFile("fightfx.air");
        IFileEntry CommonSound => Scrapper.GetFile("common.snd");
    }

    public interface IFightConfigurationFightFx : IConfigurationManagerSection<IFightConfigurationFightFx>
    {
        int Scale => Scrapper.GetInt("scale");
    }

    public interface IFightConfigurationLifebar : IConfigurationManagerSection<IFightConfigurationLifebar>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationSimulLifebar : IConfigurationManagerSection<IFightConfigurationSimulLifebar>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationTurnsLifebar : IConfigurationManagerSection<IFightConfigurationTurnsLifebar>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationPowerbar : IConfigurationManagerSection<IFightConfigurationPowerbar>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
        IEntryCollection<ISoundEntry> LevelSounds => Scrapper.GetCollection<ISoundEntry>("level");
    }

    public interface IFightConfigurationFace : IConfigurationManagerSection<IFightConfigurationFace>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationSimulFace : IConfigurationManagerSection<IFightConfigurationSimulFace>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
        IFightConfigurationPlayerEntry Player3 => Scrapper.GetFightConfigurationPlayer("p3");
        IFightConfigurationPlayerEntry Player4 => Scrapper.GetFightConfigurationPlayer("p4");
    }

    public interface IFightConfigurationTurnsFace : IConfigurationManagerSection<IFightConfigurationTurnsFace>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationName : IConfigurationManagerSection<IFightConfigurationName>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationSimulName : IConfigurationManagerSection<IFightConfigurationSimulName>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
        IFightConfigurationPlayerEntry Player3 => Scrapper.GetFightConfigurationPlayer("p3");
        IFightConfigurationPlayerEntry Player4 => Scrapper.GetFightConfigurationPlayer("p4");
    }

    public interface IFightConfigurationTurnsName : IConfigurationManagerSection<IFightConfigurationTurnsName>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");
    }

    public interface IFightConfigurationTime : IConfigurationManagerSection<IFightConfigurationTime>
    {
        IPositionEntry Position => Scrapper.GetPosition("pos");
        ITextEntry Counter => Scrapper.GetText("counter");
        IImageEntry Background => Scrapper.GetImage(".bg");

        /// <summary>
        /// Ticks for each count.
        /// </summary>
        int FramesPerCount => Scrapper.GetInt("framespercount");
    }

    public interface IFightConfigurationCombo : IConfigurationManagerSection<IFightConfigurationCombo>
    {
        IFightConfigurationTeamEntry Team1 => Scrapper.GetFightConfigurationTeam("team1");
        IFightConfigurationTeamEntry Team2 => Scrapper.GetFightConfigurationTeam("team2");
    }

    public interface IFightConfigurationRound : IConfigurationManagerSection<IFightConfigurationRound>
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
        IPositionEntry Position => Scrapper.GetPosition("pos");

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
        IEntryCollection<ISoundEntry> RoundSounds => Scrapper.GetCollection<ISoundEntry>(
            Scrapper
                .GetAll()
                .Where(entry => entry.Key.StartsWith("round") && !entry.Key.StartsWith("round."))
                .Select(entry => entry.Key)
                .ToList());

        /// <summary>
        /// Components to show for each round.
        /// </summary>
        IEntryCollection<IImageEntry> RoundAnimations => Scrapper.GetCollection<IImageEntry>(
            Scrapper
                .GetAll()
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

    public interface IFightConfigurationWinIcon : IConfigurationManagerSection<IFightConfigurationWinIcon>
    {
        IFightConfigurationPlayerEntry Player1 => Scrapper.GetFightConfigurationPlayer("p1");
        IFightConfigurationPlayerEntry Player2 => Scrapper.GetFightConfigurationPlayer("p2");

        /// <summary>
        /// Use icons up until this number of wins.
        /// </summary>
        int UseIconUpTo => Scrapper.GetInt("useiconupto");
    }
}