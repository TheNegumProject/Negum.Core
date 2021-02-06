namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Player Team Menu Value.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPlayerSelectionTeamMenuValueEntry : IScrapperEntry<IPlayerSelectionTeamMenuValueEntry>
    {
        ISoundEntry Sound => this.Scrapper.GetSound(this.KeyPrefix + ".snd");
        IImageEntry Icon => this.Scrapper.GetImage(this.KeyPrefix + ".icon");
        IImageEntry EmptyIcon => this.Scrapper.GetImage(this.KeyPrefix + ".empty.icon");
        IPositionEntry Spacing => this.Scrapper.GetPosition(this.KeyPrefix + ".spacing");
    }
}