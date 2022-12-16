using Negum.Core.Models.Pcx;

namespace Negum.Core.Models.Fonts;

/// <summary>
/// Represents a Font V0 read by reader.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IFontV0 : IFont
{
    /// <summary>
    /// File signature.
    /// </summary>
    string? Signature { get; }

    /// <summary>
    /// Version of the font.
    /// Based on that, the appropriate reader should be used.
    /// </summary>
    string? Version { get; }

    /// <summary>
    /// Offset to the place where sprites are stored.
    /// </summary>
    uint SpriteDataOffset { get; }

    /// <summary>
    /// Length of the data with sprites.
    /// </summary>
    int SpriteDataLength { get; }

    /// <summary>
    /// Offset to the place where text data is stored.
    /// </summary>
    uint TextDataOffset { get; }

    /// <summary>
    /// Length of the data with text.
    /// </summary>
    int TextDataLength { get; }

    /// <summary>
    /// Additional comment.
    /// </summary>
    string? Comment { get; }

    /// <summary>
    /// Image read from FNT file.
    /// </summary>
    IPcxImage? Image { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class FontV0 : Font, IFontV0
{
    public string? Signature { get; internal init; }
    public string? Version { get; internal init; }
    public uint SpriteDataOffset { get; internal init; }
    public int SpriteDataLength { get; internal init; }
    public uint TextDataOffset { get; internal init; }
    public int TextDataLength { get; internal init; }
    public string? Comment { get; internal init; }
    public IPcxImage? Image { get; internal set; }
}