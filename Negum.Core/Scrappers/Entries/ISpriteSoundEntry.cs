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
        IPositionEntry Sprite => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".spr");
        IPositionEntry Sound => this.Scrapper.GetPosition(this.Section.Name, this.KeyPrefix + ".snd");
        string SoundCanceled => this.Scrapper.GetString(this.Section.Name, this.KeyPrefix + ".snd.cancel");
    }
}