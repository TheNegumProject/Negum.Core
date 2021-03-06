using System.IO;
using System.Text;
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
            var binaryReader = new BinaryReader(stream);
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();

            var sprite = new Sprite
            {
                Signature = this.BytesToString(binaryReader.ReadBytes(12)),
                Version = this.GetVersion(binaryReader),
                Groups = binaryReader.ReadUInt32(),
                Images = binaryReader.ReadUInt32(),
                PosFirstSubFile = binaryReader.ReadUInt32(),
                Length = binaryReader.ReadUInt32(),
                PaletteType = binaryReader.ReadByte(),
                Blank = this.BytesToString(binaryReader.ReadBytes(3)),
                Comments = this.BytesToString(binaryReader.ReadBytes(476))
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

                var comments = this.BytesToString(binaryReader.ReadBytes(14));

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
                    var palette = await paletteReader.ReadAsync(paletteStream);
                    sprite.Palette = palette.Reverse();
                }

                binaryReader.BaseStream.Position = nextSubFile;
                
                sprite.AddSubFile(subFile);
            }

            return sprite;
        }
        
        protected virtual string BytesToString(byte[] bytes) => 
            Encoding.UTF8.GetString(bytes);

        protected virtual string GetVersion(BinaryReader binaryReader)
        {
            var versionBytes = binaryReader.ReadBytes(4);
            var versionString = $"{versionBytes[3]}.{versionBytes[2]}{versionBytes[1]}{versionBytes[0]}";
            return versionString;
        }
    }
}