using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Math;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is used to read IPoint.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPointReader : IReader<string, IPoint>
{
    /// <summary>
    /// Converts given vector to IPoint.
    /// </summary>
    /// <param name="vector">Vector to be converted.</param>
    /// <returns>Point with values from vector.</returns>
    Task<IPoint?> ToPointAsync(IVector<string>? vector);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PointReader : IPointReader
{
    public Task<IPoint> ReadAsync(string input)
    {
        var values = NegumContainer.Resolve<IIntVectorReader>().ReadAsync(input).Result;
        return Task.FromResult((IPoint)new Point(values[0], values[1]));
    }

    public Task<IPoint?> ToPointAsync(IVector<string>? vector) => 
        vector is null 
            ? Task.FromResult((IPoint?)null) 
            : Task.FromResult((IPoint?)new Point(int.Parse(vector[0]), int.Parse(vector[1])));
}