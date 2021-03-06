using System.IO;
using System.Threading.Tasks;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Represents a reader used to parse file path and get result Stream.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ILocalFileReader : IReader<string, Stream>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class LocalFileReader : ILocalFileReader
    {
        public async Task<Stream> ReadAsync(string path)
        {
            return await Task.FromResult(new FileStream(path, FileMode.Open, FileAccess.Read)
            {
                Position = 0
            });
        }
    }
}