using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;
using Negum.Core.Readers.Sff.V2.Png;
using Negum.Core.Readers.Sff.V2.Png.Decoders;

namespace Negum.Core.Readers.Sff.V2
{
    /// <summary>
    /// Represents a reader which is used to read PNG files from SFF v2 sprite's sub-file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngReader : IReader<ISffPngReaderContext, IEnumerable<byte>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngReader : ISffPngReader
    {
        public async Task<IEnumerable<byte>> ReadAsync(ISffPngReaderContext input)
        {
            var rawImageStream = new MemoryStream(input.RawImage.ToArray());

            var pngImageHeaderReader = NegumContainer.Resolve<ISffPngImageHeaderReader>();
            var pngImageHeader = await pngImageHeaderReader.ReadAsync(rawImageStream);

            var pngImageDecoder = NegumContainer.Resolve<ISffPngDecoder>();
            var decodedPngImage = await pngImageDecoder.DecodeAsync(rawImageStream, pngImageHeader);

            var pngPaletteApplier = NegumContainer.Resolve<ISffPngPaletteApplier>();
            var pngImageWithPalette = await pngPaletteApplier.ApplyAsync(pngImageHeader, decodedPngImage, input.Palette);

            return pngImageWithPalette;
        }
    }
}