using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png.Processors
{
    /// <summary>
    /// Default processor used for pHYs chunk.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkProcessor_pHYs : ISffPngChunkProcessor
    {
        public string GetChunkName() => "pHYs";

        public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
        {
            var span = new ReadOnlySpan<byte>(chunkData);

            var hResolution = BinaryPrimitives.ReadUInt32BigEndian(span[..4]);
            var vResolution = BinaryPrimitives.ReadUInt32BigEndian(span.Slice(4, 4));
            var unit = chunkData[8];

            var physicalChunkData = new SffPngPhysicalChunkData
            {
                PixelsPerUnitX = hResolution,
                PixelsPerUnityY = vResolution,
                Unit = unit,
            };

            chunkProcessorState.Add(this.GetChunkName(), physicalChunkData);
        }
    }
}