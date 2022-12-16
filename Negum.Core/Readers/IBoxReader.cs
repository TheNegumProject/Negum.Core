using System.Threading.Tasks;
using Negum.Core.Models.Math;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is used to read box.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IBoxReader : IReader<IVector<string>, IBox>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class BoxReader : IBoxReader
{
    public Task<IBox> ReadAsync(IVector<string> input)
    {
        var p1 = new Point(int.Parse(input[0]), int.Parse(input[1]));
        var p2 = new Point(int.Parse(input[2]), int.Parse(input[3]));
            
        return Task.FromResult((IBox)new Box(p1, p2));
    }
}