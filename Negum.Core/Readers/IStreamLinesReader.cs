using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is used to read all lines from specified stream.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IStreamLinesReader : IStreamReader<IEnumerable<string>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class StreamLinesReader : IStreamLinesReader
    {
        public async Task<IEnumerable<string>> ReadAsync(Stream input)
        {
            using var reader = new StreamReader(input);
            string? line;
            var lines = new List<string>();

            while ((line = await reader.ReadLineAsync()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}