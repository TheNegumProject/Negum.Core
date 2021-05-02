using System.Threading.Tasks;
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
            var bytesPerLine = imageHeader.GetBytesPerLine();
            var bytesPerPixel = imageHeader.GetBytesPerPixel();

            var index = 1;

            for (var row = 0; row < imageHeader.Height; ++row)
            {
                var filterType = imageBytes[index - 1];
                var previousIndex = row + bytesPerLine * (row - 1);
                var end = index + bytesPerLine;

                for (var currentIndex = index; currentIndex < end; ++currentIndex)
                {
                    ProcessFilter(
                        imageBytes, filterType,
                        previousIndex, index, currentIndex,
                        currentIndex - index, bytesPerPixel);
                }

                index += bytesPerLine + 1;
            }

            return imageBytes;
        }
    }
}