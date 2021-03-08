namespace Negum.Core.Models.Sprites
{
    /// <summary>
    /// Represents a definition of a single sub-file in a sprite file in SFF v1.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteSubFileSffV1 : ISpriteSubFile
    {
        ushort X { get; }
        ushort Y { get; }
        ushort GroupNumber { get; }
        ushort ImageNumber { get; }
        ushort IndexPreviousCopy { get; }
        byte SamePalette { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFileSffV1 : SpriteSubFile, ISpriteSubFileSffV1
    {
        public ushort X { get; internal set; }
        public ushort Y { get; internal set; }
        public ushort GroupNumber { get; internal set; }
        public ushort ImageNumber { get; internal set; }
        public ushort IndexPreviousCopy { get; internal set; }
        public byte SamePalette { get; internal set; }
    }
}