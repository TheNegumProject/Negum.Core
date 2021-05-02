using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Models.Palettes;
using Negum.Core.Models.Sprites.Png;

namespace Negum.Core.Readers.Sff.V2.Png
{
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
        Task<byte[]> ApplyAsync(ISffPngImageHeader imageHeader, byte[] imageData, IPalette palette);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngPaletteApplier : ISffPngPaletteApplier
    {
        public async Task<byte[]> ApplyAsync(ISffPngImageHeader imageHeader, byte[] imageData, IPalette palette)
        {
            var imageWithPalette = new List<byte>();

            for (var pixelPosY = 0; pixelPosY < imageHeader.Height; ++pixelPosY)
            {
                for (var pixelPosX = 0; pixelPosX < imageHeader.Width; ++pixelPosX)
                {
                    if (palette != null)
                    {
                        this.ApplyPalette(imageHeader, imageData, palette, imageWithPalette, pixelPosX, pixelPosY);
                    }
                    else
                    {
                        this.ApplyDefaultPalette(imageHeader, imageData, imageWithPalette, pixelPosX, pixelPosY);
                    }
                }
            }

            return imageWithPalette.ToArray();
        }

        protected virtual void ApplyPalette(ISffPngImageHeader imageHeader, byte[] imageData, IPalette palette,
            ICollection<byte> imageWithPalette,
            int pixelPosX, int pixelPosY)
        {
            var pixelsPerByte = imageHeader.PixelsPerByte;
            var bytesInRow = imageHeader.BytesInRow;
            var byteIndexInRow = pixelPosX / pixelsPerByte;
            var paletteIndex = (1 + (pixelPosY * bytesInRow)) + byteIndexInRow;
            var b = imageData[paletteIndex];

            if (imageHeader.BitDepth == 8)
            {
                var color = palette.ElementAt(b);

                imageWithPalette.Add(color.Red);
                imageWithPalette.Add(color.Green);
                imageWithPalette.Add(color.Blue);
                imageWithPalette.Add(color.Alpha);

                return;
            }

            var withinByteIndex = pixelPosX % pixelsPerByte;
            var rightShift = 8 - ((withinByteIndex + 1) * imageHeader.BitDepth);
            var indexActual = (b >> rightShift) & ((1 << imageHeader.BitDepth) - 1);

            var colorActual = palette.ElementAt(indexActual);

            imageWithPalette.Add(colorActual.Red);
            imageWithPalette.Add(colorActual.Green);
            imageWithPalette.Add(colorActual.Blue);
            imageWithPalette.Add(colorActual.Alpha);
        }

        protected virtual void ApplyDefaultPalette(ISffPngImageHeader imageHeader, byte[] imageData,
            ICollection<byte> imageWithPalette,
            int pixelPosX, int pixelPosY)
        {
            var bytesPerPixel = imageHeader.GetBytesPerPixel();
            var rowStartPixel = (imageHeader.RowOffset + (imageHeader.RowOffset * pixelPosY)) +
                                (bytesPerPixel * imageHeader.Width * pixelPosY);
            var pixelStartIndex = rowStartPixel + (bytesPerPixel * pixelPosX);
            var first = imageData[pixelStartIndex];

            switch (bytesPerPixel)
            {
                case 1:
                    imageWithPalette.Add(first);
                    imageWithPalette.Add(first);
                    imageWithPalette.Add(first);
                    imageWithPalette.Add(255);

                    break;
                case 2:
                    switch (imageHeader.ColorType)
                    {
                        case 0:
                        {
                            var second = imageData[pixelStartIndex + 1];
                            var value = ToSingleByte(first, second);

                            imageWithPalette.Add(value);
                            imageWithPalette.Add(value);
                            imageWithPalette.Add(value);
                            imageWithPalette.Add(255);

                            break;
                        }
                        default:
                            imageWithPalette.Add(first);
                            imageWithPalette.Add(first);
                            imageWithPalette.Add(first);
                            imageWithPalette.Add(imageData[pixelStartIndex + 1]);

                            break;
                    }

                    break;
                case 3:
                    imageWithPalette.Add(first);
                    imageWithPalette.Add(imageData[pixelStartIndex + 1]);
                    imageWithPalette.Add(imageData[pixelStartIndex + 2]);
                    imageWithPalette.Add(255);

                    break;
                case 4:
                    switch (imageHeader.ColorType)
                    {
                        case 0 | 4:
                        {
                            var second = imageData[pixelStartIndex + 1];
                            var firstAlpha = imageData[pixelStartIndex + 2];
                            var secondAlpha = imageData[pixelStartIndex + 3];
                            var gray = ToSingleByte(first, second);
                            var alpha = ToSingleByte(firstAlpha, secondAlpha);

                            imageWithPalette.Add(gray);
                            imageWithPalette.Add(gray);
                            imageWithPalette.Add(gray);
                            imageWithPalette.Add(alpha);

                            break;
                        }
                        default:
                            imageWithPalette.Add(first);
                            imageWithPalette.Add(imageData[pixelStartIndex + 1]);
                            imageWithPalette.Add(imageData[pixelStartIndex + 2]);
                            imageWithPalette.Add(imageData[pixelStartIndex + 3]);

                            break;
                    }

                    break;
                case 6:
                    imageWithPalette.Add(first);
                    imageWithPalette.Add(imageData[pixelStartIndex + 2]);
                    imageWithPalette.Add(imageData[pixelStartIndex + 4]);
                    imageWithPalette.Add(255);

                    break;
                case 8:
                    imageWithPalette.Add(first);
                    imageWithPalette.Add(imageData[pixelStartIndex + 2]);
                    imageWithPalette.Add(imageData[pixelStartIndex + 4]);
                    imageWithPalette.Add(imageData[pixelStartIndex + 6]);

                    break;
                default:
                    throw new InvalidOperationException(
                        $"Unrecognized number of bytes per pixel: {bytesPerPixel}.");
            }
        }

        protected virtual byte ToSingleByte(byte first, byte second)
        {
            var us = (first << 8) + second;
            var result = (byte) Math.Round((255 * us) / (double) ushort.MaxValue);
            return result;
        }
    }
}