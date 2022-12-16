using System.Collections.Generic;

namespace Negum.Core.Readers.Sff.V2.Png.Processors;

/// <summary>
/// Default processor used for sBIT chunk.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffPngChunkProcessor_sBIT : ISffPngChunkProcessor
{
    public string GetChunkName() => "sBIT";

    public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
    {
        chunkProcessorState.Add(GetChunkName(), chunkData);
    }
}