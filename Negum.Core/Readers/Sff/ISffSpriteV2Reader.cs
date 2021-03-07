using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers.Sff
{
    /// <summary>
    /// Represents a reader for SFF v2.
    ///
    /// NOTE:
    /// Since SFF v2 has more layers of complexity, it's default implementation has been moved to a different repository.
    /// https://github.com/TheNegumProject/Negum.Core.Readers.Sff.v2
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffSpriteV2Reader : ISffSpriteReader
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffSpriteV2Reader : SffSpriteReader, ISffSpriteV2Reader
    {
        public override async Task<ISprite> ReadAsync(BinaryReader binaryReader, string signature, string version)
        {
            const string message = "SFF v2 is not supported by default -> https://github.com/TheNegumProject/Negum.Core.Readers.Sff.v2";

            throw new NotImplementedException(message);
        }
    }
}