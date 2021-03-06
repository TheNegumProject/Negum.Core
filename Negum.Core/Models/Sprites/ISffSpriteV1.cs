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
        IEnumerable<ISpriteSubFileSffV1> SpriteSubFiles { get; }
        IPalette Palette { get; }

        /// <summary>
        /// Convenient method for adding new sub-files.
        /// </summary>
        /// <param name="subFileSffV1"></param>
        void AddSubFile(ISpriteSubFileSffV1 subFileSffV1);
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

        public IEnumerable<ISpriteSubFileSffV1> SpriteSubFiles { get; } = new List<ISpriteSubFileSffV1>();
        public IPalette Palette { get; internal set; }

        public void AddSubFile(ISpriteSubFileSffV1 subFileSffV1) =>
            ((List<ISpriteSubFileSffV1>) this.SpriteSubFiles).Add(subFileSffV1);
    }
}