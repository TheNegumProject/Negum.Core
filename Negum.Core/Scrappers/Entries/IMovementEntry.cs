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
        ISpriteSoundEntry Done { get; }
        ISpriteSoundEntry Move { get; }
    }
}