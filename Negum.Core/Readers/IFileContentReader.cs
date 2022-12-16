using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which provides file content from URL od from path.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFileContentReader : IReader<string, Stream>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FileContentReader : IFileContentReader
{
    public async Task<Stream> ReadAsync(string path)
    {
        if (path.StartsWith("http") || path.StartsWith("www") || path.Contains("://"))
        {
            var urlReader = NegumContainer.Resolve<IUrlReader>();
            return await urlReader.ReadAsync(path);
        }

        var localFileReader = NegumContainer.Resolve<ILocalFileReader>();
        return await localFileReader.ReadAsync(path);
    }
}