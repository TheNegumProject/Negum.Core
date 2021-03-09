using System.IO;

namespace Negum.Core.Loaders
{
    /// <summary>
    /// Represents a loader which is used to read entities from specified directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IDirectoryLoader<TOutput> : ILoader<DirectoryInfo, TOutput>
    {
    }
}