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
        /// <summary>
        /// Contains image raw data.
        /// </summary>
        IEnumerable<byte> Image { get; }

        /// <summary>
        /// Width of the image.
        /// </summary>
        ushort Width { get; }

        /// <summary>
        /// Height of the image.
        /// </summary>
        ushort Height { get; }

        /// <summary>
        /// Number of the group in which the current sprite is.
        /// </summary>
        ushort GroupNumber { get; }

        /// <summary>
        /// X-axis offset.
        /// </summary>
        ushort X { get; }

        /// <summary>
        /// Y-axis offset.
        /// </summary>
        ushort Y { get; }

        /// <summary>
        /// Index of the current sprite.
        /// </summary>
        ushort Index { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class SpriteSubFile : ISpriteSubFile
    {
        public virtual IEnumerable<byte> Image { get; internal set; }
        public virtual ushort Width { get; internal set; }
        public virtual ushort Height { get; internal set; }
        public virtual ushort GroupNumber { get; internal set; }
        public virtual ushort X { get; internal set; }
        public virtual ushort Y { get; internal set; }
        public virtual ushort Index { get; internal set; }
    }
}