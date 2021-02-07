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
    }

    public interface IFightConfigurationWinIcon : IConfigurationManagerSection<IFightConfigurationWinIcon>
    {
    }
}