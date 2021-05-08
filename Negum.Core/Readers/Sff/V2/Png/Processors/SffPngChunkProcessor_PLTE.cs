using System.Collections.Generic;
using Negum.Core.Containers;

namespace Negum.Core.Readers.Sff.V2.Png.Processors
{
    /// <summary>
    /// Default processor used for PLTE chunk.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkProcessor_PLTE : ISffPngChunkProcessor
    {
        public string GetChunkName() => "PLTE";

        public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
        {
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();
            var palette = paletteReader.ReadAsync(chunkData).Result;

            chunkProcessorState.Add(this.GetChunkName(), palette);
        }
    }
}