using System.IO;

namespace Negum.Core.Models;

/// <summary>
/// Represents an object which was read from file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFileReadable
{
    /// <summary>
    /// File from which the current object was read.
    /// </summary>
    FileInfo? File { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FileReadable : IFileReadable
{
    public FileInfo? File { get; internal set; }
}