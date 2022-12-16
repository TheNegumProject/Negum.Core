namespace Negum.Core.Readers.Sff.V2.Png;

/// <summary>
/// Contains various helper methods for reading SFF v2 PNG images.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public static class SffPngHelper
{
    public const int ImageHeaderLength = 8;
    public const int ChunkHeaderLength = 13;
    public const int CrcDataLength = 4;

    /// <summary>
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="offset"></param>
    /// <returns>Big endian Int32 from given bytes.</returns>
    public static int ReadBigEndian(byte[] bytes, int offset)
    {
        return (bytes[0 + offset] << 24) |
               (bytes[1 + offset] << 16) |
               (bytes[2 + offset] << 8) |
               bytes[3 + offset];
    }
}