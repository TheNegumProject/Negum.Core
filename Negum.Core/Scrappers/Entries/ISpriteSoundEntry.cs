namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Sprite with Sound.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSoundEntry : IScrapperEntry<ISpriteSoundEntry>
    {
        ISpriteEntry Sprite => this.Scrapper.GetSprite(this.Section.Name, this.KeyPrefix + ".spr");
        ISoundEntry Sound => this.Scrapper.GetSound(this.Section.Name, this.KeyPrefix + ".snd");
    }
}