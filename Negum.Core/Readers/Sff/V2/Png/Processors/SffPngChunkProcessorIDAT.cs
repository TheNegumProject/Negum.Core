using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Negum.Core.Readers.Sff.V2.Png.Processors
{
    /// <summary>
    /// Default processor used for IDAT chunk.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngChunkProcessorIDAT : ISffPngChunkProcessor
    {
        public string GetChunkName() => "IDAT";

        public string GetOutputStreamKey() => this.GetChunkName() + "_Output";

        public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
        {
            var chunkName = this.GetChunkName();

            Stream stream;

            if (chunkProcessorState.ContainsKey(chunkName))
            {
                stream = chunkProcessorState[chunkName] as Stream;
            }
            else
            {
                stream = new MemoryStream();
                chunkProcessorState.Add(chunkName, stream);
            }

            stream.Write(chunkData);
        }

        public void PerformPostProcessing(IDictionary<string, object> chunkProcessorState)
        {
            var chunkName = this.GetChunkName();

            if (!chunkProcessorState.ContainsKey(chunkName))
            {
                throw new ArgumentException($"Cannot read {chunkName} key from processor state.");
            }

            var stream = chunkProcessorState[chunkName] as Stream;

            stream.Flush();
            stream.Seek(2, SeekOrigin.Begin);

            var outputStream = new MemoryStream();

            using (var deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
            {
                deflateStream.CopyTo(outputStream);
                deflateStream.Close();
            }

            chunkProcessorState.Add(this.GetOutputStreamKey(), outputStream);
        }

        public byte[] GetOutputBytes(IDictionary<string, object> chunkProcessorState)
        {
            var key = this.GetOutputStreamKey();

            if (!chunkProcessorState.ContainsKey(key))
            {
                return null;
            }

            var cachedOutputStream = chunkProcessorState[key] as Stream;
            cachedOutputStream.Position = 0;

            var outputStream = new MemoryStream();
            cachedOutputStream.CopyTo(outputStream);

            var outputBytes = outputStream.ToArray();

            return outputBytes;
        }
    }
}