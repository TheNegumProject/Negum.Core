using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a SFFv1 sprite definition.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffSpriteV1 : ISprite<ISpriteSubFileSffV1>
    {
        uint Groups { get; }
        uint Images { get; }
        uint PosFirstSubFile { get; }
        uint Length { get; }
        byte PaletteType { get; }
        string Blank { get; }
        string Comments { get; }
        IPalette Palette { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffSpriteV1 : Sprite<ISpriteSubFileSffV1>, ISffSpriteV1
    {
        public uint Groups { get; internal set; }
        public uint Images { get; internal set; }
        public uint PosFirstSubFile { get; internal set; }
        public uint Length { get; internal set; }
        public byte PaletteType { get; internal set; }
        public string Blank { get; internal set; }
        public string Comments { get; internal set; }
        public IPalette Palette { get; internal set; }
    }
}