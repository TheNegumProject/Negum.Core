using Negum.Core.Models.Sprites;

namespace Negum.Core.Models.Fonts;

/// <summary>
/// Represents a Font V2 read by reader.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFontV2 : IFont
{
    /// <summary>
    /// Name of the Font.
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// Name of the sprite file.
    /// </summary>
    string? SpriteFile { get; }

    /// <summary>
    /// Sprite read from SFF file.
    /// </summary>
    ISprite? Sprite { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontV2 : Font, IFontV2
{
    public string? Name { get; internal set; }
    public string? SpriteFile { get; internal set; }
    public ISprite? Sprite { get; internal set; }
}