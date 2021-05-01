using System.Collections.Generic;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a SFFv2 sprite definition.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffSpriteV2 : ISprite
    {
        IEnumerable<byte> Unknown1 { get; } // TODO: ??
        uint PaletteMapOffset { get; }
        IEnumerable<byte> Unknown2 { get; } // TODO: ??
        uint SpriteOffset { get; }
        uint SpriteCount { get; }
        uint PaletteOffset { get; }
        uint PaletteCount { get; }
        uint LDataOffset { get; }
        uint LDataLength { get; }
        uint TDataOffset { get; }
        uint TDataLength { get; }
        IEnumerable<byte> Comment { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffSpriteV2 : Sprite, ISffSpriteV2
    {
        public IEnumerable<byte> Unknown1 { get; internal set; }
        public uint PaletteMapOffset { get; internal set; }
        public IEnumerable<byte> Unknown2 { get; internal set; }
        public uint SpriteOffset { get; internal set; }
        public uint SpriteCount { get; internal set; }
        public uint PaletteOffset { get; internal set; }
        public uint PaletteCount { get; internal set; }
        public uint LDataOffset { get; internal set; }
        public uint LDataLength { get; internal set; }
        public uint TDataOffset { get; internal set; }
        public uint TDataLength { get; internal set; }
        public IEnumerable<byte> Comment { get; internal set; }
    }
}