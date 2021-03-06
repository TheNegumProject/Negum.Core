using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Extensions;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers.Sff
{
    /// <summary>
    /// Represents a reader for SFF v1.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffSpriteV1Reader : ISffSpriteReader
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffSpriteV1Reader : SffSpriteReader, ISffSpriteV1Reader
    {
        public override async Task<ISprite> ReadAsync(BinaryReader binaryReader, string signature, string version)
        {
            var paletteReader = NegumContainer.Resolve<IPaletteReader>();

            var sprite = new SffSpriteV1
            {
                Signature = signature,
                Version = version,
                Groups = binaryReader.ReadUInt32(),
                Images = binaryReader.ReadUInt32(),
                PosFirstSubFile = binaryReader.ReadUInt32(),
                Length = binaryReader.ReadUInt32(),
                PaletteType = binaryReader.ReadByte(),
                Blank = binaryReader.ReadBytes(3).ToUtf8String(),
                Comments = binaryReader.ReadBytes(476).ToUtf8String()
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

                var comments = binaryReader.ReadBytes(14).ToUtf8String();

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
    }
}