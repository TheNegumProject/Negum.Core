namespace Negum.Core.Models.Sprites.Png;

/// <summary>
/// PNG chunk header.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffPngChunkHeader
{
    /// <summary>
    /// Length of the chunk header.
    /// </summary>
    uint Length { get; }

    /// <summary>
    /// Name of the chunk.
    /// </summary>
    string Name { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffPngChunkHeader : ISffPngChunkHeader
{
    public uint Length { get; internal init; }
    public string Name { get; internal init; } = string.Empty;
}