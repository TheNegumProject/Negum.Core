using System.Collections.Generic;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a SFFv1 sprite definition.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffSpriteV1 : ISprite
    {
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
    public class SffSpriteV1 : Sprite, ISffSpriteV1
    {
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