using System.Collections.Generic;

namespace Negum.Core.Models.Sprites.Png;

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
    int GetBytesPerLine(int width = -1);

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

    public int PixelsPerByte => 8 / BitDepth;
    public int BytesInRow => 1 + Width / PixelsPerByte;
    public int RowOffset => InterlaceMethod == 1 ? 0 : 1;

    public SffPngImageHeader(IReadOnlyList<byte> headerChunkBytes)
    {
        BitDepth = headerChunkBytes[8];
        ColorType = headerChunkBytes[9];
        CompressionMethod = headerChunkBytes[10];
        FilterMethod = headerChunkBytes[11];
        InterlaceMethod = headerChunkBytes[12];
    }

    public byte GetSamplesPerPixel() =>
        ColorType switch
        {
            0 => (byte) (BitDepth == 16 ? 2 : 1), // Grayscale
            1 => 1, // Colors are stored in a palette rather than directly in the data
            2 => (byte) (BitDepth == 16 ? 6 : 3), // RGB
            3 => 1, // Indexed color (Palette)
            4 => (byte) (BitDepth == 16 ? 4 : 2), // Grayscale + alpha channel
            6 => (byte) (BitDepth == 16 ? 8 : 4), // RGB + alpha channel
            _ => (byte) (BitDepth == 16 ? 8 : 4) // Default ==>> RGB + alpha
        };

    public int GetBytesPerLine(int width = -1)
    {
        if (width == -1)
        {
            width = Width;
        }
            
        var mod = BitDepth == 16 ? 16 : 8;
        var scanlineLength = width * BitDepth * GetBytesPerPixel();
        var amount = scanlineLength % mod;
            
        if (amount != 0)
        {
            scanlineLength += mod - amount;
        }

        // +1 ==>> We want to read bytes from at least one byte
        return scanlineLength / mod + 1;
    }

    public virtual byte GetBytesPerPixel()
    {
        var bitDepthCorrected = (BitDepth + 7) / 8;
        var samplesPerPixel = GetSamplesPerPixel();

        return (byte) (samplesPerPixel * bitDepthCorrected);
    }

    public virtual int GetPixelsPerRow() =>
        Width * GetBytesPerPixel();

    public virtual byte[] GetPostDecodingBuffer() =>
        new byte[Height * GetPixelsPerRow()];
}