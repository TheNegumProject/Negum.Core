using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Pcx;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle PCX files.
    /// PCX stands for “Picture Exchange”, which is a Paintbrush Bitmap image format.
    /// It was developed as one of the initial bitmap image formats for DOS and Windows.
    /// Supporting 24-bit true color images, 1-bit black and white images, 8-bit grayscale and indexed color images.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPcxReader : IReader<IPcxDetails, IPcxImage>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PcxReader : IPcxReader
    {
        public async Task<IPcxImage> ReadAsync(IPcxDetails pcxDetails)
        {
            var binaryReader = new BinaryReader(pcxDetails.Stream);
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();

            var image = new PcxImage
            {
                Id = binaryReader.ReadByte(),
                Version = binaryReader.ReadByte(),
                Encoding = binaryReader.ReadByte(),
                BitPerPixel = binaryReader.ReadByte(),
                X = binaryReader.ReadUInt16(),
                Y = binaryReader.ReadUInt16(),
                Width = binaryReader.ReadUInt16(),
                Height = binaryReader.ReadUInt16(),
                HRes = binaryReader.ReadUInt16(),
                VRes = binaryReader.ReadUInt16()
            };

            const int paletteColors = 16; // 16 colors RGB
            var paletteBuffer = binaryReader.ReadBytes(paletteColors * 3); // 16 colors * RGB
            var colorPalette = paletteReader.ReadExact(paletteBuffer, paletteColors, false);
            image.ColorPalette = colorPalette.Reverse();

            image.Reserved = binaryReader.ReadByte();
            image.NbPlanes = binaryReader.ReadByte();
            image.BitesPerLine = binaryReader.ReadByte();
            image.PaletteInfo = binaryReader.ReadUInt16();

            if (pcxDetails.Palette == null)
            {
                // 769 => (256 colors * RGB) + 1 for signature
                binaryReader.BaseStream.Position = binaryReader.BaseStream.Length - 769;
                image.Signature = binaryReader.ReadByte();

                paletteBuffer = binaryReader.ReadBytes(768); // 256 colors * RGB
                var palette = await paletteReader.ReadAsync(paletteBuffer);
                image.Palette = palette.Reverse();
            }
            else
            {
                image.Palette = pcxDetails.Palette;
            }

            binaryReader.BaseStream.Position = 128;

            image.Width++;
            image.Height++;

            var x = image.X;
            var y = image.Y;
            var pixels = new List<byte>();
            var firstColorInPalette = image.Palette.ElementAt(0);

            while (y < image.Height)
            {
                var isCompressed = binaryReader.ReadByte();
                int numberOfPixels;
                int paletteColorIndex;

                if ((isCompressed & 0xC0) == 0xC0)
                {
                    numberOfPixels = isCompressed & 0x3F;
                    paletteColorIndex = binaryReader.ReadByte();
                }
                else
                {
                    numberOfPixels = 1;
                    paletteColorIndex = isCompressed;
                }

                for (var i = 0; i < numberOfPixels; ++i)
                {
                    var color = paletteColorIndex != 0
                        ? image.Palette.ElementAt(paletteColorIndex)
                        : firstColorInPalette;

                    pixels.Add(color.Red);
                    pixels.Add(color.Green);
                    pixels.Add(color.Blue);
                    pixels.Add(color.Alpha);

                    x++;

                    if (x >= image.Width)
                    {
                        y++;
                        x = image.X;
                    }
                }
            }

            image.Pixels = pixels;

            return image;
        }
    }
}