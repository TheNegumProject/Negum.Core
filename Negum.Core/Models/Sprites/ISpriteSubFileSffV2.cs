namespace Negum.Core.Models.Sprites;

/// <summary>
/// Represents a definition of a single sub-file in a sprite file in SFF v2.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISpriteSubFileSffV2 : ISpriteSubFile
{
    byte CompressionMethod { get; }
    byte ColorDepth { get; }
    ushort LoadMode { get; }
    uint ImageSize { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SpriteSubFileSffV2 : SpriteSubFile, ISpriteSubFileSffV2
{
    public byte CompressionMethod { get; internal init; }
    public byte ColorDepth { get; internal init; }
    public ushort LoadMode { get; internal init; }
    public uint ImageSize { get; internal set; }
}