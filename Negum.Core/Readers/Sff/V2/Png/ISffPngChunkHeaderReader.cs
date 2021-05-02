using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png
{
    /// <summary>
    /// Reader which is used to read PNG chunk header.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngChunkHeaderReader : IStreamReader<ISffPngChunkHeader>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkHeaderReader : ISffPngChunkHeaderReader
    {
        public async Task<ISffPngChunkHeader> ReadAsync(Stream input)
        {
            var lengthBytes = new byte[4];

            if (input.Read(lengthBytes) != 4)
            {
                throw new ArgumentException($"Cannot read chunk header length.");
            }

            var nameBytes = new byte[4];

            if (input.Read(nameBytes) != 4)
            {
                throw new ArgumentException($"Cannot read chunk header name.");
            }

            var length = SffPngHelper.ReadBigEndian(lengthBytes, 0);
            var name = Encoding.ASCII.GetString(nameBytes, 0, 4);

            var chunkHeader = new SffPngChunkHeader
            {
                Length = length,
                Name = name
            };

            return chunkHeader;
        }
    }
}