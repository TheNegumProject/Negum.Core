using Negum.Core.Models.Pcx;

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
        uint NextSubFileOffset { get; }
        uint PcxDataLength { get; }
        ushort X { get; }
        ushort Y { get; }
        ushort GroupNumber { get; }
        ushort ImageNumber { get; }
        ushort Index { get; }
        byte SamePalette { get; }
        IPcxImage PcxImage { get; }
        string Comment { get; }
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteSubFileSffV1 : SpriteSubFile, ISpriteSubFileSffV1
    {
        public uint NextSubFileOffset { get; internal set; }
        public uint PcxDataLength { get; internal set; }
        public ushort X { get; internal set; }
        public ushort Y { get; internal set; }
        public ushort GroupNumber { get; internal set; }
        public ushort ImageNumber { get; internal set; }
        public ushort Index { get; internal set; }
        public byte SamePalette { get; internal set; }
        public IPcxImage PcxImage { get; internal set; }
        public string Comment { get; internal set; }
    }
}