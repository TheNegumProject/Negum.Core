using System.Threading.Tasks;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites;

namespace Negum.Core.Readers
{
    /// <summary>
    /// Reader which is designed to read Sprite from specified path.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public interface ISpritePathReader : IReader<string, ISprite>
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Core
    /// </author>
    public class SpritePathReader : ISpritePathReader
    {
        public async Task<ISprite> ReadAsync(string path)
        {
            var fileContentReader = NegumContainer.Resolve<IFileContentReader>();
            var fileContentStream = await fileContentReader.ReadAsync(path);

            var memoryStreamReader = NegumContainer.Resolve<IMemoryStreamReader>();
            var memoryStream = await memoryStreamReader.ReadAsync(fileContentStream);
            
            var spriteReader = NegumContainer.Resolve<ISpriteReader>();
            var sprite = await spriteReader.ReadAsync(memoryStream);

            return sprite;
        }
    }
}