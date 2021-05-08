using System;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png.Decoders
{
    /// <summary>
    /// PNG image interlace decoder.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngInterlaceDecoder
    {
        /// <summary>
        /// Decodes specified image bytes.
        /// </summary>
        /// <param name="imageBytes">PNG image bytes.</param>
        /// <param name="imageHeader">PNG image header.</param>
        /// <returns>Raw decoded PNG image.</returns>
        Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngInterlaceDecoder : ISffPngInterlaceDecoder
    {
        public async Task<byte[]> DecodeAsync(byte[] imageBytes, ISffPngImageHeader imageHeader) =>
            imageHeader.InterlaceMethod switch
            {
                0 => await NegumContainer.Resolve<ISffPngNoInterlaceDecoder>().DecodeAsync(imageBytes, imageHeader),
                1 => await NegumContainer.Resolve<ISffPngAdam7InterlaceDecoder>().DecodeAsync(imageBytes, imageHeader),
                _ => throw new ArgumentException($"Unknown interlace method: {imageHeader.InterlaceMethod}")
            };
    }
}