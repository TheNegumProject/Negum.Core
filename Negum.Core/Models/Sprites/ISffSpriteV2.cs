using System;
using System.Collections.Generic;

namespace Negum.Core.Models.Sprites;

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
    public IEnumerable<byte> Unknown1 { get; internal init; } = Array.Empty<byte>();
    public uint PaletteMapOffset { get; internal init; }
    public IEnumerable<byte> Unknown2 { get; internal init; } = Array.Empty<byte>();
    public uint SpriteOffset { get; internal init; }
    public uint SpriteCount { get; internal init; }
    public uint PaletteOffset { get; internal init; }
    public uint PaletteCount { get; internal init; }
    public uint LDataOffset { get; internal init; }
    public uint LDataLength { get; internal init; }
    public uint TDataOffset { get; internal init; }
    public uint TDataLength { get; internal init; }
    public IEnumerable<byte> Comment { get; internal init; } = Array.Empty<byte>();
}