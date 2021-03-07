using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Extensions;
using Negum.Core.Models.Sprites;
using Negum.Core.Readers.Sff;

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

            var signature = binaryReader.ReadBytes(12).ToUtf8String();
            var version = this.GetVersion(binaryReader);

            if (version.StartsWith("1"))
            {
                var sffV1Reader = NegumContainer.Resolve<ISffSpriteV1Reader>();
                return await sffV1Reader.ReadAsync(binaryReader, signature, version);
            }

            if (version.StartsWith("2"))
            {
                var sffV2Reader = NegumContainer.Resolve<ISffSpriteV2Reader>();
                return await sffV2Reader.ReadAsync(binaryReader, signature, version);
            }

            throw new ArgumentException($"Unknown version: {version}");
        }

        protected virtual string GetVersion(BinaryReader binaryReader)
        {
            var versionBytes = binaryReader.ReadBytes(4);
            var versionString = $"{versionBytes[3]}.{versionBytes[2]}{versionBytes[1]}{versionBytes[0]}";
            return versionString;
        }
    }
}