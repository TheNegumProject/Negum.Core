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
    public interface IPcxReader : IStreamReader<IPcxImage>
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
        public async Task<IPcxImage> ReadAsync(Stream stream)
        {
            var binaryReader = new BinaryReader(stream);
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();

            var image = new PcxImage
            {
                Id = binaryReader.ReadByte(),
                Version = binaryReader.ReadByte(),
                Encoding = binaryReader.ReadByte(),
                BitPerPixel = binaryReader.ReadByte(),
                X = binaryReader.ReadUInt16(),
                Y = binaryReader.ReadUInt16(),
                Width = (ushort) (binaryReader.ReadUInt16() + 1), // We can't increment it later
                Height = (ushort) (binaryReader.ReadUInt16() + 1), // Same as above
                HRes = binaryReader.ReadUInt16(),
                VRes = binaryReader.ReadUInt16()
            };

            const int paletteColors = 16;
            var paletteBuffer = binaryReader.ReadBytes(paletteColors * 3); // 16 colors * RGB
            var paletteStream = new MemoryStream(paletteBuffer);
            var colorPalette = paletteReader.ReadExact(paletteStream, paletteColors);
            image.ColorPalette = colorPalette.Reverse();

            image.Reserved = binaryReader.ReadByte();
            image.NbPlanes = binaryReader.ReadByte();
            image.Bpl = binaryReader.ReadByte();
            image.PaletteInfo = binaryReader.ReadUInt16();

            // 769 => (256 colors * RGB) + 1 for signature
            binaryReader.BaseStream.Position = binaryReader.BaseStream.Length - 769;
            image.Signature = binaryReader.ReadByte();

            paletteBuffer = binaryReader.ReadBytes(768); // 256 colors * RGB
            paletteStream = new MemoryStream(paletteBuffer);
            var palette = await paletteReader.ReadAsync(paletteStream);
            image.Palette = palette.Reverse();

            binaryReader.BaseStream.Position = 128;

            var x = image.X;
            var y = image.Y;
            var pixels = new byte[image.Width * image.Height * 4]; // width * height * RGBA

            while (y < image.Height)
            {
                var b = binaryReader.ReadByte();
                int runCount;
                int value;

                if ((b & 0xC0) == 0xC0)
                {
                    runCount = b & 0x3F;
                    value = binaryReader.ReadByte();
                }
                else
                {
                    runCount = 1;
                    value = b;
                }

                for (var i = 0; i < runCount; ++i)
                {
                    if (value != 0)
                    {
                        var pos = (x + y * image.Width) * 4;
                        pixels[pos + 0] = image.Palette.ElementAt(value).Red;
                        pixels[pos + 1] = image.Palette.ElementAt(value).Green;
                        pixels[pos + 2] = image.Palette.ElementAt(value).Blue;
                        pixels[pos + 3] = 255;
                    }

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