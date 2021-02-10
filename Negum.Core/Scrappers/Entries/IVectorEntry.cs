using System.Collections.Generic;

namespace Negum.Core.Scrappers.Entries
{
    /// <summary>
    /// Represents a scrapped entry which should represent Vector of values.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IVectorEntry : IScrapperEntry<IVectorEntry>, IEnumerable<string>
    {
        /// <summary>
        /// Provides simple way to retrieve value from appropriate slot.
        /// </summary>
        /// <param name="index"></param>
        string this[int index] { get; }
        
        /// <summary>
        /// Raw value passed to current entry.
        /// Exposed for any custom outside operations.
        /// </summary>
        string RawValue { get; }
        
        /// <summary>
        /// Initializes position from specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Current entry with initialized values.</returns>
        IVectorEntry From(string value);
    }
}