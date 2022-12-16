using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Models.Palettes;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png;

/// <summary>
/// Component which is responsible for applying specified palette to the image.
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public interface ISffPngPaletteApplier
{
    /// <summary>
    /// Applies palette to the specified image.
    /// </summary>
    /// <param name="imageHeader">SFF v2 PNG image header.</param>
    /// <param name="imageData">Image to which palette will be applied.</param>
    /// <param name="palette">Palette which will be applied to an image.</param>
    /// <returns>Image with palette applied.</returns>
    Task<byte[]> ApplyAsync(ISffPngImageHeader imageHeader, byte[] imageData, IPalette? palette);
}

/// <summary>
/// </summary>
/// 
/// <author>
/// https://github.com/TheNegumProject/Negum.Core
/// </author>
public class SffPngPaletteApplier : ISffPngPaletteApplier
{
    public Task<byte[]> ApplyAsync(ISffPngImageHeader imageHeader, byte[] imageData, IPalette? palette)
    {
        // (Scanline filter byte + imageHeader.Width * 4 RGBA bytes) * imageHeader.Height == imageData.Length
        if ((1 + imageHeader.Width * 4) * imageHeader.Height == imageData.Length)
        {
            // Already in RGBA format
            return Task.FromResult(imageData);
        }

        if (palette == null)
        {
            throw new ArgumentNullException("Palette is required to decode PNG image.");
        }
            
        var coloredImage = new List<byte>();

        for (var index = 0; index < imageData.Length; ++index)
        {
            var paletteIndex = imageData[index];

            // For scanline filter type we don't want to perform colorization
            if (index == 0 || index % imageHeader.BytesInRow == 0)
            {
                coloredImage.Add(paletteIndex);
                continue;
            }

            var color = palette.ElementAt(paletteIndex);

            coloredImage.Add(color.Red);
            coloredImage.Add(color.Green);
            coloredImage.Add(color.Blue);
            coloredImage.Add(color.Alpha);
        }

        return Task.FromResult(coloredImage.ToArray());
    }
}