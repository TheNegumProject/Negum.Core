using System;
using System.Threading.Tasks;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png.Decoders
{
    /// <summary>
    /// PNG image interlace decoder which is used Adam7 algorithm.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngAdam7InterlaceDecoder : ISffPngInterlaceDecoder
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngAdam7InterlaceDecoder : SffPngInterlaceDecoder, ISffPngAdam7InterlaceDecoder
    {
        public async Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader)
        {
            throw new ArgumentException($"Adam7 interlace is not yet supported.");
        }
    }
}