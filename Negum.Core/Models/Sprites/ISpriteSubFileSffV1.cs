using System.Collections.Generic;
using Negum.Core.Models.Palettes;
using Negum.Core.Models.Pcx;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a definition of a single sub-file in a sprite file in SFF v1.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFileSffV1 : ISpriteSubFile
    {
        uint NextSubFileOffset { get; }
        uint PcxDataLength { get; }
        ushort ImageNumber { get; }
        byte SamePalette { get; }
        IPcxImage PcxImage { get; }
        string Comment { get; }
        byte[] RawImage { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFileSffV1 : SpriteSubFile, ISpriteSubFileSffV1
    {
        public uint NextSubFileOffset { get; internal set; }
        public uint PcxDataLength { get; internal set; }
        public ushort ImageNumber { get; internal set; }
        public byte SamePalette { get; internal set; }
        public IPcxImage PcxImage { get; internal set; }
        public string Comment { get; internal set; }
        public byte[] RawImage { get; internal set; }
        public override IEnumerable<byte> Image => this.PcxImage.Pixels;
        public override ushort SpriteImageWidth => this.PcxImage.Width;
        public override ushort SpriteImageHeight => this.PcxImage.Height;
        public override IPalette Palette => this.PcxImage.Palette;
    }
}