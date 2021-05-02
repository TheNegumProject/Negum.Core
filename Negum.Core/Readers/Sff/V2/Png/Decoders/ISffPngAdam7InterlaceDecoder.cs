using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly IReadOnlyDictionary<int, int[]> PassToScanlineGridIndex = new Dictionary<int, int[]>
        {
            {1, new[] {0}},
            {2, new[] {0}},
            {3, new[] {4}},
            {4, new[] {0, 4}},
            {5, new[] {2, 6}},
            {6, new[] {0, 2, 4, 6}},
            {7, new[] {1, 3, 5, 7}}
        };

        private static readonly IReadOnlyDictionary<int, int[]> PassToScanlineColumnIndex = new Dictionary<int, int[]>
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
            var bytesPerPixel = imageHeader.GetBytesPerPixel();
            var pixelsPerRow = imageHeader.GetPixelsPerRow();
            var newSizeBytes = imageHeader.GetPostDecodingBuffer();
            var index = 0;
            var previousIndex = -1;

            for (var i = 0; i < 7; ++i)
            {
                var lines = this.GetScanlines(imageHeader, i);
                var pixelsPerLine = this.GetPixelsPerScanline(imageHeader, i);

                if (lines <= 0 || pixelsPerLine <= 0)
                {
                    continue;
                }

                for (var lineIndex = 0; lineIndex < lines; ++lineIndex)
                {
                    var filterType = imageBytes[index++];
                    var startByte = index;

                    for (var pixel = 0; pixel < pixelsPerLine; ++pixel)
                    {
                        this.ReadPixelIndex(i, lineIndex, pixel, out var pixelPosX, out var pixelPosY);

                        for (var b = 0; b < bytesPerPixel; ++b)
                        {
                            var byteLine = pixel * bytesPerPixel + b;

                            ProcessFilter(
                                imageBytes, filterType,
                                previousIndex, startByte, index,
                                byteLine, bytesPerPixel);

                            index++;
                        }

                        var start = pixelsPerRow * pixelPosY + pixelPosX * bytesPerPixel;
                        Array.ConstrainedCopy(imageBytes, startByte + pixel * bytesPerPixel,
                            newSizeBytes, start,
                            bytesPerPixel);
                    }

                    previousIndex = startByte;
                }
            }

            return newSizeBytes;
        }

        protected virtual int GetScanlines(ISffPngImageHeader imageHeader, int iteration)
        {
            var indices = PassToScanlineGridIndex[iteration + 1];
            var is8Pixels = imageHeader.Height % 8;
            var isValid = is8Pixels == 0;

            if (isValid)
            {
                return indices.Length * (imageHeader.Height / 8);
            }

            var extraLines = indices.Count(index => index < is8Pixels);

            return indices.Length * (imageHeader.Height / 8) + extraLines;
        }

        protected virtual int GetPixelsPerScanline(ISffPngImageHeader imageHeader, int iteration)
        {
            var indices = PassToScanlineColumnIndex[iteration + 1];
            var is8Pixels = imageHeader.Width % 8;
            var isValid = is8Pixels == 0;

            if (isValid)
            {
                return indices.Length * (imageHeader.Width / 8);
            }

            var extraColumns = indices.Count(index => index < is8Pixels);

            return indices.Length * (imageHeader.Width / 8) + extraColumns;
        }

        protected virtual void ReadPixelIndex(int iteration, int lineIndex, int pixelIndex,
            out int pixelPosX, out int pixelPosY)
        {
            var columnIndices = PassToScanlineColumnIndex[iteration + 1];
            var rows = PassToScanlineGridIndex[iteration + 1];

            var row = lineIndex % rows.Length;
            var column = pixelIndex % columnIndices.Length;

            var previousRow = 8 * (lineIndex / rows.Length);
            var previousColumn = 8 * (pixelIndex / columnIndices.Length);

            pixelPosX = previousColumn + columnIndices[column];
            pixelPosY = previousRow * rows[row];
        }
    }
}