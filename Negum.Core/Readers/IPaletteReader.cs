using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models.Palettes;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle Palette (.act) files.
    /// Palette files (.act) are the 256 colour data files that determine what colours go where on a character.
    /// A single game character can have up to 12 act files that can be read by the game engine - these are determined by the .def file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface IPaletteReader : IStreamReader<IPalette>
    {
        /// <summary>
        /// Reads a specified amount of colors from the stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="count"></param>
        /// <returns>Palette with read colors.</returns>
        IPalette ReadExact(Stream stream, int count);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class PaletteReader : IPaletteReader
    {
        public async Task<IPalette> ReadAsync(Stream stream) =>
            await Task.FromResult(this.ReadExact(stream, 256));

        public IPalette ReadExact(Stream stream, int count)
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
                };

                palette.Colors.Push(color);
            }

            return palette;
        }
    }
}