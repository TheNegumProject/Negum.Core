using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;
using Negum.Core.Readers.Sff.V2.Png.Processors;

namespace Negum.Core.Readers.Sff.V2.Png.Decoders
{
    /// <summary>
    /// PNG image decoder.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngDecoder
    {
        /// <summary>
        /// Decodes PNG image from the specified stream.
        /// </summary>
        /// <param name="stream">Stream with PNG image.</param>
        /// <param name="imageHeader">PNG image header.</param>
        /// <returns>Raw decoded PNG image.</returns>
        Task<byte[]> DecodeAsync(Stream stream, ISffPngImageHeader imageHeader);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngDecoder : ISffPngDecoder
    {
        public async Task<byte[]> DecodeAsync(Stream stream, ISffPngImageHeader imageHeader)
        {
            var chunkHeaderReader = NegumContainer.Resolve<ISffPngChunkHeaderReader>();
            var chunkProcessorContainer = NegumContainer.Resolve<ISffPngChunkProcessorContainer>();

            var chunkProcessorState = new Dictionary<string, object>();

            while (true)
            {
                if (chunkProcessorContainer.IsProcessingFinished(chunkProcessorState))
                {
                    break;
                }

                var chunkHeader = await chunkHeaderReader.ReadAsync(stream);

                var chunkData = new byte[chunkHeader.Length];

                if (stream.Read(chunkData) != chunkHeader.Length)
                {
                    throw new ArgumentException($"Cannot read chunk data.");
                }

                chunkProcessorContainer.ProcessChunk(chunkHeader, chunkData, chunkProcessorState);

                var crcData = new byte[SffPngHelper.CrcDataLength];

                if (stream.Read(crcData) != SffPngHelper.CrcDataLength)
                {
                    throw new ArgumentException($"Cannot read CRC data for chunk: {chunkHeader.Name}");
                }

                // TODO: Do we need to validate CRC ???
            }

            chunkProcessorContainer.PerformPostProcessing(chunkProcessorState);

            var outputBytes = chunkProcessorContainer.GetOutputBytes(chunkProcessorState);

            var pngInterlaceDecoder = NegumContainer.Resolve<ISffPngInterlaceDecoder>();
            var decodedOutputBytes = await pngInterlaceDecoder.DecodeAsync(outputBytes, imageHeader);

            return decodedOutputBytes;
        }
    }
}