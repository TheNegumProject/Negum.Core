namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Animation.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IAnimationEntry : IScrapperEntry<IAnimationEntry>
    {
        int Animation => this.Scrapper.GetInt(this.Section.Name, this.KeyPrefix + ".anim");
        IPositionEntry Offset => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".offset");
    }
}