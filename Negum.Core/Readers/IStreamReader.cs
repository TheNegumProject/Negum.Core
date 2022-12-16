using System.IO;

namespace Negum.Core.Readers;

/// <summary>
/// Reader which is designed to handle streams.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IStreamReader<TOutput> : IReader<Stream, TOutput>
{
}