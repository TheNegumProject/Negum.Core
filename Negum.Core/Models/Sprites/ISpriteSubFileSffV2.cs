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
        ushort ItemNumber { get; }
        byte Format { get; }
        byte Depth { get; }
        uint DataOffset { get; }
        uint DataLength { get; }
        ushort PaletteIndex { get; }
        ushort Flags { get; }
        byte PngFormat { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFileSffV2 : SpriteSubFile, ISpriteSubFileSffV2
    {
        public ushort ItemNumber { get; internal set; }
        public byte Format { get; internal set; }
        public byte Depth { get; internal set; }
        public uint DataOffset { get; internal set; }
        public uint DataLength { get; internal set; }
        public ushort PaletteIndex { get; internal set; }
        public ushort Flags { get; internal set; }
        public byte PngFormat { get; internal set; }
    }
}