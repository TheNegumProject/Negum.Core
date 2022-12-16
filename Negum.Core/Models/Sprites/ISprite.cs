using System.Collections.Generic;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Sprites;

/// <summary>
/// Represents general definition of a single sprite file (.sff)
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISprite
{
    string? Signature { get; }
    string? Version { get; }
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
    public string? Signature { get; init; }
    public string? Version { get; init; }
    public IEnumerable<ISpriteSubFile> SpriteSubFiles { get; } = new List<ISpriteSubFile>();
    public IEnumerable<IPalette> Palettes { get; } = new List<IPalette>();

    public void AddSubFile(ISpriteSubFile subFile) =>
        ((List<ISpriteSubFile>) SpriteSubFiles).Add(subFile);

    public void AddPalette(IPalette palette) =>
        ((List<IPalette>) Palettes).Add(palette);
}