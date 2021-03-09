using System.IO;

namespace Negum.Core.Models.Sounds
{
    /// <summary>
    /// Represents a single sound read from appropriate directory.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISound
    {
        /// <summary>
        /// File from which th current Sound was read.
        /// </summary>
        FileInfo File { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Sound : ISound
    {
        public FileInfo File { get; internal set; }
    }
}