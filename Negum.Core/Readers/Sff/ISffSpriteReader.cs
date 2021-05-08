using System;
using System.IO;
using System.Threading.Tasks;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers.Sff
{
    /// <summary>
    /// Represents a general SFF reader.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffSpriteReader : IStreamReader<ISprite>
    {
        Task<ISprite> ReadAsync(BinaryReader binaryReader, string signature, string version);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public abstract class SffSpriteReader : ISffSpriteReader
    {
        public virtual async Task<ISprite> ReadAsync(Stream input)
        {
            throw new NotSupportedException("Please use ISpriteReader.ReadAsync(BinaryReader, Signature, Version) method overload");
        }

        public abstract Task<ISprite> ReadAsync(BinaryReader binaryReader, string signature, string version);
    }
}