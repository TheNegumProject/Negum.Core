using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle Palette (.act) files.
    /// Palette files (.act) are the 256 colour data files that determine what colours go where on a character.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPaletteReader : IStreamReader<IPalette>, IReader<byte[], IPalette>
    {
        /// <summary>
        /// Reads a specified amount of colors from the stream.
        /// </summary>
        /// <param name="paletteData">Array of palette data.</param>
        /// <param name="count">Number of colors in palette.</param>
        /// <param name="readAlpha">True if should read alpha; false otherwise - by default will set alpha to 255.</param>
        /// <param name="defaultAlpha">Default alpha value</param>
        /// <returns>Palette with read colors.</returns>
        IPalette ReadExact(byte[] paletteData, int count, bool readAlpha = false, byte defaultAlpha = 255);

        /// <summary>
        /// Reads a specified amount of colors from the stream.
        /// </summary>
        /// <param name="stream">Stream with the palette data.</param>
        /// <param name="count">Number of colors in palette.</param>
        /// <param name="readAlpha">True if should read alpha; false otherwise - by default will set alpha to 255.</param>
        /// <param name="defaultAlpha">Default alpha value</param>
        /// <returns>Palette with read colors.</returns>
        IPalette ReadExact(Stream stream, int count, bool readAlpha = false, byte defaultAlpha = 255);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PaletteReader : IPaletteReader
    {
        public async Task<IPalette> ReadAsync(byte[] input) =>
            await this.ReadAsync(new MemoryStream(input));

        public async Task<IPalette> ReadAsync(Stream stream) =>
            await Task.FromResult(this.ReadExact(stream, 256));

        public IPalette ReadExact(byte[] paletteData, int count, bool readAlpha = false, byte defaultAlpha = 255) =>
            this.ReadExact(new MemoryStream(paletteData), count, readAlpha, defaultAlpha);

        public IPalette ReadExact(Stream stream, int count, bool readAlpha = false, byte defaultAlpha = 255)
        {
            var binaryReader = new BinaryReader(stream);
            var palette = new Palette();

            for (var i = 0; i < count; ++i)
            {
                var color = new Color
                {
                    Red = binaryReader.ReadByte(),
                    Green = binaryReader.ReadByte(),
                    Blue = binaryReader.ReadByte(),
                    Alpha = readAlpha ? binaryReader.ReadByte() : defaultAlpha
                };

                palette.AddColor(color);
            }

            return palette;
        }
    }
}