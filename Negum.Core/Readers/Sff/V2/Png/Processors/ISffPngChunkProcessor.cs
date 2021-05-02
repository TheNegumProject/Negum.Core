using System.Collections.Generic;

namespace Negum.Core.Readers.Sff.V2.Png.Processors
{
    /// <summary>
    /// Processor which is responsible for handling single chunk type.
    /// Various processors can be registered for the same chunk type.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngChunkProcessor
    {
        /// <summary>
        /// </summary>
        /// <returns>Name of chunk which should be processed by this processor.</returns>
        string GetChunkName();

        /// <summary>
        /// Main processing method.
        /// </summary>
        /// <param name="chunkData">Data of the chunk, read from stream.</param>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
        {
        }

        /// <summary>
        /// Indicates if the processing of an image should end.
        /// Technically only IEND chunk should return true here.
        /// </summary>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        /// <returns>True for IEND chunk; otherwise false.</returns>
        bool IsProcessingFinished(IDictionary<string, object> chunkProcessorState) => false;

        /// <summary>
        /// Allows for additional operations after the image has been read from stream.
        /// </summary>
        /// <param name="chunkProcessorState"></param>
        void PerformPostProcessing(Dictionary<string, object> chunkProcessorState)
        {
        }

        /// <summary>
        /// Method which is used by IDAT chunk to return read image data. 
        /// </summary>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        /// <returns>Stream with read image data.</returns>
        byte[] GetOutputBytes(Dictionary<string, object> chunkProcessorState) => null;
    }
}