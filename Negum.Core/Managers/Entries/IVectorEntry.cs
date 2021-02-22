using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Vector of values.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IVectorEntry : IManagerSectionEntry<IVectorEntry>, IEnumerable<string>
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
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class VectorEntry : ManagerSectionEntry<IVectorEntry>, IVectorEntry
    {
        protected IList<string> Values { get; set; }

        public string this[int index] => this.Values[index];

        public string RawValue => this.Entry.Value;

        public override IVectorEntry Get()
        {
            this.Values = this.RawValue
                .Replace(" ", "")
                .Split(",")
                .ToList();

            return this;
        }

        public IEnumerator<string> GetEnumerator() =>
            this.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}