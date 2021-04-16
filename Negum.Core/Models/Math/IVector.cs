using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Models.Math
{
    /// <summary>
    /// Represents a vector of data.
    /// Vectors should be immutable.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IVector<TData> : IEnumerable<TData>
    {
        /// <summary>
        /// Provides simple way to retrieve value at given index.
        /// </summary>
        /// <param name="index"></param>
        TData this[int index] { get; }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        int Length { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Vector<TData> : IVector<TData>
    {
        protected IList<TData> Data { get; } = new List<TData>();

        public TData this[int index] => this.Data[index];

        public int Length => this.Data.Count;

        /// <summary>
        /// Adds data to current vector.
        /// </summary>
        /// <param name="data"></param>
        public virtual void Add(TData data)
        {
            this.Data.Add(data);
        }

        public IEnumerator<TData> GetEnumerator() =>
            this.Data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}