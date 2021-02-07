namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent a Fighting Player.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationPlayerEntry : IScrapperEntry<IFightConfigurationPlayerEntry>
    {
        IPositionEntry Position => Scrapper.GetPosition(this.KeyPrefix + ".pos");
        IAnimationEntry Bg0 => Scrapper.GetAnimation(this.KeyPrefix + ".bg0");
        IImageEntry Bg1 => Scrapper.GetImage(this.KeyPrefix + ".bg1");
        IAnimationEntry Mid => Scrapper.GetAnimation(this.KeyPrefix + ".mid");
        IImageEntry Front => Scrapper.GetImage(this.KeyPrefix + ".front");
        IPositionEntry RangeX => Scrapper.GetPosition(this.KeyPrefix + ".range.x");
    }
}