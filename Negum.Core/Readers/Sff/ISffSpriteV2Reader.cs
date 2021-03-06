using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers.Sff
{
    /// <summary>
    /// Represents a reader for SFF v2.
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
            var sprite = new SffSpriteV2
            {
                Signature = signature,
                Version = version,
            };

            throw new Exception();
        }
    }
}