using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Models.Math;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is used to read vector of values from given string.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IIntVectorReader : IReader<string, IVector<int>>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class IntVectorReader : CommonVectorReader, IIntVectorReader
{
    public Task<IVector<int>> ReadAsync(string input)
    {
        var vector = new Vector<int>();

        SplitValues(input)
            .ToList()
            .ForEach(value => vector.Add(int.Parse(value)));

        return Task.FromResult((IVector<int>)vector);
    }
}