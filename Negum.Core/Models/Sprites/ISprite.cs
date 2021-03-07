using System.Collections.Generic;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents general definition of a single sprite file (.sff)
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISprite
    {
        string Signature { get; }
        string Version { get; }
    }

    /// <summary>
    /// Adds possibility for sprite to expose multiple sub-files in single sprite.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISprite<TSubFile> : ISprite
    {
        IEnumerable<TSubFile> SpriteSubFiles { get; }

        /// <summary>
        /// Convenient method for adding new sub-files.
        /// </summary>
        /// <param name="subFile"></param>
        void AddSubFile(TSubFile subFile);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Sprite<TSubFile> : ISprite<TSubFile>
    {
        public string Signature { get; internal set; }
        public string Version { get; internal set; }
        public IEnumerable<TSubFile> SpriteSubFiles { get; } = new List<TSubFile>();

        public void AddSubFile(TSubFile subFile) =>
            ((List<TSubFile>) this.SpriteSubFiles).Add(subFile);
    }
}