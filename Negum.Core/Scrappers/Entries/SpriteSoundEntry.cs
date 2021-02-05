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
        public IPositionEntry Sprite => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".spr");
        public IPositionEntry Sound => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".snd");
        public string SoundCanceled => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".snd.cancel");
    }
}