namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSoundEntry : ScrappedEntry<ISpriteSoundEntry>, ISpriteSoundEntry
    {
        public string Sprite => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".spr");
        public string Sound => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".snd");
    }
}