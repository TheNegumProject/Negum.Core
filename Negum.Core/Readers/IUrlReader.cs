using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Negum.Core.Readers;

/// <summary>
/// Represents a reader used to parse URL and get result Stream.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IUrlReader : IReader<string, Stream>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class UrlReader : IUrlReader
{
    public async Task<Stream> ReadAsync(string url)
    {
        var client = new HttpClient();
        var stream = await client.GetStreamAsync(url);
        return stream;
    }
}