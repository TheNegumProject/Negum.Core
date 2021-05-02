using System.Collections.Generic;

namespace Negum.Core.Models.Sprites.Png
{
    /// <summary>
    /// PNG image header.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngImageHeader
    {
        /// <summary>
        /// Image width.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Image height.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Image bit depth.
        /// </summary>
        byte BitDepth { get; }

        /// <summary>
        /// Image color type.
        /// </summary>
        byte ColorType { get; }

        /// <summary>
        /// Image compression method.
        /// </summary>
        byte CompressionMethod { get; }

        /// <summary>
        /// Image filter method.
        /// </summary>
        byte FilterMethod { get; }

        /// <summary>
        /// Image interlace method.
        /// </summary>
        byte InterlaceMethod { get; }

        /// <summary>
        /// Number of pixels per byte.
        /// </summary>
        int PixelsPerByte { get; }

        /// <summary>
        /// Number of bytes in row.
        /// </summary>
        int BytesInRow { get; }

        /// <summary>
        /// Image row offset.
        /// </summary>
        int RowOffset { get; }

        /// <summary>
        /// </summary>
        /// <returns>Number of samples per pixel.</returns>
        byte GetSamplesPerPixel();

        /// <summary>
        /// </summary>
        /// <returns>Number of bytes per line.</returns>
        int GetBytesPerLine();

        /// <summary>
        /// </summary>
        /// <returns>Number of bytes per pixel.</returns>
        byte GetBytesPerPixel();

        /// <summary>
        /// </summary>
        /// <returns>Number of pixels in row.</returns>
        int GetPixelsPerRow();

        /// <summary>
        /// </summary>
        /// <returns>Buffer for post-decoding data.</returns>
        byte[] GetPostDecodingBuffer();
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngImageHeader : ISffPngImageHeader
    {
        public int Width { get; internal init; }
        public int Height { get; internal init; }

        public byte BitDepth { get; }
        public byte ColorType { get; }
        public byte CompressionMethod { get; }
        public byte FilterMethod { get; }
        public byte InterlaceMethod { get; }

        public int PixelsPerByte => 8 / this.BitDepth;
        public int BytesInRow => 1 + this.Width / this.PixelsPerByte;
        public int RowOffset => this.InterlaceMethod == 1 ? 0 : 1;

        public SffPngImageHeader(IReadOnlyList<byte> headerChunkBytes)
        {
            this.BitDepth = headerChunkBytes[8];
            this.ColorType = headerChunkBytes[9];
            this.CompressionMethod = headerChunkBytes[10];
            this.FilterMethod = headerChunkBytes[11];
            this.InterlaceMethod = headerChunkBytes[12];
        }

        public byte GetSamplesPerPixel() =>
            this.ColorType switch
            {
                0 => 1, // Greyscale
                1 => 1, // Colors are stored in a palette rather than directly in the data
                2 => 3, // The image uses color
                3 => 3, // Indexed color
                4 => 2, // The image has an alpha channel
                2 | 4 => 4,
                _ => 0
            };

        public int GetBytesPerLine() =>
            this.BitDepth switch
            {
                1 => (this.Width + 7) / 8,
                2 => (this.Width + 3) / 4,
                4 => (this.Width + 1) / 2,
                8 => this.Width * this.GetSamplesPerPixel() * (this.BitDepth / 8),
                16 => this.Width * this.GetSamplesPerPixel() * (this.BitDepth / 8),
                _ => 0
            };

        public virtual byte GetBytesPerPixel()
        {
            var bitDepthCorrected = (this.BitDepth + 7) / 8;
            var samplesPerPixel = this.GetSamplesPerPixel();

            return (byte) (samplesPerPixel * bitDepthCorrected);
        }

        public virtual int GetPixelsPerRow() =>
            this.Width * this.GetBytesPerPixel();

        public virtual byte[] GetPostDecodingBuffer() =>
            new byte[this.Height * this.GetPixelsPerRow()];
    }
}