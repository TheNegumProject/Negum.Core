namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a definition of a single sub-file in a sprite file in SFF v2.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFileSffV2 : ISpriteSubFile
    {
        ushort SpriteNumber { get; }
        byte CompressionMethod { get; }
        byte ColorDepth { get; }
        uint DataOffset { get; }
        uint DataLength { get; }
        ushort PaletteIndex { get; }
        ushort LoadMode { get; }
        uint ImageSize { get; }
        byte[] RawImage { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFileSffV2 : SpriteSubFile, ISpriteSubFileSffV2
    {
        public ushort SpriteNumber { get; internal set; }
        public byte CompressionMethod { get; internal set; }
        public byte ColorDepth { get; internal set; }
        public uint DataOffset { get; internal set; }
        public uint DataLength { get; internal set; }
        public ushort PaletteIndex { get; internal set; }
        public ushort LoadMode { get; internal set; }
        public uint ImageSize { get; internal set; }
        public byte[] RawImage { get; internal set; }
    }
}