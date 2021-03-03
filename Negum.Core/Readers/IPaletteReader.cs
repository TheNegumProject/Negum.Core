using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models;

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
            await Task.FromResult(this.Read(stream));

        protected virtual IPalette Read(Stream stream)
        {
            var palette = new Palette();

            for (var i = 0; i < 256; ++i)
            {
                var color = new Color
                {
                    Red = stream.ReadByte(),
                    Green = stream.ReadByte(),
                    Blue = stream.ReadByte()
                };

                palette.Colors.Push(color);
            }

            return palette;
        }
    }
}