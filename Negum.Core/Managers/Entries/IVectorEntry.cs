using System.Collections;
using System.Collections.Generic;
using Negum.Core.Containers;
using Negum.Core.Models.Math;
using Negum.Core.Readers;

namespace Negum.Core.Managers.Entries;

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
    string? RawValue { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class VectorEntry : ManagerSectionEntry<IVectorEntry>, IVectorEntry
{
    private IVector<string> Vector { get; set; } = new Vector<string>();

    public string this[int index] => Vector[index];

    public string? RawValue => Entry?.Value;
    public int Length => Vector.Length;

    public override IVectorEntry Read()
    {
        var reader = NegumContainer.Resolve<IStringVectorReader>();
        Vector = reader.ReadAsync(RawValue).Result;

        return this;
    }

    public IEnumerator<string> GetEnumerator() =>
        Vector.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}