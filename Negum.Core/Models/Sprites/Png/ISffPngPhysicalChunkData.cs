namespace Negum.Core.Models.Sprites.Png
{
    /// <summary>
    /// Represents data read from pHYs chunk from PNG file.
    /// Specified the pixel size / aspect ratio.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngPhysicalChunkData
    {
        uint PixelsPerUnitX { get; }
        uint PixelsPerUnitY { get; }

        /// <summary>
        /// 0: Unknown - defines aspect ratio only
        /// 1: Meter
        /// </summary>
        byte Unit { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngPhysicalChunkData : ISffPngPhysicalChunkData
    {
        public uint PixelsPerUnitX { get; internal set; }
        public uint PixelsPerUnitY { get; internal set; }
        public byte Unit { get; internal set; }
    }
}