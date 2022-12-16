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
public interface IStringVectorReader : IReader<string?, IVector<string>>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class StringVectorReader : CommonVectorReader, IStringVectorReader
{
    public Task<IVector<string>> ReadAsync(string? input)
    {
        var vector = new Vector<string>();

        SplitValues(input)
            .ToList()
            .ForEach(value => vector.Add(value));

        return Task.FromResult((IVector<string>)vector);
    }
}