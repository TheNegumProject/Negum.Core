namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Animation.
    /// </summary>
    ///
    /// <docs>
    /// http://www.elecbyte.com/mugendocs/air.html
    /// </docs>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IAnimationEntry : IScrapperEntry<IAnimationEntry>
    {
        int Animation => this.Scrapper.GetInt(this.KeyPrefix + ".anim");
        IPositionEntry Offset => this.Scrapper.GetPosition(this.KeyPrefix + ".offset");
    }
}