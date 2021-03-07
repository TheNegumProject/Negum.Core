using System.Collections.Generic;
using System.Threading.Tasks;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers.Sff.V2
{
    /// <summary>
    /// Represents a reader which is used to read PNG files from SFF v2 sprite's sub-file.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISffPngReader : IReader<ISpriteSubFileSffV2, IEnumerable<byte>>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SffPngReader : ISffPngReader
    {
        public async Task<IEnumerable<byte>> ReadAsync(ISpriteSubFileSffV2 subFile)
        {
            // TODO: Implement appropriate logic for handling PNG; (Does any stage / character really use SFFv2 ???)
            return await Task.FromResult(subFile.Image);
        }
    }
}