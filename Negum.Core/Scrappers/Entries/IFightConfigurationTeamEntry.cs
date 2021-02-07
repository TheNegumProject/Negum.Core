namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Fighting Team.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationTeamEntry : IScrapperEntry<IFightConfigurationTeamEntry>
    {
        IPositionEntry Position => Scrapper.GetPosition(this.KeyPrefix + ".pos");
        int StartX => Scrapper.GetInt(this.KeyPrefix + ".start.x");
        ITextEntry Counter => Scrapper.GetText(this.KeyPrefix + ".counter");
        ITextEntry Text => Scrapper.GetText(this.KeyPrefix + ".text");
        ITimeEntry DisplayTime => Scrapper.GetTime(this.KeyPrefix + ".displaytime");
    }
}