using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Negum.Core.Readers.Sff.V2
{
    /// <summary>
    /// Reader used to decode SFF image using RLE-8 (Run Length Encoding).
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffRle8Reader : IReader<IEnumerable<byte>, IEnumerable<byte>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffRle8Reader : ISffRle8Reader
    {
        public async Task<IEnumerable<byte>> ReadAsync(IEnumerable<byte> input)
        {
            var ret = new List<byte>();
            var stream = new MemoryStream(input.ToArray());
            var binaryReader = new BinaryReader(stream);

            while (stream.Position != stream.Length)
            {
                var character = binaryReader.ReadByte();

                if ((character & 192) == 64)
                {
                    var color = binaryReader.ReadByte();
                    var length = character & 63;

                    for (var i = 0; i < length; ++i)
                    {
                        ret.Add(color);
                    }
                }
                else
                {
                    ret.Add(character);
                }
            }

            binaryReader.Close();
            await stream.DisposeAsync();

            return ret.ToArray();
        }
    }
}