using System;
using System.Collections.Generic;
using Negum.Core.Models.Palettes;
using Negum.Core.Models.Pcx;

namespace Negum.Core.Models.Sprites;

/// <summary>
/// Represents a definition of a single sub-file in a sprite file in SFF v1.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISpriteSubFileSffV1 : ISpriteSubFile
{
    byte SamePalette { get; }
    IPcxImage? PcxImage { get; }
    string? Comment { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SpriteSubFileSffV1 : SpriteSubFile, ISpriteSubFileSffV1
{
    public byte SamePalette { get; internal init; }
    public IPcxImage? PcxImage { get; internal set; }
    public string? Comment { get; internal init; }
    public override IEnumerable<byte> Image => PcxImage?.Pixels ?? Array.Empty<byte>();
    public override ushort SpriteImageWidth => PcxImage?.Width ?? default;
    public override ushort SpriteImageHeight => PcxImage?.Height ?? default;
    public override IPalette? Palette => PcxImage?.Palette;
    public override ushort PaletteIndex => PcxImage?.PaletteIndex ?? default;
}