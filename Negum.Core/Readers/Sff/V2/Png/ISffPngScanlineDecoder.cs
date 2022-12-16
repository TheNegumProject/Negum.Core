using System;
using System.Threading.Tasks;

namespace Negum.Core.Readers.Sff.V2.Png;

/// <summary>
/// Decodes SFF v2 PNG scanline based on the filter type.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffPngScanlineDecoder
{
    /// <summary>
    /// Decodes specified scanline using the known filter.
    /// </summary>
    /// <param name="scanline">Image scanline which should be decoded.</param>
    /// <param name="previousScanline">Previous image scanline.</param>
    /// <param name="bytesPerPixel">Number of bytes per pixel.</param>
    /// <returns>Decoded scanline.</returns>
    Task<byte[]> DecodeAsync(byte[] scanline, byte[] previousScanline, int bytesPerPixel);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffPngScanlineDecoder : ISffPngScanlineDecoder
{
    public Task<byte[]> DecodeAsync(byte[] scanline, byte[] previousScanline, int bytesPerPixel) =>
        Task.FromResult(DecodeInternal(scanline, previousScanline, bytesPerPixel));

    private byte[] DecodeInternal(byte[] scanline, byte[] previousScanline, int bytesPerPixel) =>
        scanline[0] switch
        {
            0 => scanline, // Skip filterType byte
            1 => DecodeSubFilter(scanline, bytesPerPixel),
            2 => DecodeUpFilter(scanline, previousScanline),
            3 => DecodeAverageFilter(scanline, previousScanline, bytesPerPixel),
            4 => DecodePaethFilter(scanline, previousScanline, bytesPerPixel),
            _ => scanline // TODO: throw new ArgumentException($"Unknown filter: {scanline[0]}")
        };

    protected virtual byte[] DecodeSubFilter(byte[] scanline, int bytesPerPixel)
    {
        for (var index = 1 + bytesPerPixel; index < scanline.Length; ++index)
        {
            scanline[index] += scanline[index - bytesPerPixel];
        }

        return scanline;
    }

    protected virtual byte[] DecodeUpFilter(byte[] scanline, byte[] previousScanline)
    {
        for (var index = 1; index < scanline.Length; ++index)
        {
            scanline[index] += previousScanline[index];
        }

        return scanline;
    }

    protected virtual byte[] DecodeAverageFilter(byte[] scanline, byte[] previousScanline, int bytesPerPixel)
    {
        var index = 1; // At 0 we have filterType

        for (; index <= bytesPerPixel; ++index)
        {
            scanline[index] = (byte) (scanline[index] + (previousScanline[index] >> 1));
        }

        for (; index < scanline.Length; ++index)
        {
            var left = scanline[index - bytesPerPixel];
            var above = previousScanline[index];

            scanline[index] = (byte) (scanline[index] + ((left + above) >> 1));
        }

        return scanline;
    }

    protected virtual byte[] DecodePaethFilter(byte[] scanline, byte[] previousScanline, int bytesPerPixel)
    {
        var index = 1;

        for (; index < 1 + bytesPerPixel; ++index)
        {
            scanline[index] += previousScanline[index];
        }

        for (; index < scanline.Length; ++index)
        {
            var left = scanline[index - bytesPerPixel];
            var above = previousScanline[index];
            var aboveLeft = previousScanline[index - bytesPerPixel];

            scanline[index] += GetPaethValue(left, above, aboveLeft);
        }

        return scanline;
    }

    protected virtual byte GetPaethValue(byte left, byte above, byte aboveLeft)
    {
        var initialEstimate = left + above - aboveLeft;

        var distanceToLeft = Math.Abs(initialEstimate - left);
        var distanceToAbove = Math.Abs(initialEstimate - above);
        var distanceToAboveLeft = Math.Abs(initialEstimate - aboveLeft);

        if (distanceToLeft <= distanceToAbove && distanceToLeft <= distanceToAboveLeft)
        {
            return left;
        }

        return distanceToAbove <= distanceToAboveLeft ? above : aboveLeft;
    }
}