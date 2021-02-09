namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Box.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IBoxEntry : IScrapperEntry<IBoxEntry>
    {
        IVectorEntry Start { get; }
        IVectorEntry End { get; }
    }
}