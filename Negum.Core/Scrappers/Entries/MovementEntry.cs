namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class MovementEntry : ScrappedEntry<IMovementEntry>, IMovementEntry
    {
        public ISpriteSoundEntry Move => this.Scrapper.GetSpriteSound(this.Section.Name, this.KeyPrefix + ".move");
        public ISpriteSoundEntry Done => this.Scrapper.GetSpriteSound(this.Section.Name, this.KeyPrefix + ".done");
    }
}