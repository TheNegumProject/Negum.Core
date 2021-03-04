using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to handle Sprite (.sff) files.
    /// The sprites file (.sff) contains every image (sprite) used by a stage, character, screenpack, etc.
    /// Because game runs off indexed images with 256 colour palettes, transparency has to be a single forced colour rather than actual transparency.
    /// If a sprite isn't indexed, it runs off the palette of the computer's operating system, with the default transparency colour being black.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpriteReader : IStreamReader<ISprite>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpriteReader : ISpriteReader
    {
        public async Task<ISprite> ReadAsync(Stream stream)
        {
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            
            var binaryReader = new BinaryReader(memoryStream);
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();

            var sprite = new Sprite
            {
                Signature = new string(binaryReader.ReadChars(12)),
                Version = new string(binaryReader.ReadChars(4)),
                Groups = binaryReader.ReadUInt32(),
                Images = binaryReader.ReadUInt32(),
                PosFirstSubFile = binaryReader.ReadUInt32(),
                Length = binaryReader.ReadUInt32(),
                PaletteType = binaryReader.ReadByte(),
                Blank = new string(binaryReader.ReadChars(3)),
                Comments = new string(binaryReader.ReadChars(476))
            };

            for (var i = 0; i < sprite.Images; ++i)
            {
                var nextSubFile = binaryReader.ReadUInt32();
                var subFileLength = binaryReader.ReadUInt32();
                
                var subFile = new SpriteSubFile
                {
                    X = binaryReader.ReadUInt16(),
                    Y = binaryReader.ReadUInt16(),
                    GroupNumber = binaryReader.ReadUInt16(),
                    ImageNumber = binaryReader.ReadUInt16(),
                    IndexPreviousCopy = binaryReader.ReadUInt16(),
                    SamePalette = binaryReader.ReadByte()
                };

                var comments = new string(binaryReader.ReadChars(14));

                if (subFile.IndexPreviousCopy == 0)
                {
                    binaryReader.BaseStream.Position -= 1;
                    var count = (int) (nextSubFile - binaryReader.BaseStream.Position);
                    subFile.Image = binaryReader.ReadBytes(count);
                }

                if (i == 0)
                {
                    var data = binaryReader.ReadBytes(768);
                    var paletteStream = new MemoryStream(data);
                    sprite.Palette = await paletteReader.ReadAsync(paletteStream);
                }

                binaryReader.BaseStream.Position = nextSubFile;
                
                sprite.AddSubFile(subFile);
            }

            return sprite;
        }
    }
}