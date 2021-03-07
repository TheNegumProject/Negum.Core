using System.Collections.Generic;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a definition of a single sub-file in a sprite file in SFF v2.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFileSffV2
    {
        ushort Group { get; }
        ushort Index { get; }
        ushort Width { get; }
        ushort Height { get; }
        ushort X { get; }
        ushort Y { get; }
        ushort LinkIndex { get; }
        byte Format { get; }
        byte Depth { get; }
        uint DataOffset { get; }
        uint DataLength { get; }
        ushort PaletteIndex { get; }
        ushort Flags { get; }
        IEnumerable<byte> Image { get; }
        IEnumerable<byte> Palette { get; }
        byte PngFormat { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFileSffV2 : ISpriteSubFileSffV2
    {
        public ushort Group { get; internal set; }
        public ushort Index { get; internal set; }
        public ushort Width { get; internal set; }
        public ushort Height { get; internal set; }
        public ushort X { get; internal set; }
        public ushort Y { get; internal set; }
        public ushort LinkIndex { get; internal set; }
        public byte Format { get; internal set; }
        public byte Depth { get; internal set; }
        public uint DataOffset { get; internal set; }
        public uint DataLength { get; internal set; }
        public ushort PaletteIndex { get; internal set; }
        public ushort Flags { get; internal set; }
        public IEnumerable<byte> Image { get; internal set; }
        public IEnumerable<byte> Palette { get; internal set; }
        public byte PngFormat { get; internal set; }
    }
}