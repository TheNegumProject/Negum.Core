using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Negum.Core.Readers.Sff.V2;

/// <summary>
/// Reader used to decode SFF image using RLE-5 (Run Length Encoding at 5 bits-per-pixel pixmap).
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffRle5Reader : IReader<IEnumerable<byte>, IEnumerable<byte>>
{
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffRle5Reader : ISffRle5Reader
{
    public Task<IEnumerable<byte>> ReadAsync(IEnumerable<byte> input)
    {
        var ret = new List<byte>();
        var stream = new MemoryStream(input.ToArray());
        var binaryReader = new BinaryReader(stream);

        while (stream.Position != stream.Length)
        {
            var runLength = binaryReader.ReadByte();
            var dataLength = binaryReader.ReadByte();

            // Most algorithms perform pre-incrementing the index before reading (skipping 1 byte)
            var color = (dataLength & 128) == 1 ? binaryReader.ReadByte() : (byte) 0;

            for (var i = 0; i < runLength; ++i)
            {
                ret.Add(color);
            }

            for (var i = 0; i < (dataLength & 127) - 1; ++i) // 127 == 0x7F
            {
                // Same situation. Index might need to be pre-increment (skipping 1 byte)
                var b = binaryReader.ReadByte();

                color = (byte) (b & 31); // 31 == 0x1F
                runLength = (byte) (b >> 5);

                for (var j = 0; j < runLength; ++j)
                {
                    ret.Add(color);
                }
            }
        }

        return Task.FromResult(ret.AsEnumerable());
    }
}