using System.Collections;
using System.Collections.Generic;
using Negum.Core.Containers;
using Negum.Core.Models.Math;
using Negum.Core.Readers;

namespace Negum.Core.Managers.Entries
{
    /// <summary>
    /// Represents a Vector of values.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IVectorEntry : IManagerSectionEntry<IVectorEntry>, IVector<string>
    {
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
        protected IVector<string> Vector { get; set; }

        public string this[int index] => this.Vector[index];

        public string RawValue => this.Entry.Value;
        public int Length => this.Vector.Length;

        public override IVectorEntry Get()
        {
            var reader = NegumContainer.Resolve<IStringVectorReader>();
            this.Vector = reader.ReadAsync(this.RawValue).Result;

            return this;
        }

        public IEnumerator<string> GetEnumerator() =>
            this.Vector.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}