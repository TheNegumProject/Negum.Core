using System;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png.Decoders
{
    /// <summary>
    /// PNG image no interlace decoder.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngNoInterlaceDecoder : ISffPngInterlaceDecoder
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngNoInterlaceDecoder : SffPngInterlaceDecoder, ISffPngNoInterlaceDecoder
    {
        public async Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader)
        {
            var scanlineDecoder = NegumContainer.Resolve<ISffPngScanlineDecoder>();

            // -3 ==>> Scanline was interpreted as RGBA and we want it to be 1 byte not 4
            // 4 ==>> RGBA (1 byte per each subPixel)
            var bytesPerLine = imageHeader.BytesInRow * 4 - 3;
            var bytesPerPixel = imageHeader.GetBytesPerPixel();

            var outputBytes = new byte[imageBytes.Length];

            for (var row = 0; row < imageHeader.Height; ++row)
            {
                var rowStartIndex = row * bytesPerLine;
                var rowEndIndex = rowStartIndex + bytesPerLine;
                var scanline = imageBytes[rowStartIndex..rowEndIndex];

                var previousScanline = row > 0
                    ? outputBytes[(rowStartIndex - bytesPerLine)..rowStartIndex]
                    : Array.Empty<byte>();

                var decodedRow = await scanlineDecoder.DecodeAsync(scanline, previousScanline, bytesPerPixel);

                // Add decoded bytes to output buffer
                for (var index = 0; index < decodedRow.Length; ++index)
                {
                    outputBytes[rowStartIndex + index] = decodedRow[index];
                }
            }

            // Return output bytes without filter types which are at the beginning of each saved scanline
            var outputBytesWithoutFilterTypes = outputBytes
                .Where((value, index) => index != 0 && index % bytesPerLine != 0)
                .ToArray();

            return outputBytesWithoutFilterTypes;
        }
    }
}