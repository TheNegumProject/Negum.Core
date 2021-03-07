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
    public interface ISffSpriteV2 : ISprite<ISpriteSubFileSffV2>
    {
        IEnumerable<byte> Header { get; } // TODO: Unknown 20 bytes
        uint SpriteOffset { get; }
        uint SpriteNumber { get; }
        uint PaletteOffset { get; }
        uint PaletteNumber { get; }
        uint LDataOffset { get; }
        uint LDataLength { get; }
        uint TDataOffset { get; }
        uint TDataLength { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffSpriteV2 : Sprite<ISpriteSubFileSffV2>, ISffSpriteV2
    {
        public IEnumerable<byte> Header { get; internal set; }
        public uint SpriteOffset { get; internal set; }
        public uint SpriteNumber { get; internal set; }
        public uint PaletteOffset { get; internal set; }
        public uint PaletteNumber { get; internal set; }
        public uint LDataOffset { get; internal set; }
        public uint LDataLength { get; internal set; }
        public uint TDataOffset { get; internal set; }
        public uint TDataLength { get; internal set; }
    }
}