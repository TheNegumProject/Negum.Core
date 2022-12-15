using System.IO;
using System.Threading.Tasks;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which general purpose is to provide simple conversion from abstract Stream into convenient MemoryStream.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IMemoryStreamReader : IStreamReader<MemoryStream>
{
}
    
/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class MemoryStreamReader : IMemoryStreamReader
{
    public async Task<MemoryStream> ReadAsync(Stream stream)
    {
        var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        return memoryStream;
    }
}