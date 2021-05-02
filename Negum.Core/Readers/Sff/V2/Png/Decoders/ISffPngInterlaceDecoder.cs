using System;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png.Decoders
{
    /// <summary>
    /// PNG image interlace decoder.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngInterlaceDecoder
    {
        /// <summary>
        /// Decodes specified image bytes.
        /// </summary>
        /// <param name="imageBytes">PNG image bytes.</param>
        /// <param name="imageHeader">PNG image header.</param>
        /// <returns>Raw decoded PNG image.</returns>
        Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngInterlaceDecoder : ISffPngInterlaceDecoder
    {
        public async Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader) =>
            imageHeader.InterlaceMethod switch
            {
                0 => await NegumContainer.Resolve<ISffPngNoInterlaceDecoder>().DecodeAsync(imageBytes, imageHeader),
                1 => await NegumContainer.Resolve<ISffPngAdam7InterlaceDecoder>().DecodeAsync(imageBytes, imageHeader),
                _ => throw new ArgumentException($"Unknown interlace method: {imageHeader.InterlaceMethod}")
            };

        protected virtual void ProcessFilter(byte[] data, int filterType,
            int previousIndex, int index, int currentIndex,
            int rowByteIndex, int bytesPerPixel)
        {
            byte GetLeftByteValue()
            {
                var leftIndex = rowByteIndex - bytesPerPixel;
                var leftValue = leftIndex >= 0 ? data[index + leftIndex] : (byte) 0;
                return leftValue;
            }

            byte GetAboveByteValue()
            {
                var upIndex = previousIndex + rowByteIndex;
                return upIndex >= 0 ? data[upIndex] : (byte) 0;
            }

            byte GetAboveLeftByteValue()
            {
                var validIndex = previousIndex + rowByteIndex - bytesPerPixel;
                return validIndex < previousIndex || previousIndex < 0 ? (byte) 0 : data[validIndex];
            }

            switch (filterType)
            {
                case 0: // The raw byte is unaltered
                    return;
                case 1: // The byte to the left
                    var leftIndex = rowByteIndex - bytesPerPixel;

                    if (leftIndex < 0)
                    {
                        return;
                    }

                    data[currentIndex] += data[index + leftIndex];
                    return;
                case 2: // The byte above
                    var above = previousIndex + rowByteIndex;

                    if (above < 0)
                    {
                        return;
                    }

                    data[currentIndex] += data[above];
                    return;
                case 3: // The mean of bytes left and above, rounded down
                    data[currentIndex] += (byte) ((GetLeftByteValue() + GetAboveByteValue()) / 2);
                    return;
                case 4: // Byte to the left, above or top-left based on Paeth's algorithm
                    var leftByte = GetLeftByteValue();
                    var aboveByte = GetAboveByteValue();
                    var aboveLeftByte = GetAboveLeftByteValue();
                    data[currentIndex] += GetPaethValue(leftByte, aboveByte, aboveLeftByte);
                    return;
            }
        }

        protected virtual byte GetPaethValue(byte leftByte, byte aboveByte, byte aboveLeftByte)
        {
            var delta = leftByte + aboveByte - aboveLeftByte;

            var deltaLeft = Math.Abs(delta - leftByte);
            var deltaAbove = Math.Abs(delta - aboveByte);
            var deltaAboveLeft = Math.Abs(delta - aboveLeftByte);

            if (deltaLeft <= deltaAbove && deltaLeft <= deltaAboveLeft)
            {
                return leftByte;
            }

            return deltaAbove <= deltaAboveLeft ? aboveByte : aboveLeftByte;
        }
    }
}