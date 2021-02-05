namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Movement entry.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IMovementEntry : IScrapperEntry<IMovementEntry>
    {
        ISpriteSoundEntry Move => this.Scrapper.GetSpriteSound(this.Section.Name, this.KeyPrefix + ".move");
        ISpriteSoundEntry Done => this.Scrapper.GetSpriteSound(this.Section.Name, this.KeyPrefix + ".done");
    }
}