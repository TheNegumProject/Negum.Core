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
        IEnumerable<ISpriteSubFile> SpriteSubFiles { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Sprite : ISprite
    {
        public string Signature { get; set; }
        public string Version { get; set; }
        public IEnumerable<ISpriteSubFile> SpriteSubFiles { get; } = new List<ISpriteSubFile>();

        public void AddSubFile(ISpriteSubFile subFile) =>
            ((List<ISpriteSubFile>) this.SpriteSubFiles).Add(subFile);
    }
}