using System.Collections.Generic;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a container which contains a file data for single sprite sub-file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFile
    {
        IEnumerable<byte> Image { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFile : ISpriteSubFile
    {
        public IEnumerable<byte> Image { get; internal set; }
    }
}