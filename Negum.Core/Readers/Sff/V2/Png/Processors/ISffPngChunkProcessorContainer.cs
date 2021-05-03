using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png.Processors
{
    /// <summary>
    /// Container responsible for holding processors for various chunks.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngChunkProcessorContainer
    {
        /// <summary>
        /// Registers new chunk processor.
        /// </summary>
        /// <param name="processor">Processor to register.</param>
        void RegisterChunkProcessor(ISffPngChunkProcessor processor);

        /// <summary>
        /// Calls all registered chunk processors for handling the chunk.
        /// </summary>
        /// <param name="chunkHeader">Head of the chunk which will be processed.</param>
        /// <param name="chunkData">Chunk data read from stream.</param>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        void ProcessChunk(ISffPngChunkHeader chunkHeader, byte[] chunkData,
            IDictionary<string, object> chunkProcessorState);

        /// <summary>
        /// Indicates to decoder that the processing of an image should be finished.
        /// Technically only IEND chunk should return true here.
        /// </summary>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        /// <returns>True for IEND chunk; otherwise false.</returns>
        bool IsProcessingFinished(IDictionary<string, object> chunkProcessorState);

        /// <summary>
        /// Allows for additional processing of an image after the image was read from stream.
        /// </summary>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        void PerformPostProcessing(IDictionary<string, object> chunkProcessorState);

        /// <summary>
        /// Method which is used by IDAT chunk to return read image data. 
        /// </summary>
        /// <param name="chunkProcessorState">Common state used across all chunk processors.</param>
        /// <returns>Stream with read image data.</returns>
        byte[] GetOutputBytes(IDictionary<string, object> chunkProcessorState);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkProcessorContainer : ISffPngChunkProcessorContainer
    {
        /// <summary>
        /// Collection with all currently registered chunk processors.
        /// </summary>
        private static IProducerConsumerCollection<ISffPngChunkProcessor> Processors { get; } =
            new ConcurrentBag<ISffPngChunkProcessor>();

        static SffPngChunkProcessorContainer()
        {
            // Critical
            Processors.TryAdd(new SffPngChunkProcessor_PLTE());
            Processors.TryAdd(new SffPngChunkProcessor_IDAT());
            Processors.TryAdd(new SffPngChunkProcessor_IEND());

            // Ancillary
            Processors.TryAdd(new SffPngChunkProcessor_pHYs());
            Processors.TryAdd(new SffPngChunkProcessor_sBIT());
        }

        public void RegisterChunkProcessor(ISffPngChunkProcessor processor)
        {
            if (!Processors.TryAdd(processor))
            {
                throw new ArgumentException($"Cannot add chunk processor: {processor}");
            }
        }

        public void ProcessChunk(ISffPngChunkHeader chunkHeader, byte[] chunkData,
            IDictionary<string, object> chunkProcessorState)
        {
            var validProcessors = Processors.Where(proc => proc.GetChunkName().Equals(chunkHeader.Name));

            foreach (var processor in validProcessors)
            {
                processor.ProcessChunk(chunkData, chunkProcessorState);
            }
        }

        public bool IsProcessingFinished(IDictionary<string, object> chunkProcessorState) =>
            Processors.Any(proc => proc.IsProcessingFinished(chunkProcessorState));

        public void PerformPostProcessing(IDictionary<string, object> chunkProcessorState)
        {
            foreach (var processor in Processors)
            {
                processor.PerformPostProcessing(chunkProcessorState);
            }
        }

        public byte[] GetOutputBytes(IDictionary<string, object> chunkProcessorState)
        {
            foreach (var processor in Processors)
            {
                var outputBytesStream = processor.GetOutputBytes(chunkProcessorState);

                if (outputBytesStream != null)
                {
                    return outputBytesStream;
                }
            }

            throw new ArgumentException($"Cannot find output image data.");
        }
    }
}