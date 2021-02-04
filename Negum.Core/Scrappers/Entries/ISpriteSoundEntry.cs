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
        string Sprite { get; }
        string Sound { get; }
    }
}