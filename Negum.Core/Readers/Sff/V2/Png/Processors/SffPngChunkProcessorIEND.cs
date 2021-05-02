using System.Collections.Generic;

namespace Negum.Core.Readers.Sff.V2.Png.Processors
{
    /// <summary>
    /// Default processor used for IEND chunk.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkProcessorIEND : ISffPngChunkProcessor
    {
        public string GetChunkName() => "IEND";

        public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
        {
            chunkProcessorState.Add(this.GetChunkName(), true);
        }

        public bool IsProcessingFinished(IDictionary<string, object> chunkProcessorState)
        {
            return chunkProcessorState.ContainsKey(this.GetChunkName()) &&
                   bool.Parse(chunkProcessorState[this.GetChunkName()].ToString());
        }
    }
}