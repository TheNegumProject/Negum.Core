using System.Collections.Generic;
using Negum.Core.Models.Palettes;

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
        uint Groups { get; }
        uint Images { get; }
        uint PosFirstSubFile { get; }
        uint Length { get; }
        byte PaletteType { get; }
        string Blank { get; }
        string Comments { get; }
        IEnumerable<ISpriteSubFile> SpriteSubFiles { get; }
        IPalette Palette { get; }

        /// <summary>
        /// Convenient method for adding new sub-files.
        /// </summary>
        /// <param name="subFile"></param>
        void AddSubFile(ISpriteSubFile subFile);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class Sprite : ISprite
    {
        public string Signature { get; internal set; }
        public string Version { get; internal set; }
        public uint Groups { get; internal set; }
        public uint Images { get; internal set; }
        public uint PosFirstSubFile { get; internal set; }
        public uint Length { get; internal set; }
        public byte PaletteType { get; internal set; }
        public string Blank { get; internal set; }
        public string Comments { get; internal set; }

        public IEnumerable<ISpriteSubFile> SpriteSubFiles { get; } = new List<ISpriteSubFile>();
        public IPalette Palette { get; internal set; }

        public void AddSubFile(ISpriteSubFile subFile) =>
            ((List<ISpriteSubFile>) this.SpriteSubFiles).Add(subFile);
    }
}