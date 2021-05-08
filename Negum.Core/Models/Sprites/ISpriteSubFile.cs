using System.Collections.Generic;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a container which contains a file data for single sprite sub-file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFile
    {
        /// <summary>
        /// Image returned from reader.
        /// </summary>
        IEnumerable<byte> Image { get; }

        /// <summary>
        /// Width of the image.
        /// </summary>
        ushort SpriteImageWidth { get; }

        /// <summary>
        /// Height of the image.
        /// </summary>
        ushort SpriteImageHeight { get; }

        /// <summary>
        /// Number of the group in which the current sprite is.
        /// </summary>
        ushort SpriteGroup { get; }

        /// <summary>
        /// X-axis offset.
        /// </summary>
        ushort SpriteImageXAxis { get; }

        /// <summary>
        /// Y-axis offset.
        /// </summary>
        ushort SpriteImageYAxis { get; }

        /// <summary>
        /// Index of the current sprite.
        /// </summary>
        ushort SpriteLinkedIndex { get; }

        /// <summary>
        /// Palette used for the current image.
        /// </summary>
        IPalette Palette { get; }

        /// <summary>
        /// Raw image read from SFF file.
        /// </summary>
        byte[] RawImage { get; }

        /// <summary>
        /// Sprite number in SFF file.
        /// </summary>
        ushort SpriteNumber { get; }

        /// <summary>
        /// Offset to sprite data.
        /// </summary>
        uint DataOffset { get; }

        /// <summary>
        /// Sprite's size.
        /// </summary>
        uint DataLength { get; }

        /// <summary>
        /// Palette used to color this sprite.
        /// </summary>
        ushort PaletteIndex { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class SpriteSubFile : ISpriteSubFile
    {
        public virtual IEnumerable<byte> Image { get; internal set; }
        public virtual ushort SpriteImageWidth { get; internal set; }
        public virtual ushort SpriteImageHeight { get; internal set; }
        public virtual ushort SpriteGroup { get; internal set; }
        public virtual ushort SpriteImageXAxis { get; internal set; }
        public virtual ushort SpriteImageYAxis { get; internal set; }
        public virtual ushort SpriteLinkedIndex { get; internal set; }
        public virtual IPalette Palette { get; internal set; }
        public virtual byte[] RawImage { get; internal set; }
        public virtual ushort SpriteNumber { get; internal set; }
        public virtual uint DataOffset { get; internal set; }
        public virtual uint DataLength { get; internal set; }
        public virtual ushort PaletteIndex { get; internal set; }
    }
}