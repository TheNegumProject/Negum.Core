using System;
using System.Collections.Generic;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Pcx;

/// <summary>
/// Represents a general model of an image read from the PCX file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPcxImage
{
    byte Id { get; }
    byte Version { get; }
    byte Encoding { get; }
    byte BitPerPixel { get; }
    ushort X { get; }
    ushort Y { get; }
    ushort Width { get; }
    ushort Height { get; }
    ushort HRes { get; }
    ushort VRes { get; }
    IPalette? ColorPalette { get; }
    byte Reserved { get; }
    byte NbPlanes { get; }
    ushort BitesPerLine { get; }
    ushort PaletteIndex { get; }
    IPalette? Palette { get; }
    byte Signature { get; }

    /// <summary>
    /// Each pixel is build out of 4 bytes (RGBA).
    /// </summary>
    IEnumerable<byte> Pixels { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PcxImage : IPcxImage
{
    public byte Id { get; internal init; }
    public byte Version { get; internal init; }
    public byte Encoding { get; internal init; }
    public byte BitPerPixel { get; internal init; }
    public ushort X { get; internal init; }
    public ushort Y { get; internal init; }
    public ushort Width { get; internal set; }
    public ushort Height { get; internal set; }
    public ushort HRes { get; internal init; }
    public ushort VRes { get; internal init; }
    public IPalette? ColorPalette { get; internal set; }
    public byte Reserved { get; internal set; }
    public byte NbPlanes { get; internal set; }
    public ushort BitesPerLine { get; internal set; }
    public ushort PaletteIndex { get; internal set; }
    public IPalette? Palette { get; internal set; }
    public byte Signature { get; internal set; }
    public IEnumerable<byte> Pixels { get; internal set; } = Array.Empty<byte>();
}