using System.IO;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Models.Pcx;

/// <summary>
/// Represents a general data required to properly parse PCX file.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPcxDetails
{
    /// <summary>
    /// Stream containing the PCX file.
    /// </summary>
    Stream? Stream { get; }

    /// <summary>
    /// Palette which should be used for this specific image.
    /// </summary>
    IPalette? Palette { get; }
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class PcxDetails : IPcxDetails
{
    public Stream? Stream { get; internal init; }
    public IPalette? Palette { get; internal init; }
}