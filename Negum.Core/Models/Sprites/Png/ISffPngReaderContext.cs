using System.Collections.Generic;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Sprites.Png
{
    /// <summary>
    /// Context which is used when reading SFF v2 PNG image.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngReaderContext
    {
        /// <summary>
        /// Format of a PNG file.
        /// Indicates the total number of bytes per pixel.
        ///     - PNG8 = 8
        ///     - PNG24 = 24
        ///     - PNG32 = 32
        /// </summary>
        int PngFormat { get; }

        /// <summary>
        /// Palette which should be used when parsing current image.
        /// </summary>
        IPalette Palette { get; }

        /// <summary>
        /// Raw bytes from which the image should be read.
        /// </summary>
        IEnumerable<byte> RawImage { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public partial class SffPngReaderContext : ISffPngReaderContext
    {
        public int PngFormat { get; set; }
        public IPalette Palette { get; set; }
        public IEnumerable<byte> RawImage { get; set; }
    }
}