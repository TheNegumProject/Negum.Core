namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a definition of a single sub-file in a sprite file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFile
    {
        ushort X { get; }
        ushort Y { get; }
        ushort GroupNumber { get; }
        ushort ImageNumber { get; }
        ushort IndexPreviousCopy { get; }
        byte SamePalette { get; }
        byte[] Image { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFile : ISpriteSubFile
    {
        public ushort X { get; internal set; }
        public ushort Y { get; internal set; }
        public ushort GroupNumber { get; internal set; }
        public ushort ImageNumber { get; internal set; }
        public ushort IndexPreviousCopy { get; internal set; }
        public byte SamePalette { get; internal set; }
        public byte[] Image { get; internal set; }
    }
}