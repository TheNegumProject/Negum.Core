namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent a Fighting Player.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IFightConfigurationPlayerEntry : IScrapperEntry
    {
        IVectorEntry Position => Scrapper.GetVector(this.KeyPrefix + ".pos");
        IImageEntry Bg0 => Scrapper.GetImage(this.KeyPrefix + ".bg0");
        IImageEntry Bg1 => Scrapper.GetImage(this.KeyPrefix + ".bg1");
        IImageEntry Mid => Scrapper.GetImage(this.KeyPrefix + ".mid");
        IImageEntry Front => Scrapper.GetImage(this.KeyPrefix + ".front");
        IVectorEntry RangeX => Scrapper.GetVector(this.KeyPrefix + ".range.x");
        ITextEntry Counter => Scrapper.GetText(this.KeyPrefix + ".counter");
        IImageEntry Face => Scrapper.GetImage(this.KeyPrefix + ".face");
        ITextEntry Name => Scrapper.GetText(this.KeyPrefix + ".name");
        IVectorEntry IconOffset => Scrapper.GetVector(this.KeyPrefix + ".iconoffset");
        IFightConfigurationWinEntry Win => Scrapper.GetFightConfigurationWin(this.KeyPrefix);
    }
}