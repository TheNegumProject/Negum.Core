using System.Collections.Generic;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Pcx
{
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
        IPalette ColorPalette { get; }
        byte Reserved { get; }
        byte NbPlanes { get; }
        ushort Bpl { get; }
        ushort PaletteInfo { get; }
        IPalette Palette { get; }
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
        public byte Id { get; internal set; }
        public byte Version { get; internal set; }
        public byte Encoding { get; internal set; }
        public byte BitPerPixel { get; internal set; }
        public ushort X { get; internal set; }
        public ushort Y { get; internal set; }
        public ushort Width { get; internal set; }
        public ushort Height { get; internal set; }
        public ushort HRes { get; internal set; }
        public ushort VRes { get; internal set; }
        public IPalette ColorPalette { get; internal set; }
        public byte Reserved { get; internal set; }
        public byte NbPlanes { get; internal set; }
        public ushort Bpl { get; internal set; }
        public ushort PaletteInfo { get; internal set; }
        public IPalette Palette { get; internal set; }
        public byte Signature { get; internal set; }
        public IEnumerable<byte> Pixels { get; internal set; }
    }
}