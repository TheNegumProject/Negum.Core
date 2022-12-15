using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Negum.Core.Exceptions;

namespace Negum.Core.Readers.Sff.V2.Png.Processors;

/// <summary>
/// Default processor used for IDAT chunk.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffPngChunkProcessor_IDAT : ISffPngChunkProcessor
{
    public string GetChunkName() => "IDAT";

    public string GetOutputStreamKey() => GetChunkName() + "_Output";

    public void ProcessChunk(byte[] chunkData, IDictionary<string, object> chunkProcessorState)
    {
        var chunkName = GetChunkName();

        Stream? stream;

        if (chunkProcessorState.TryGetValue(chunkName, out var value))
        {
            stream = value as Stream;
        }
        else
        {
            stream = new MemoryStream();
            chunkProcessorState.Add(chunkName, stream);
        }

        stream?.Write(chunkData);
    }

    public void PerformPostProcessing(IDictionary<string, object> chunkProcessorState)
    {
        var chunkName = GetChunkName();

        if (!chunkProcessorState.ContainsKey(chunkName))
        {
            throw new ArgumentException($"Cannot read {chunkName} key from processor state.");
        }

        var stream = chunkProcessorState[chunkName] as Stream;

        stream?.Flush();
        stream?.Seek(2, SeekOrigin.Begin);

        var outputStream = new MemoryStream();

        if (stream is null)
        {
            throw new NegumException("Stream is null.");
        }

        using (var deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
        {
            deflateStream.CopyTo(outputStream);
            deflateStream.Close();
        }

        chunkProcessorState.Add(GetOutputStreamKey(), outputStream);
    }

    public byte[] GetOutputBytes(IDictionary<string, object> chunkProcessorState)
    {
        var key = GetOutputStreamKey();

        if (!chunkProcessorState.ContainsKey(key))
        {
            throw new NegumException($"No output data found for key: '{key}'");
        }

        if (chunkProcessorState[key] is not Stream cachedOutputStream)
        {
            throw new NegumException("Stream is null");
        }
            
        cachedOutputStream.Position = 0;

        var outputStream = new MemoryStream();
        cachedOutputStream.CopyTo(outputStream);

        var outputBytes = outputStream.ToArray();

        return outputBytes;
    }
}