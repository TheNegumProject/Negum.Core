using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Containers;
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
    public class SpriteReader : CommonFileReader, ISpriteReader
    {
        public async Task<ISprite> ReadAsync(Stream stream)
        {
            var binaryReader = new BinaryReader(stream);
            var (signature, version) = this.ReadFileHeader(binaryReader);

            if (version.StartsWith("1"))
            {
                return await NegumContainer.Resolve<ISffSpriteV1Reader>().ReadAsync(binaryReader, signature, version);
            }

            if (version.StartsWith("2"))
            {
                return await NegumContainer.Resolve<ISffSpriteV2Reader>().ReadAsync(binaryReader, signature, version);
            }

            throw new ArgumentException($"Unknown version: {version}");
        }
    }
}