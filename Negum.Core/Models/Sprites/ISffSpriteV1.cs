using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Sprites;

/// <summary>
/// Represents a SFFv1 sprite definition.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffSpriteV1 : ISprite
{
    uint GroupCount { get; }
    uint ImageCount { get; }
    uint PosFirstSubFileOffset { get; }
    uint Length { get; }
    byte PaletteType { get; }
    string? Blank { get; }
    string? Comments { get; }
    IPalette? Palette { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffSpriteV1 : Sprite, ISffSpriteV1
{
    public uint GroupCount { get; internal init; }
    public uint ImageCount { get; internal init; }
    public uint PosFirstSubFileOffset { get; internal init; }
    public uint Length { get; internal init; }
    public byte PaletteType { get; internal init; }
    public string? Blank { get; internal init; }
    public string? Comments { get; internal init; }
    public IPalette? Palette { get; internal set; }
}