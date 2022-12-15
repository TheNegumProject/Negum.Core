using System.Collections;
using System.Collections.Generic;

namespace Negum.Core.Models.Palettes;

/// <summary>
/// Represents a palette.
/// Palette is build of a collection of colors.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface IPalette : IEnumerable<IColor>
{
    ushort GroupNumber { get; }
    ushort ItemNumber { get; }
    ushort ColorNumber { get; }
    ushort LinkedIndex { get; }
    uint LDataOffset { get; }
    uint LDataLength { get; }
        
    /// <summary>
    /// Adds new color at the end of the palette.
    /// </summary>
    /// <param name="color"></param>
    void AddColor(IColor color);
        
    /// <summary>
    /// </summary>
    /// <returns>Copy of a current palette but in reversed order.</returns>
    IPalette Reverse();

    /// <summary>
    /// Copies current palette into the selected one.
    /// </summary>
    /// <param name="palette"></param>
    void CopyTo(IPalette palette);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class Palette : IPalette
{
    private IList<IColor> Colors { get; } = new List<IColor>();
        
    public ushort GroupNumber { get; internal init; }
    public ushort ItemNumber { get; internal init; }
    public ushort ColorNumber { get; internal init; }
    public ushort LinkedIndex { get; internal init; }
    public uint LDataOffset { get; internal init; }
    public uint LDataLength { get; internal init; }

    public void AddColor(IColor color) => 
        Colors.Add(color);

    public IPalette Reverse()
    {
        var palette = new Palette();
            
        for (var i = Colors.Count - 1; i >= 0; --i)
        {
            var color = Colors[i];
            palette.AddColor(color);
        }

        return palette;
    }

    public void CopyTo(IPalette palette)
    {
        foreach (var color in Colors)
        {
            palette.AddColor(color);
        }
    }
        
    public IEnumerator<IColor> GetEnumerator() =>
        Colors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}