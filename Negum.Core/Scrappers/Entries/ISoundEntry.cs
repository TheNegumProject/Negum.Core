namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Sound.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISoundEntry : IScrapperEntry<ISoundEntry>
    {
        string SoundCanceled => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".cancel");
    }
}