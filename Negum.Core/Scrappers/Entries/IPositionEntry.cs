namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Position.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPositionEntry : IScrapperEntry<IPositionEntry>
    {
        float X { get; }
        float y { get; }

        /// <summary>
        /// Initializes position from specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Current entry with initialized values.</returns>
        IPositionEntry From(string value);
    }
}