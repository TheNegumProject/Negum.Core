using System;
using System.Collections.Generic;
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
        private static readonly IReadOnlyDictionary<int, int[]> PassToRow = new Dictionary<int, int[]>
        {
            {1, new[] {0}},
            {2, new[] {0}},
            {3, new[] {4}},
            {4, new[] {0, 4}},
            {5, new[] {2, 6}},
            {6, new[] {0, 2, 4, 6}},
            {7, new[] {1, 3, 5, 7}}
        };

        private static readonly IReadOnlyDictionary<int, int[]> PassToColumn = new Dictionary<int, int[]>
        {
            {1, new[] {0}},
            {2, new[] {4}},
            {3, new[] {0, 4}},
            {4, new[] {2, 6}},
            {5, new[] {0, 2, 4, 6}},
            {6, new[] {1, 3, 5, 7}},
            {7, new[] {0, 1, 2, 3, 4, 5, 6, 7}}
        };

        public async Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader)
        {
            throw new ArgumentException($"Adam7 interlace is not yet supported.");
        }
    }
}