using System.Collections.Generic;

namespace Negum.Core.Readers.Sff.V2.Png.Processors;

/// <summary>
/// Default processor used for IEND chunk.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffPngChunkProcessor_IEND : ISffPngChunkProcessor
{
    public string GetChunkName() => "IEND";

    public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
    {
        chunkProcessorState.Add(GetChunkName(), true);
    }

    public bool IsProcessingFinished(IDictionary<string, object> chunkProcessorState)
    {
        if (chunkProcessorState.TryGetValue(GetChunkName(), out var chunkData)
            && bool.TryParse(chunkData.ToString(), out var isFinished))
        {
            return isFinished;
        }

        return false;
    }
}